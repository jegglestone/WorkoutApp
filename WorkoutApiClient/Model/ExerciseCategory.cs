using Newtonsoft.Json;
using System.Collections.Generic;
using WorkoutApiClient.Serialization;

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
        public List<CategoryResult> Results { get; set; }
    }

    public class CategoryResult
    {
        [JsonProperty("id")]
        public long CategoryId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public partial class ExerciseCategory
    {
        public static ExerciseCategory FromJson(string json) => JsonConvert.DeserializeObject<ExerciseCategory>(json, Converter.Settings);
    }
}
