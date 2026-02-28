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
    public event EventHandler<SpellData> SpellDataChanged;
    public event EventHandler<FighterCardData> FighterCardDataChanged;
    public event EventHandler<Enums.TriggerType> TriggerDataChanged;
    public event EventHandler<Enums.TargetType> TargetDataChanged;
    public event EventHandler<int> ValueChanged;

    public override void _Ready()
    {
        _delete.Pressed += _OnDeletePressed;
    }

    public void SetSpellData(SpellData spellData)
    {
        _optionButtonPreview = new OptionButton();
        _optionButtonPreview.ItemSelected += newSpellData
            => SpellDataChanged?.Invoke(this, GlobalData.Instance.SpellData[(int)newSpellData]);
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
            => FighterCardDataChanged?.Invoke(this, GlobalData.Instance.FighterCardsData[(int)newFighterCardData]);
        AddChild(_optionButtonPreview);
    }

    public void SetTriggerData(Enums.TriggerType triggerType)
    {
        _optionButtonPreview = new OptionButton();
        _optionButtonPreview.ItemSelected += newTriggerType
            => TriggerDataChanged?.Invoke(this, (Enums.TriggerType)newTriggerType);
        AddChild(_optionButtonPreview);
    }

    public void SetTargetData(Enums.TargetType targetType)
    {
        _optionButtonPreview = new OptionButton();
        _optionButtonPreview.ItemSelected += newTargetType
            => TargetDataChanged?.Invoke(this, (Enums.TargetType)newTargetType);
        AddChild(_optionButtonPreview);
    }

    public void SetValue(int value)
    {
        _spinBoxPreview = new SpinBox();
        _spinBoxPreview.Value = value;
        _spinBoxPreview.ValueChanged += newValue
            => ValueChanged?.Invoke(this, (int)newValue);
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
        ValueChanged?.Invoke(this, (int)_spinBoxPreview.Value);
    }
}
