using Godot;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

public class SphereData
{
    [JsonPropertyName("id")] public int Id { get; set; }
    [JsonPropertyName("sphereBoardId")] public int SphereBoardId { get; set; }
    [JsonPropertyName("xpNumber")] public int XpNumber { get; set; }
    [JsonPropertyName("spellId")] public int SpellId { get; set; }
    [JsonPropertyName("effects")] public List<EffectData> Effects { get; set; } = [];
    [JsonPropertyName("fighterCardListId")] public int FighterCardListId { get; set; }
    [JsonPropertyName("yposition")] public int YPosition { get; set; }
    [JsonPropertyName("xposition")] public int XPosition { get; set; }
    [JsonPropertyName("type")] public int Type { get; set; }
    [JsonPropertyName("linkedSpheres")] public List<int> LinkedSpheres { get; set; } = [];
}
