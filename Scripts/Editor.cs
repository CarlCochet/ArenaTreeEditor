using Godot;
using System;
using System.Collections.Generic;

public partial class Editor : Node2D
{
    [Export] public Inspector Inspector { get; set; }
    [Export] public EffectEditor EffectEditor { get; set; }
    [Export] public SphereBoard SphereBoard { get; set; }
    [Export] public Camera Camera { get; set; }
    
    private Dictionary<int, SphereBoardData> _data;

    public override void _Ready()
    {
        DisplayServer.WindowSetMinSize(new Vector2I(900, 500));
        EffectEditor.Visible = false;

        SphereBoard.OnSphereSelected += _OnSphereSelected;
    }
    
    private void LoadData()
    {
        _data = new Dictionary<int, SphereBoardData>();
    }

    private void _OnSphereSelected(object sender, SphereData sphereData)
    {
        if (sphereData == null)
        {
            EffectEditor.Visible = false;
            return;
        }
        EffectEditor.Visible = true;
        EffectEditor.Load(sphereData);
    }
}
