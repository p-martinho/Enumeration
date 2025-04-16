using System.Text.Json;
using Enumeration.SystemTextJson.Sample.Models;
using PMart.Enumeration.SystemTextJson;

namespace Enumeration.SystemTextJson.Sample.Samples;

public static class SerializeCommunicationSample
{
    public static string SerializeCommunicationRecord(CommunicationRecord communicationRecord)
    {
        var serializerOptions = GetSerializerOptions();

        var json = JsonSerializer.Serialize(communicationRecord, serializerOptions);

        return json;
    }

    public static CommunicationRecord? DeserializeCommunicationRecord(string json)
    {
        var serializerOptions = GetSerializerOptions();

        var communicationRecord = JsonSerializer.Deserialize<CommunicationRecord>(json, serializerOptions);

        return communicationRecord;
    }

    private static JsonSerializerOptions GetSerializerOptions()
    {
        return new JsonSerializerOptions
        {
            Converters = { new EnumerationConverterFactory() }
        };
    }
}