using Enumeration.JsonNet.Sample.Models;
using Newtonsoft.Json;
using PMart.Enumeration.JsonNet;

namespace Enumeration.JsonNet.Sample.Samples;

public static class SerializeCommunicationSample
{
    public static string SerializeCommunicationRecord(CommunicationRecord communicationRecord)
    {
        var serializerSettings = GetSerializerSettings();

        var json = JsonConvert.SerializeObject(communicationRecord, serializerSettings);

        return json;
    }

    public static CommunicationRecord? DeserializeCommunicationRecord(string json)
    {
        var serializerSettings = GetSerializerSettings();

        var communicationRecord = JsonConvert.DeserializeObject<CommunicationRecord>(json, serializerSettings);

        return communicationRecord;
    }

    private static JsonSerializerSettings GetSerializerSettings()
    {
        return new JsonSerializerSettings
        {
            Converters = { new EnumerationConverter() }
        };
    }
}