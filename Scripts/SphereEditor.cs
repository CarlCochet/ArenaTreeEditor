using Godot;
using System;

public partial class SphereEditor : ScrollContainer
{
    [Export] private SpinBox _sphereId;
    [Export] private SpinBox _xpNumber;
    [Export] private SpinBox _x;
    [Export] private SpinBox _y;
    [Export] private VBoxContainer _links;
    [Export] private VBoxContainer _effects;
    [Export] private Button _addEffect;
    
    public override void _Ready()
    {
        _sphereId.Changed += _OnSphereIdChanged;
        _xpNumber.Changed += _OnXpNumberChanged;
        _x.Changed += _OnXChanged;
        _y.Changed += _OnYChanged;
        _addEffect.Pressed += _OnAddEffectPressed;
    }
    
    private void _OnSphereIdChanged()
    {
        
    }
    
    private void _OnXpNumberChanged()
    {
        
    }
    
    private void _OnXChanged()
    {
        
    }
    
    private void _OnYChanged()
    {
        
    }
    
    private void _OnAddEffectPressed()
    {
        
    }
}
