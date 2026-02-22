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
}
