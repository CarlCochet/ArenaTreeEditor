using Godot;
using System;

public partial class EffectEditor : Control
{
    [Export] private SpinBox _actionId;
    [Export] private OptionButton _areaShape;
    [Export] private CheckBox _triggerSelf;
    [Export] private Button _addParam;
    [Export] private VBoxContainer _params;
    [Export] private Button _addTriggerBefore;
    [Export] private VBoxContainer _triggersBefore;
    [Export] private Button _addTriggerAfter;
    [Export] private VBoxContainer _triggersAfter;
    [Export] private Button _addEndTrigger;
    [Export] private VBoxContainer _endTriggers;
    [Export] private Button _addServerTrigger;
    [Export] private VBoxContainer _serverTriggers;
    [Export] private SpinBox _areaSizeMin;
    [Export] private SpinBox _areaSizeMax;
    [Export] private SpinBox _duration;
    [Export] private VBoxContainer _targets;
    [Export] private Button _addTarget;
    [Export] private CheckBox _triggeredWithDuration;
    
    public override void _Ready()
    {
        
    }

    public void Load(SphereData sphereData)
    {
        
    }
}
