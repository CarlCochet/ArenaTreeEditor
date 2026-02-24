using Godot;
using System;

public partial class SphereEditor : ScrollContainer
{
    [Export] private SpinBox _xpNumber;
    [Export] private OptionButton _type;
    [Export] private SpinBox _x;
    [Export] private SpinBox _y;
    [Export] private VBoxContainer _spells;
    [Export] private Button _addSpell;
    [Export] private VBoxContainer _fighterCards;
    [Export] private Button _addFighterCard;
    [Export] private VBoxContainer _links;
    [Export] private VBoxContainer _effects;
    [Export] private Button _addEffect;
    
    public override void _Ready()
    {
        _xpNumber.Changed += _OnXpNumberChanged;
        _type.ItemSelected += _OnTypeSelected;
        _x.Changed += _OnXChanged;
        _y.Changed += _OnYChanged;
        _addSpell.Pressed += _OnAddSpellPressed;
        _addFighterCard.Pressed += _OnAddFighterCardPressed;
        _addEffect.Pressed += _OnAddEffectPressed;
    }
    
    private void _OnXpNumberChanged()
    {
        
    }
    
    private void _OnTypeSelected(long index)
    {
        
    }
    
    private void _OnXChanged()
    {
        
    }
    
    private void _OnYChanged()
    {
        
    }
    
    private void _OnAddSpellPressed()
    {
        
    }
    
    private void _OnAddFighterCardPressed()
    {
        
    }
    
    private void _OnAddEffectPressed()
    {
        
    }
}
