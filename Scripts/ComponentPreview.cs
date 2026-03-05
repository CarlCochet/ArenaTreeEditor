using Godot;
using System;
using System.Linq;

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
        foreach (var entry in GlobalData.Instance.SpellData.OrderBy(kvp => kvp.Key))
        {
            _optionButtonPreview.AddItem(entry.Value.Name, entry.Value.Id);
        }
        
        var indexToSelect = _optionButtonPreview.GetItemIndex(spellData.Id);
        if (indexToSelect >= 0)
            _optionButtonPreview.Select(indexToSelect);
        
        _optionButtonPreview.ItemSelected += selectedIndex =>
        {
            var selectedId = _optionButtonPreview.GetItemId((int)selectedIndex);
            if (GlobalData.Instance.SpellData.TryGetValue(selectedId, out var selectedSpell))
                SpellDataChanged?.Invoke(this, (Index, selectedSpell));
        };
        AddChild(_optionButtonPreview);
    }
    
    public void SetLinkData(SphereData sphereData)
    {
        _buttonPreview = new Button();
        _buttonPreview.Text = sphereData.Id.ToString();
        _buttonPreview.Pressed += () => PreviewPressed?.Invoke(this, Index);
        AddChild(_buttonPreview);
    }

    public void SetEffectData(EffectData effectData)
    {
        _buttonPreview = new Button();
        _buttonPreview.Text = ((Enums.ActionType)effectData.ActionId).ToString();
        _buttonPreview.Pressed += () => PreviewPressed?.Invoke(this, Index);
        AddChild(_buttonPreview);
    }

    public void SetFighterCardData(FighterCardData fighterCardData)
    {
        _optionButtonPreview = new OptionButton();
        foreach (var entry in GlobalData.Instance.FighterCardsData.OrderBy(kvp => kvp.Key))
        {
            _optionButtonPreview.AddItem(entry.Value.Name, entry.Value.Id);
        }
        
        var indexToSelect = _optionButtonPreview.GetItemIndex(fighterCardData.Id);
        if (indexToSelect >= 0)
            _optionButtonPreview.Select(indexToSelect);
        
        _optionButtonPreview.ItemSelected += selectedIndex =>
        {
            var selectedId = _optionButtonPreview.GetItemId((int)selectedIndex);
            if (GlobalData.Instance.FighterCardsData.TryGetValue(selectedId, out var selectedCard))
                FighterCardDataChanged?.Invoke(this, (Index, selectedCard));
        };
        AddChild(_optionButtonPreview);
    }

    public void SetTriggerData(Enums.TriggerType triggerType)
    {
        _optionButtonPreview = new OptionButton();
        foreach (var value in Enum.GetValues<Enums.TargetType>())
        {
            _optionButtonPreview.AddItem(value.ToString(), (int)value);
        }
        
        var indexToSelect = _optionButtonPreview.GetItemIndex((int)triggerType);
        if (indexToSelect >= 0)
            _optionButtonPreview.Select(indexToSelect);
        
        _optionButtonPreview.ItemSelected += selectedIndex => 
        {
            var enumValue = _optionButtonPreview.GetItemId((int)selectedIndex);
            TriggerDataChanged?.Invoke(this, (Index, (Enums.TriggerType)enumValue));
        };
        AddChild(_optionButtonPreview);
    }

    public void SetTargetData(Enums.TargetType targetType)
    {
        _optionButtonPreview = new OptionButton();
        foreach (var value in Enum.GetValues<Enums.TargetType>())
        {
            _optionButtonPreview.AddItem(value.ToString(), (int)value);
        }
        
        var indexToSelect = _optionButtonPreview.GetItemIndex((int)targetType);
        if (indexToSelect >= 0)
            _optionButtonPreview.Select(indexToSelect);
        
        _optionButtonPreview.ItemSelected += selectedIndex => 
        {
            var enumValue = _optionButtonPreview.GetItemId((int)selectedIndex);
            TargetDataChanged?.Invoke(this, (Index, (Enums.TargetType)enumValue));
        };
        AddChild(_optionButtonPreview);
    }

    public void SetValue(double value)
    {
        _spinBoxPreview = new SpinBox();
        _spinBoxPreview.Value = value;
        _spinBoxPreview.ValueChanged += newValue => ValueChanged?.Invoke(this, (Index, (int)newValue));
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
