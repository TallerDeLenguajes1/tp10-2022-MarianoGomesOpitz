using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

public class Root
    {
        [JsonPropertyName("civilizations")]
        public List<Civilization> Civilization { get; set; }
    }