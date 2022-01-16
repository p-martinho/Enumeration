using Enumeration.EFCore.Sample.DbContext;
using Enumeration.EFCore.Sample.Entities;
using Enumeration.Sample.Enumerations;
using Microsoft.EntityFrameworkCore;

namespace Enumeration.EFCore.Sample.Samples;

public class CommunicationUsingEFCoreSample
{
    private readonly SampleDbContext _context;

    public CommunicationUsingEFCoreSample(SampleDbContext context)
    {
        _context = context;
    }

    public async Task SaveCommunicationRecord(string to, CommunicationType communicationType)
    {
        var record = new CommunicationRecord
        {
            To = to,
            Type = communicationType
        };

        _context.CommunicationRecords.Add(record);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<CommunicationRecord>> GetCommunicationRecordsByType(CommunicationType communicationType)
    {
        var records = await _context.CommunicationRecords
            .Where(r => r.Type == communicationType)
            .ToListAsync();

        return records;
    }
}