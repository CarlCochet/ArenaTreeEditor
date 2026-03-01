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
        var targetPreview = _componentPreviewScene.Instantiate<ComponentPreview>();
        targetPreview.SetTargetData(Enums.TargetType.Always);
        targetPreview.Index = _targets.GetChildCount() - 1;
        targetPreview.TargetDataChanged += _OnTargetChanged;
        targetPreview.DeletePressed += _OnTargetDeleted;
        _targets.AddChild(targetPreview);
        TargetAdded?.Invoke(this, EventArgs.Empty);
    }
    
    private void _OnAddParamPressed()
    {
        var paramPreview = _componentPreviewScene.Instantiate<ComponentPreview>();
        paramPreview.SetValue(0);
        paramPreview.Index = _params.GetChildCount() - 1;
        paramPreview.ValueChanged += _OnParamChanged;
        paramPreview.DeletePressed += _OnParamDeleted;
        _params.AddChild(paramPreview);
        ParamAdded?.Invoke(this, EventArgs.Empty);
    }
    
    private void _OnAddTriggerBeforePressed()
    {
        var triggerPreview = _componentPreviewScene.Instantiate<ComponentPreview>();
        triggerPreview.SetTriggerData(Enums.TriggerType.None);
        triggerPreview.Index = _triggersBefore.GetChildCount() - 1;
        triggerPreview.TriggerDataChanged += _OnTriggerBeforeChanged;
        triggerPreview.DeletePressed += _OnTriggerBeforeDeleted;
        _triggersBefore.AddChild(triggerPreview);
        TriggerBeforeAdded?.Invoke(this, EventArgs.Empty);
    }
    
    private void _OnAddTriggerAfterPressed()
    {
        var triggerPreview = _componentPreviewScene.Instantiate<ComponentPreview>();
        triggerPreview.SetTriggerData(Enums.TriggerType.None);
        triggerPreview.Index = _triggersAfter.GetChildCount() - 1;
        triggerPreview.TriggerDataChanged += _OnTriggerAfterChanged;
        triggerPreview.DeletePressed += _OnTriggerAfterDeleted;
        _triggersAfter.AddChild(triggerPreview);
        TriggerAfterAdded?.Invoke(this, EventArgs.Empty);  
    }
    
    private void _OnAddEndTriggerPressed()
    {
        var triggerPreview = _componentPreviewScene.Instantiate<ComponentPreview>();
        triggerPreview.SetTriggerData(Enums.TriggerType.None);
        triggerPreview.Index = _endTriggers.GetChildCount() - 1;
        triggerPreview.TriggerDataChanged += _OnEndTriggerChanged;
        triggerPreview.DeletePressed += _OnEndTriggerDeleted;
        _endTriggers.AddChild(triggerPreview);
        EndTriggerAdded?.Invoke(this, EventArgs.Empty);
    }
    
    private void _OnAddServerTriggerPressed()
    {
        var triggerPreview = _componentPreviewScene.Instantiate<ComponentPreview>();
        triggerPreview.SetTriggerData(Enums.TriggerType.None);
        triggerPreview.Index = _serverTriggers.GetChildCount() - 1;
        triggerPreview.TriggerDataChanged += _OnServerTriggerChanged;
        triggerPreview.DeletePressed += _OnServerTriggerDeleted;
        _serverTriggers.AddChild(triggerPreview);
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
