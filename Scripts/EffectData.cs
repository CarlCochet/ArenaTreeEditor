using Godot;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

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
    [JsonPropertyName("triggersBefore")] public List<Enums.TriggerType> TriggersBefore { get; set; } = [];
    [JsonPropertyName("triggersAfter")] public List<Enums.TriggerType> TriggersAfter { get; set; } = [];
    [JsonPropertyName("endTriggers")] public List<Enums.TriggerType> EndTriggers { get; set; } = [];
    [JsonPropertyName("serverSideTriggers")] public List<Enums.TriggerType> ServerSideTriggers { get; set; } = [];
    [JsonPropertyName("areaSize")] public List<int> AreaSize { get; set; } = [];
    [JsonPropertyName("duration")] public List<int> Duration { get; set; } = [];
    [JsonPropertyName("targets")] public List<Enums.TargetType> Targets { get; set; } = [];
    [JsonPropertyName("triggeredWithDuration")] public bool TriggeredWithDuration { get; set; }
    [JsonPropertyName("appliedIfTargetValid")] public bool AppliedIfTargetValid { get; set; }
}
