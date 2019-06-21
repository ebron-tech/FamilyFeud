﻿// Generated by https://quicktype.io
//
// To change quicktype's target language, run command:
//
//   "Set quicktype target language"

namespace QuickType
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class Round
    {
        [JsonProperty("rounds")]
        public RoundElement[] Rounds { get; set; }
    }

    public partial class RoundElement
    {
        [JsonProperty("multi")]
        public long Multi { get; set; }

        [JsonProperty("question")]
        public string Question { get; set; }

        [JsonProperty("resp")]
        public Resp[] Resp { get; set; }
    }

    public partial class Resp
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("points")]
        public long Points { get; set; }
    }

    public partial class Round
    {
        public static Round FromJson(string json) => JsonConvert.DeserializeObject<Round>(json, QuickType.Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this Round self) => JsonConvert.SerializeObject(self, QuickType.Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters = {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}
