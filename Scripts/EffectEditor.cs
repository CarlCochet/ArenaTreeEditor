using Godot;
using System;

public partial class EffectEditor : Control
{
    [Export] private OptionButton _action;
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
    
    public event EventHandler<int> ActionSelected;
    public event EventHandler<int> AreaShapeSelected;
    public event EventHandler<bool> TriggerSelfToggled;
    public event EventHandler ParamAdded;
    public event EventHandler TriggerBeforeAdded;
    public event EventHandler TriggerAfterAdded;
    public event EventHandler EndTriggerAdded;
    public event EventHandler ServerTriggerAdded;
    public event EventHandler<int> AreaSizeMinChanged;
    public event EventHandler<int> AreaSizeMaxChanged;
    public event EventHandler<int> DurationChanged;
    public event EventHandler TargetAdded;
    public event EventHandler<bool> TriggeredWithDurationChanged;
    
    public override void _Ready()
    {
        _action.ItemSelected += _OnActionSelected;
        _areaShape.ItemSelected += _OnAreaShapeSelected;
        _triggerSelf.Toggled += _OnTriggerSelfToggled;
        _addParam.Pressed += _OnAddParamPressed;
        _addTriggerBefore.Pressed += _OnAddTriggerBeforePressed;
        _addTriggerAfter.Pressed += _OnAddTriggerAfterPressed;
        _addEndTrigger.Pressed += _OnAddEndTriggerPressed;
        _addServerTrigger.Pressed += _OnAddServerTriggerPressed;
        _areaSizeMin.ValueChanged += _OnAreaSizeMinChanged;
        _areaSizeMax.ValueChanged += _OnAreaSizeMaxChanged;
        _duration.ValueChanged += _OnDurationChanged;
        _addTarget.Pressed += _OnAddTargetPressed;
        _triggeredWithDuration.Toggled += _OnTriggeredWithDurationChanged;
    }

    public void SetData(EffectData effectData)
    {
        _action.Select(_action.GetItemIndex(effectData.ActionId));
        _areaShape.Select(_areaShape.GetItemIndex(effectData.AreaShape));
        _triggerSelf.SetPressed(effectData.TargetTriggerSelf);
        _areaSizeMin.Value = effectData.AreaSize.Count > 0 ? effectData.AreaSize[0] : 0;
        _areaSizeMax.Value = effectData.AreaSize.Count > 1 ? effectData.AreaSize[1] : 0;
        _duration.Value = effectData.Duration.Count > 0 ? effectData.Duration[0] : 0;
        _triggeredWithDuration.SetPressed(effectData.TriggeredWithDuration);

        foreach (var param in effectData.Params)
        {
            var componentPreview = _componentPreviewScene.Instantiate<ComponentPreview>();
            
        }
    }
    
    private void _OnActionSelected(long id)
    {
        ActionSelected?.Invoke(this, (int)id);
    }
    
    private void _OnAreaShapeSelected(long id)
    {
        AreaShapeSelected?.Invoke(this, (int)id);   
    }
    
    private void _OnTriggerSelfToggled(bool value)
    {
        TriggerSelfToggled?.Invoke(this, value);  
    }
    
    private void _OnAddTargetPressed()
    {
        TargetAdded?.Invoke(this, EventArgs.Empty);
    }
    
    private void _OnAddParamPressed()
    {
        ParamAdded?.Invoke(this, EventArgs.Empty);
    }
    
    private void _OnAddTriggerBeforePressed()
    {
        TriggerBeforeAdded?.Invoke(this, EventArgs.Empty);
    }
    
    private void _OnAddTriggerAfterPressed()
    {
        TriggerAfterAdded?.Invoke(this, EventArgs.Empty);  
    }
    
    private void _OnAddEndTriggerPressed()
    {
        EndTriggerAdded?.Invoke(this, EventArgs.Empty);
    }
    
    private void _OnAddServerTriggerPressed()
    {
        ServerTriggerAdded?.Invoke(this, EventArgs.Empty);
    }
    
    private void _OnTriggeredWithDurationChanged(bool value)
    {
        TriggeredWithDurationChanged?.Invoke(this, value); 
    }
    
    private void _OnAreaSizeMinChanged(double value)
    {
        AreaSizeMinChanged?.Invoke(this, (int)value);
    }
    
    private void _OnAreaSizeMaxChanged(double value)
    {
        AreaSizeMaxChanged?.Invoke(this, (int)value);
    }
    
    private void _OnDurationChanged(double value)
    {
        DurationChanged?.Invoke(this, (int)value);
    }
}
