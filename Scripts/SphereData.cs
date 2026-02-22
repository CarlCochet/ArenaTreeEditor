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
    [JsonPropertyName("linkedSpheres")] public List<int> LinkedSpheres { get; set; } = [];

    public class EffectData
    {
        [JsonPropertyName("id")] public int Id { get; set; }
        [JsonPropertyName("actionId")] public int ActionId { get; set; }
        [JsonPropertyName("parentId")] public int ParentId { get; set; }
        [JsonPropertyName("parentType")] public string ParentType { get; set; } = string.Empty;
        [JsonPropertyName("areaShape")] public int AreaShape { get; set; }
        [JsonPropertyName("areaOrderingMethod")] public int AreaOrderingMethod { get; set; }
        [JsonPropertyName("affectedByLocalisation")] public bool AffectedByLocalisation { get; set; }
        [JsonPropertyName("targetTriggerSelf")] public bool TargetTriggerSelf { get; set; }
        [JsonPropertyName("personal")] public bool Personal { get; set; }
        [JsonPropertyName("singleTarget")] public bool SingleTarget { get; set; }
        [JsonPropertyName("critical")] public bool Critical { get; set; }
        [JsonPropertyName("params")] public List<double> Params { get; set; } = [];
        [JsonPropertyName("triggersBefore")] public List<int> TriggersBefore { get; set; } = [];
        [JsonPropertyName("triggersAfter")] public List<int> TriggersAfter { get; set; } = [];
        [JsonPropertyName("endTriggers")] public List<int> EndTriggers { get; set; } = [];
        [JsonPropertyName("serverSideTriggers")] public List<int> ServerSideTriggers { get; set; } = [];
        [JsonPropertyName("areaSize")] public List<int> AreaSize { get; set; } = [];
        [JsonPropertyName("duration")] public List<int> Duration { get; set; } = [];
        [JsonPropertyName("targets")] public List<int> Targets { get; set; } = [];
        [JsonPropertyName("triggeredWithDuration")] public bool TriggeredWithDuration { get; set; }
        [JsonPropertyName("appliedIfTargetValid")] public bool AppliedIfTargetValid { get; set; }
    }
}
