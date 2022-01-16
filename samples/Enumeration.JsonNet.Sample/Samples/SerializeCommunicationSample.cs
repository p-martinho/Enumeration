using Enumeration.JsonNet.Sample.Models;
using Newtonsoft.Json;
using PMart.Enumeration.JsonNet;

namespace Enumeration.JsonNet.Sample.Samples;

public class SerializeCommunicationSample
{
    public string SerializeCommunicationRecord(CommunicationRecord communicationRecord)
    {
        var json = JsonConvert.SerializeObject(communicationRecord, new EnumerationConverter());

        return json;
    }

    public CommunicationRecord? DeserializeCommunicationRecord(string json)
    {
        var communicationRecord = JsonConvert.DeserializeObject<CommunicationRecord>(json, new EnumerationConverter());

        return communicationRecord;
    }
}