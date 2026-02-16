using Godot;
using System;
using System.Collections.Generic;

public partial class SphereEditor : Node2D
{
    private Dictionary<int, SphereBoardData> _data;

    public override void _Ready()
    {
        
    }
    
    private void LoadData()
    {
        _data = new Dictionary<int, SphereBoardData>();
    }
}
