using Godot;
using System;

public partial class Editor : Node2D
{
    [Export] public Inspector Inspector { get; set; }
    [Export] public EffectEditor EffectEditor { get; set; }
    [Export] public SphereBoard SphereBoard { get; set; }
    [Export] public Camera Camera { get; set; }
    [Export] private FileDialog _openDialog;
    [Export] private FileDialog _saveDialog;

    public override void _Ready()
    {
        DisplayServer.WindowSetMinSize(new Vector2I(900, 500));
        EffectEditor.Visible = false;
        GlobalData.Instance.Load();

        SphereBoard.OnSphereSelected += _OnSphereSelected;
        
        Inspector.SphereBoardEditor.NewPressed += CreateSphereBoard;
        Inspector.SphereBoardEditor.OpenPressed += (_, _) => _openDialog.Visible = true;
        Inspector.SphereBoardEditor.SavePressed += (_, _) => _saveDialog.Visible = true;
        Inspector.SphereBoardEditor.AddPressed += AddSphere;
        Inspector.SphereBoardEditor.RemovePressed += RemoveSphere;
        Inspector.SphereBoardEditor.LinkPressed += LinkSpheres;

        Inspector.Init();
    }

    private void CreateSphereBoard(object sender, EventArgs e)
    {
        
    }
    
    private void AddSphere(object sender, EventArgs e)
    {
        
    }
    
    private void RemoveSphere(object sender, EventArgs e)
    {
        
    }
    
    private void LinkSpheres(object sender, EventArgs e)
    {
        
    }

    private void _OnSphereSelected(object sender, SphereData sphereData)
    {
        
    }
}
