using Godot;
using System;

public partial class ComponentPreview : HBoxContainer
{
    [Export] private Button _delete;
    private SpinBox _spinBoxPreview;
    private OptionButton _optionButtonPreview;
    private Button _buttonPreview;
    
    public int Index { get; set; }
    
    public event EventHandler<int> PreviewPressed;
    public event EventHandler<int> DeletePressed;
    public event EventHandler<(int index, SpellData spell)> SpellDataChanged;
    public event EventHandler<(int index, FighterCardData fighterCard)> FighterCardDataChanged;
    public event EventHandler<(int index, Enums.TriggerType trigger)> TriggerDataChanged;
    public event EventHandler<(int index, Enums.TargetType target)> TargetDataChanged;
    public event EventHandler<(int index, double value)> ValueChanged;

    public override void _Ready()
    {
        _delete.Pressed += _OnDeletePressed;
    }

    public void SetSpellData(SpellData spellData)
    {
        _optionButtonPreview = new OptionButton();
        _optionButtonPreview.ItemSelected += newSpellData
            => SpellDataChanged?.Invoke(this, (Index, GlobalData.Instance.SpellData[(int)newSpellData]));
        AddChild(_optionButtonPreview);
    }
    
    public void SetLinkData(SphereData sphereData)
    {
        _buttonPreview = new Button();
        _buttonPreview.Pressed += () 
            => PreviewPressed?.Invoke(this, Index);
        AddChild(_buttonPreview);
    }

    public void SetEffectData(EffectData effectData)
    {
        _buttonPreview = new Button();
        _buttonPreview.Pressed += () 
            => PreviewPressed?.Invoke(this, Index);
        AddChild(_buttonPreview);
    }

    public void SetFighterCardData(FighterCardData fighterCardData)
    {
        _optionButtonPreview = new OptionButton();
        _optionButtonPreview.ItemSelected += newFighterCardData
            => FighterCardDataChanged?.Invoke(this, (Index, GlobalData.Instance.FighterCardsData[(int)newFighterCardData]));
        AddChild(_optionButtonPreview);
    }

    public void SetTriggerData(Enums.TriggerType triggerType)
    {
        _optionButtonPreview = new OptionButton();
        _optionButtonPreview.ItemSelected += newTriggerType
            => TriggerDataChanged?.Invoke(this, (Index, (Enums.TriggerType)newTriggerType));
        AddChild(_optionButtonPreview);
    }

    public void SetTargetData(Enums.TargetType targetType)
    {
        _optionButtonPreview = new OptionButton();
        _optionButtonPreview.ItemSelected += newTargetType
            => TargetDataChanged?.Invoke(this, (Index, (Enums.TargetType)newTargetType));
        AddChild(_optionButtonPreview);
    }

    public void SetValue(double value)
    {
        _spinBoxPreview = new SpinBox();
        _spinBoxPreview.Value = value;
        _spinBoxPreview.ValueChanged += newValue
            => ValueChanged?.Invoke(this, (Index, (int)newValue));
        AddChild(_spinBoxPreview);
    }
    
    private void _OnPreviewPressed()
    {
        PreviewPressed?.Invoke(this, Index);
    }

    private void _OnDeletePressed()
    {
        DeletePressed?.Invoke(this, Index);
    }
    
    private void _OnValueChanged()
    {
        ValueChanged?.Invoke(this, (Index, (int)_spinBoxPreview.Value));
    }
}
