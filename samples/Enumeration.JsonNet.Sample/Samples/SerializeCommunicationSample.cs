using Enumeration.JsonNet.Sample.Models;
using Newtonsoft.Json;
using PMart.Enumeration.JsonNet;

namespace Enumeration.JsonNet.Sample.Samples;

public class SerializeCommunicationSample
{
    public string SerializeCommunicationRecord(CommunicationRecord communicationRecord)
    {
        var serializerSettings = GetSerializerSettings();

        var json = JsonConvert.SerializeObject(communicationRecord, serializerSettings);

        return json;
    }

    public CommunicationRecord? DeserializeCommunicationRecord(string json)
    {
        var serializerSettings = GetSerializerSettings();
        
        var communicationRecord = JsonConvert.DeserializeObject<CommunicationRecord>(json, serializerSettings);

        return communicationRecord;
    }

    private JsonSerializerSettings GetSerializerSettings()
    {
        return new JsonSerializerSettings
        {
            Converters = {new EnumerationConverter()}
        };
    }
}