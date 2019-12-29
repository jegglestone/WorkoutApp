using Newtonsoft.Json;
using System.Collections.Generic;

namespace WorkoutApiClient.Model
{
    public partial class ExerciseCategory
    {
        [JsonProperty("count")]
        public long Count { get; set; }

        [JsonProperty("next")]
        public object Next { get; set; }

        [JsonProperty("previous")]
        public object Previous { get; set; }

        [JsonProperty("results")]
        public List<Result> Results { get; set; }
    }

    public partial class Result
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public partial class ExerciseCategory
    {
        public static ExerciseCategory FromJson(string json) => JsonConvert.DeserializeObject<ExerciseCategory>(json, Converter.Settings);
    }
}
