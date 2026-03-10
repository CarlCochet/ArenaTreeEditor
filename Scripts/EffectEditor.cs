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
    public event EventHandler<(int index, double value)> ParamChanged;
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
        _params.ValueChanged += _OnParamChanged;
        _params.DeletePressed += _OnParamDeleted;
        _triggersBefore.AddPressed += _OnAddTriggerBeforePressed;
        _triggersBefore.TriggerDataChanged += _OnTriggerBeforeChanged;
        _triggersBefore.DeletePressed += _OnTriggerBeforeDeleted;
        _triggersAfter.AddPressed += _OnAddTriggerAfterPressed;
        _triggersAfter.TriggerDataChanged += _OnTriggerAfterChanged;
        _triggersAfter.DeletePressed += _OnTriggerAfterDeleted;
        _endTriggers.AddPressed += _OnAddEndTriggerPressed;
        _endTriggers.TriggerDataChanged += _OnEndTriggerChanged;
        _endTriggers.DeletePressed += _OnEndTriggerDeleted;
        _serverTriggers.AddPressed += _OnAddServerTriggerPressed;
        _serverTriggers.TriggerDataChanged += _OnServerTriggerChanged;
        _serverTriggers.DeletePressed += _OnServerTriggerDeleted;
        _areaSizeMin.ValueChanged += _OnAreaSizeMinChanged;
        _areaSizeMax.ValueChanged += _OnAreaSizeMaxChanged;
        _duration.ValueChanged += _OnDurationChanged;
        _targets.AddPressed += _OnAddTargetPressed;
        _targets.TargetDataChanged += _OnTargetChanged;
        _targets.DeletePressed += _OnTargetDeleted;
        _triggeredWithDuration.Toggled += _OnTriggeredWithDurationChanged;

        foreach (var value in Enum.GetValues<Enums.ActionType>())
        {
            _action.AddItem(value.ToString(), (int)value);
        }
        
        foreach (var value in Enum.GetValues<Enums.AreaShape>())
        {
            _areaShape.AddItem(value.ToString(), (int)value);
        }
    }

    public void SetData(EffectData effectData)
    {
        _action.Select(_action.GetItemIndex(effectData.ActionId));
        _areaShape.Select(_areaShape.GetItemIndex((int)effectData.AreaShape));
        _triggerSelf.SetPressed(effectData.TargetTriggerSelf);
        _areaSizeMin.Value = effectData.AreaSize.Count > 0 ? effectData.AreaSize[0] : 0;
        _areaSizeMax.Value = effectData.AreaSize.Count > 1 ? effectData.AreaSize[1] : 0;
        _duration.Value = effectData.Duration.Count > 0 ? effectData.Duration[0] : 0;
        _triggeredWithDuration.SetPressed(effectData.TriggeredWithDuration);

        _params.SetValue(effectData.Params);
        _triggersBefore.SetTriggerData(effectData.TriggersBefore);
        _triggersAfter.SetTriggerData(effectData.TriggersAfter);
        _endTriggers.SetTriggerData(effectData.EndTriggers);
        _serverTriggers.SetTriggerData(effectData.ServerSideTriggers);
        _targets.SetTargetData(effectData.Targets);
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
        TargetChanged?.Invoke(this, args);
    }

    private void _OnTargetDeleted(object sender, int index)
    {
        TargetDeleted?.Invoke(this, index);
    }
    
    private void _OnParamChanged(object sender, (int index, double value) args)
    {
        ParamChanged?.Invoke(this, args);
    }
    
    private void _OnParamDeleted(object sender, int index)
    {
        ParamDeleted?.Invoke(this, index);
    }
    
    private void _OnTriggerBeforeChanged(object sender, (int index, Enums.TriggerType triggerType) args)
    {
        TriggerBeforeChanged?.Invoke(this, args);
    }
    
    private void _OnTriggerBeforeDeleted(object sender, int index)
    {
        TriggerBeforeDeleted?.Invoke(this, index);
    }
    
    private void _OnTriggerAfterChanged(object sender, (int index, Enums.TriggerType triggerType) args)
    {
        TriggerAfterChanged?.Invoke(this, args);
    }
    
    private void _OnTriggerAfterDeleted(object sender, int index)
    {
        TriggerAfterDeleted?.Invoke(this, index);
    }
    
    private void _OnEndTriggerChanged(object sender, (int index, Enums.TriggerType triggerType) args)
    {
        EndTriggerChanged?.Invoke(this, args);
    }
    
    private void _OnEndTriggerDeleted(object sender, int index)
    {
        EndTriggerDeleted?.Invoke(this, index);
    }
    
    private void _OnServerTriggerChanged(object sender, (int index, Enums.TriggerType triggerType) args)
    {
        ServerTriggerChanged?.Invoke(this, args);
    }
    
    private void _OnServerTriggerDeleted(object sender, int index)
    {
        ServerTriggerDeleted?.Invoke(this, index);
    }
}
