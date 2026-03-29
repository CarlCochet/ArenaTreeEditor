using Godot;
using System;
using System.Collections.Generic;
using Godot.Collections;

public partial class SphereBoard : Node2D
{
    
    [Export] private PackedScene _sphereScene;
    [Export] private Node2D _links;
    [Export] private Node2D _spheres;

    private int _sphereCount;
    private bool _buildGraph;
    private HashSet<(SphereData, SphereData)> _connectedSpheres = [];

    public event EventHandler<SphereData> OnSphereSelected;

    public override void _Process(double delta)
    {
        if (!Engine.IsEditorHint())
            return;
        
        if (_buildGraph)
            BuildGraph();
    }
    public void Reset()
    {
        foreach (var sphere in _spheres.GetChildren())
        {
            sphere.QueueFree();
        }
        _connectedSpheres.Clear();
    }

    public void Load(SphereBoardData sphereBoardData, List<SphereData> spheres)
    {
        Reset();

        foreach (var sphereData in spheres)
        {
            var sphere = _sphereScene.Instantiate<Sphere>();
            sphere.SetData(sphereData);
            _spheres.AddChild(sphere);
        }
        
        BuildGraph();
    }
    
    private void BuildGraph()
    {
        foreach (var child in _spheres.GetChildren())
        {
            if (child is not Sphere sphere)
                return;
            
            
        }
    }
}
