using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace WorkoutApiClient.Model
{
    public partial class ExerciseImage
    {
        [JsonProperty("count")]
        public long Count { get; set; }

        [JsonProperty("next")]
        public Uri Next { get; set; }

        [JsonProperty("previous")]
        public object Previous { get; set; }

        [JsonProperty("results")]
        public List<Result> Results { get; set; }
    }

    public partial class Result
    {
        [JsonProperty("id")]
        public long ImageId { get; set; }

        [JsonProperty("license_author")]
        public LicenseAuthor LicenseAuthor { get; set; }

        [JsonProperty("status")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long Status { get; set; }

        [JsonProperty("image")]
        public Uri Image { get; set; }

        [JsonProperty("is_main")]
        public bool IsMain { get; set; }

        [JsonProperty("license")]
        public long License { get; set; }

        [JsonProperty("exercise")]
        public long Exercise { get; set; }
    }

    public enum LicenseAuthor { Empty, Everkinetic };

    public partial class ExerciseImage
    {
        public static ExerciseImage FromJson(string json) => JsonConvert.DeserializeObject<ExerciseImage>(json, ImageConverter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this ExerciseImage self) => JsonConvert.SerializeObject(self, ImageConverter.Settings);
    }

    internal static class ImageConverter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                LicenseAuthorConverter.Singleton,
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }

    internal class LicenseAuthorConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(LicenseAuthor) || t == typeof(LicenseAuthor?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "":
                    return LicenseAuthor.Empty;
                case "Everkinetic":
                    return LicenseAuthor.Everkinetic;
                default: return LicenseAuthor.Empty;
            }
            //throw new Exception("Cannot unmarshal type LicenseAuthor");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (LicenseAuthor)untypedValue;
            switch (value)
            {
                case LicenseAuthor.Empty:
                    serializer.Serialize(writer, "");
                    return;
                case LicenseAuthor.Everkinetic:
                    serializer.Serialize(writer, "Everkinetic");
                    return;
                default:
                    serializer.Serialize(writer, "");
                    return;
            }
            //throw new Exception("Cannot marshal type LicenseAuthor");
        }

        public static readonly LicenseAuthorConverter Singleton = new LicenseAuthorConverter();
    }

    internal class ParseStringConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(long) || t == typeof(long?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            long l;
            if (Int64.TryParse(value, out l))
            {
                return l;
            }
            throw new Exception("Cannot unmarshal type long");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (long)untypedValue;
            serializer.Serialize(writer, value.ToString());
            return;
        }

        public static readonly ParseStringConverter Singleton = new ParseStringConverter();
    }
}
