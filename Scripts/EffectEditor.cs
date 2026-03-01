using Godot;
using System;

public partial class EffectEditor : Control
{
    [Export] private OptionButton _action;
    [Export] private OptionButton _areaShape;
    [Export] private CheckBox _triggerSelf;
    [Export] private ComponentPreviewList _params;
    [Export] private ComponentPreviewList _triggersBefore;
    [Export] private ComponentPreviewList _triggersAfter;
    [Export] private ComponentPreviewList _endTriggers;
    [Export] private ComponentPreviewList _serverTriggers;
    [Export] private SpinBox _areaSizeMin;
    [Export] private SpinBox _areaSizeMax;
    [Export] private SpinBox _duration;
    [Export] private ComponentPreviewList _targets;
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
    public event EventHandler<(int index, int value)> ParamChanged;
    public event EventHandler<(int index, Enums.TargetType target)> TargetChanged;
    public event EventHandler<(int index, Enums.TriggerType trigger)> TriggerBeforeChanged;
    public event EventHandler<(int index, Enums.TriggerType trigger)> TriggerAfterChanged;
    public event EventHandler<(int index, Enums.TriggerType trigger)> EndTriggerChanged;
    public event EventHandler<(int index, Enums.TriggerType trigger)> ServerTriggerChanged;
    public event EventHandler<int> ParamDeleted;
    public event EventHandler<int> TargetDeleted;
    public event EventHandler<int> TriggerBeforeDeleted;
    public event EventHandler<int> TriggerAfterDeleted;
    public event EventHandler<int> EndTriggerDeleted;
    public event EventHandler<int> ServerTriggerDeleted;
    public event EventHandler<int> AreaSizeMinChanged;
    public event EventHandler<int> AreaSizeMaxChanged;
    public event EventHandler<int> DurationChanged;
    public event EventHandler TargetAdded;
    public event EventHandler<bool> TriggeredWithDurationChanged;
    
    public override void _Ready()
    {
        _params.SetTitle("Parameters");
        _triggersBefore.SetTitle("Triggers Before");
        _triggersAfter.SetTitle("Triggers After");
        _endTriggers.SetTitle("End Triggers");
        _serverTriggers.SetTitle("Server Triggers");
        _targets.SetTitle("Targets");
        
        _action.ItemSelected += _OnActionSelected;
        _areaShape.ItemSelected += _OnAreaShapeSelected;
        _triggerSelf.Toggled += _OnTriggerSelfToggled;
        _params.AddPressed += _OnAddParamPressed;
        _triggersBefore.AddPressed += _OnAddTriggerBeforePressed;
        _triggersAfter.AddPressed += _OnAddTriggerAfterPressed;
        _endTriggers.AddPressed += _OnAddEndTriggerPressed;
        _serverTriggers.AddPressed += _OnAddServerTriggerPressed;
        _areaSizeMin.ValueChanged += _OnAreaSizeMinChanged;
        _areaSizeMax.ValueChanged += _OnAreaSizeMaxChanged;
        _duration.ValueChanged += _OnDurationChanged;
        _targets.AddPressed += _OnAddTargetPressed;
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

        _params.SetValue(effectData.Params);
        _triggersBefore.SetTriggerData(effectData.TriggersBefore);
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
    
    private void _OnAddTargetPressed(object sender, EventArgs eventArgs)
    {
        TargetAdded?.Invoke(this, EventArgs.Empty);
    }
    
    private void _OnAddParamPressed(object sender, EventArgs eventArgs)
    {
        ParamAdded?.Invoke(this, EventArgs.Empty);
    }
    
    private void _OnAddTriggerBeforePressed(object sender, EventArgs eventArgs)
    {
        TriggerBeforeAdded?.Invoke(this, EventArgs.Empty);
    }
    
    private void _OnAddTriggerAfterPressed(object sender, EventArgs eventArgs)
    {
        TriggerAfterAdded?.Invoke(this, EventArgs.Empty);  
    }
    
    private void _OnAddEndTriggerPressed(object sender, EventArgs eventArgs)
    {
        EndTriggerAdded?.Invoke(this, EventArgs.Empty);
    }
    
    private void _OnAddServerTriggerPressed(object sender, EventArgs eventArgs)
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

    private void _OnTargetChanged(object sender, (int index, Enums.TargetType targetType) args)
    {
        
    }

    private void _OnTargetDeleted(object sender, int index)
    {
        
    }
    
    private void _OnParamChanged(object sender, (int index, int value) args)
    {
        
    }
    
    private void _OnParamDeleted(object sender, int index)
    {
        
    }
    
    private void _OnTriggerBeforeChanged(object sender, (int index, Enums.TriggerType triggerType) args)
    {
        
    }
    
    private void _OnTriggerBeforeDeleted(object sender, int index)
    {
        
    }
    
    private void _OnTriggerAfterChanged(object sender, (int index, Enums.TriggerType triggerType) args)
    {
        
    }
    
    private void _OnTriggerAfterDeleted(object sender, int index)
    {
        
    }
    
    private void _OnEndTriggerChanged(object sender, (int index, Enums.TriggerType triggerType) args)
    {
        
    }
    
    private void _OnEndTriggerDeleted(object sender, int index)
    {
        
    }
    
    private void _OnServerTriggerChanged(object sender, (int index, Enums.TriggerType triggerType) args)
    {
        
    }
    
    private void _OnServerTriggerDeleted(object sender, int index)
    {
        
    }
}
