using Godot;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

public class SphereBoardData
{
    [JsonPropertyName("id")] public int Id { get; set; }
    [JsonPropertyName("seasonId")] public int SeasonId { get; set; }
    [JsonPropertyName("breedId")] public int BreedId { get; set; }
    [JsonPropertyName("fighterCardListId")] public int FighterCardListId { get; set; }
    [JsonPropertyName("initialSpellIds")] public List<int> InitialSpellIds { get; set; }
    [JsonPropertyName("startId")] public int StartId { get; set; }

    public SphereBoardData()
    {
        SeasonId = 1;
        BreedId = 1;
        InitialSpellIds = [ 31, 36, 34 ];
        StartId = 1;
    }
}
