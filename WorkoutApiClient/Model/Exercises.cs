using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using WorkoutApiClient.Serialization;

namespace WorkoutApiClient.Model
{
    public partial class Exercises
    {
        [JsonProperty("count")]
        public long Count { get; set; }

        [JsonProperty("next")]
        public Uri Next { get; set; }

        [JsonProperty("previous")]
        public object Previous { get; set; }

        [JsonProperty("results")]
        public List<Exercise> Results { get; set; }
    }

    public class Exercise
    {
        [JsonProperty("id")]
        public int ExerciseId { get; set; }

        [JsonProperty("license_author")]
        public string LicenseAuthor { get; set; }

        [JsonProperty("status")]
        public int Status { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("name")]
        public string ExerciseName { get; set; }

        [JsonProperty("name_original")]
        public string NameOriginal { get; set; }

        [JsonProperty("creation_date")]
        public DateTimeOffset? CreationDate { get; set; }

        [JsonProperty("uuid")]
        public Guid Uuid { get; set; }

        [JsonProperty("license")]
        public long License { get; set; }

        [JsonProperty("category")]
        public long Category { get; set; }

        [JsonProperty("language")]
        public long Language { get; set; }

        [JsonProperty("muscles")]
        public List<long> Muscles { get; set; }

        [JsonProperty("muscles_secondary")]
        public List<long> MusclesSecondary { get; set; }

        [JsonProperty("equipment")]
        public List<int> Equipment { get; set; }
    }

    public partial class Exercises
    {
        public static Exercises FromJson(string json) => JsonConvert.DeserializeObject<Exercises>(json, Converter.Settings);
    }
}
