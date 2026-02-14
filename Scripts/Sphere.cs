using Godot;
using System;
using Godot.Collections;

public partial class Sphere : Sprite2D
{
    public event EventHandler OnConnectedSpheresChanged;
    
    [Export] public Array<Sphere> ConnectedSpheres { get; set; }
    private int _lastConnectedCount;

    public override void _Process(double delta)
    {
        if (!Engine.IsEditorHint())
            return;
        
        if (ConnectedSpheres.Count == _lastConnectedCount)
            return;
        
        _lastConnectedCount = ConnectedSpheres.Count;
        OnConnectedSpheresChanged?.Invoke(this, EventArgs.Empty);
    }
}
