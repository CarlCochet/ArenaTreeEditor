using Godot;
using System;
using Godot.Collections;

public partial class SphereBoardEditor : MarginContainer
{
    [Export] private Button _new;
    [Export] private Button _open;
    [Export] private Button _save;
    [Export] private Button _add;
    [Export] private Button _remove;
    [Export] private Button _link;
    [Export] private OptionButton _sphereBoardId;
    [Export] private OptionButton _breed;
    [Export] private SpinBox _x;
    [Export] private SpinBox _y;
    [Export] private Array<OptionButton> _startingSpells;
    
    public event EventHandler NewPressed;
    public event EventHandler OpenPressed;
    public event EventHandler SavePressed;
    public event EventHandler AddPressed;
    public event EventHandler RemovePressed;
    public event EventHandler LinkPressed;

    public override void _Ready()
    {
        _new.Pressed += _OnNewPressed;
        _open.Pressed += _OnOpenPressed;
        _save.Pressed += _OnSavePressed;
        _add.Pressed += _OnAddPressed;
        _remove.Pressed += _OnRemovePressed;
        _link.Pressed += _OnLinkPressed;
        _sphereBoardId.ItemSelected += _OnSphereBoardIdSelected;
        _breed.ItemSelected += _OnBreedSelected;
        _x.Changed += _OnXChanged;
        _y.Changed += _OnYChanged;
    }
    
    private void _OnNewPressed()
    {
        NewPressed?.Invoke(this, EventArgs.Empty);
    }
    
    private void _OnOpenPressed()
    {
        OpenPressed?.Invoke(this, EventArgs.Empty);
    }
    
    private void _OnSavePressed()
    {
        SavePressed?.Invoke(this, EventArgs.Empty);
    }
    
    private void _OnAddPressed()
    {
        AddPressed?.Invoke(this, EventArgs.Empty);
    }
    
    private void _OnRemovePressed()
    {
        RemovePressed?.Invoke(this, EventArgs.Empty);
    }
    
    private void _OnLinkPressed()
    {
        LinkPressed?.Invoke(this, EventArgs.Empty);
    }
    
    private void _OnSphereBoardIdSelected(long index)
    {
        
    }
    
    private void _OnBreedSelected(long index)
    {
        
    }
    
    private void _OnXChanged()
    {
        
    }
    
    private void _OnYChanged()
    {
        
    }
}
