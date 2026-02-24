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
    [Export] private PackedScene _componentPreviewScene;
    
    public override void _Ready()
    {
        _actionId.ValueChanged += _OnActionIdChanged;
        
    }

    public void SetData(SphereData sphereData)
    {
        
    }
    
    private void _OnActionIdChanged(double value)
    {
        
    }
    
    private void _OnAreaShapeChanged(double value)
    {
        
    }
    
    private void _OnTriggerSelfChanged(bool value)
    {
        
    }
    
    private void _OnAddTargetPressed()
    {
        
    }
    
    private void _OnAddParamPressed()
    {
        
    }
    
    private void _OnAddTriggerBeforePressed()
    {
        
    }
    
    private void _OnAddTriggerAfterPressed()
    {
        
    }
    
    private void _OnAddEndTriggerPressed()
    {
        
    }
    
    private void _OnAddServerTriggerPressed()
    {
        
    }
    
    private void _OnTriggeredWithDurationChanged(bool value)
    {
        
    }
    
    private void _OnAreaSizeMinChanged(double value)
    {
        
    }
    
    private void _OnAreaSizeMaxChanged(double value)
    {
        
    }
    
    private void _OnDurationChanged(double value)
    {
        
    }
    
    private void _OnTargetChanged(int value)
    {
        
    }
    
    private void _OnParamChanged(double value)
    {
        
    }
    
    private void _OnTriggerBeforeChanged(int value)
    {
        
    }
    
    private void _OnTriggerAfterChanged(int value)
    {
        
    }
    
    private void _OnEndTriggerChanged(int value)
    {
        
    }
    
    private void _OnServerTriggerChanged(int value)
    {
        
    }
}
