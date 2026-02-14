using Godot;
using System;
using System.Collections.Generic;
using Godot.Collections;

public partial class SphereBoard : Node2D
{
    [Export] public Array<Sphere> Spheres { get; set; }
    private int _sphereCount;
    private bool _buildGraph;
    private HashSet<(Sphere, Sphere)> _connectedSpheres;

    public override void _Process(double delta)
    {
        if (!Engine.IsEditorHint())
            return;
        
        if (_buildGraph)
            BuildGraph();
    }

    private void BuildGraph()
    {
        foreach (var child in GetChildren())
        {
            if (child is not Sphere sphere)
                return;
            
            
        }
    }
}
