using Godot;
using System;

public partial class Inspector : Control
{
    [Export] public SphereBoardEditor SphereBoardEditor;
    [Export] public SphereEditor SphereEditor;

    public override void _Ready() { }

    public void Init()
    {
        SphereBoardEditor.Init();
        SphereEditor.Init();
    }
}
