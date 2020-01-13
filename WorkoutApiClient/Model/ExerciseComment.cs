﻿using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace WorkoutApiClient.Model
{
    public partial class ExerciseComments
    {
        [JsonProperty("count")]
        public long Count { get; set; }

        [JsonProperty("next")]
        public Uri Next { get; set; }

        [JsonProperty("previous")]
        public object Previous { get; set; }

        [JsonProperty("results")]
        public List<ExerciseComment> Results { get; set; }
    }

    public partial class ExerciseComment
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("comment")]
        public string Comment { get; set; }

        [JsonProperty("exercise")]
        public long Exercise { get; set; }
    }

    public partial class ExerciseComments
    {
        public static ExerciseComments FromJson(string json) => JsonConvert.DeserializeObject<ExerciseComments>(json, Model.Converter.Settings);
    }
}
