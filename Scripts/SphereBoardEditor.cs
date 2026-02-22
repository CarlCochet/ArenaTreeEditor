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
    [Export] private SpinBox _sphereBoardId;
    [Export] private SpinBox _breedId;
    [Export] private SpinBox _x;
    [Export] private SpinBox _y;
    [Export] private Array<OptionButton> _startingSpells;
    
    
}
