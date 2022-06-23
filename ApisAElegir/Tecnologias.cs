// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
using System.Text.Json.Serialization;

public class CostTechnology
{
    [JsonPropertyName("Wood")]
    public int Wood { get; set; }

    [JsonPropertyName("Food")]
    public int Food { get; set; }

    [JsonPropertyName("Stone")]
    public int Stone { get; set; }

    [JsonPropertyName("Gold")]
    public int Gold { get; set; }
}

public class Technology
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("description")]
    public string Description { get; set; }

    [JsonPropertyName("expansion")]
    public string Expansion { get; set; }

    [JsonPropertyName("age")]
    public string Age { get; set; }

    [JsonPropertyName("develops_in")]
    public string DevelopsIn { get; set; }

    [JsonPropertyName("cost")]
    public CostTechnology CostTecnologia { get; set; }

    [JsonPropertyName("build_time")]
    public int BuildTime { get; set; }

    [JsonPropertyName("applies_to")]
    public List<string> AppliesTo { get; set; }
}

public class RootTechnology
{
    [JsonPropertyName("technologies")]
    public List<Technology> Technologies { get; set; }
}