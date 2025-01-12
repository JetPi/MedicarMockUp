using System.Runtime.Serialization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Types
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum IVehicle
    {
        [EnumMember(Value = "Ambulance")]
        Ambulance,

        [EnumMember(Value = "Personal")]
        Personal,

        [EnumMember(Value = "Express")]
        Express,

        [EnumMember(Value = "Ramped")]
        Ramped,
    }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum IDocumentType
    {
        [EnumMember(Value = "Foreign")]
        Foreign,

        [EnumMember(Value = "National")]
        National,

        [EnumMember(Value = "Legal")]
        Legal,
    }
}
