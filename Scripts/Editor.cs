using Godot;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using FileAccess = Godot.FileAccess;

public partial class Editor : Node2D
{
    [Export] public Inspector Inspector { get; set; }
    [Export] public EffectEditor EffectEditor { get; set; }
    [Export] public SphereBoard SphereBoard { get; set; }
    [Export] public Camera Camera { get; set; }
    [Export] private FileDialog _openDialog;
    [Export] private FileDialog _saveDialog;
    
    private Dictionary<int, SphereBoardData> _sphereBoardData;
    private Dictionary<int, SphereData> _sphereData;
    private Dictionary<int, SpellData> _spellData;
    private Dictionary<int, FighterCardData> _fighterCardsData;
    
    private readonly JsonSerializerOptions _jsonOptions = new()
    {
        PropertyNameCaseInsensitive = true,
        WriteIndented = true
    };

    public override void _Ready()
    {
        DisplayServer.WindowSetMinSize(new Vector2I(900, 500));
        EffectEditor.Visible = false;

        SphereBoard.OnSphereSelected += _OnSphereSelected;
        
        Inspector.SphereBoardEditor.NewPressed += CreateSphereBoard;
        Inspector.SphereBoardEditor.OpenPressed += (_, _) => _openDialog.Visible = true;
        Inspector.SphereBoardEditor.SavePressed += (_, _) => _saveDialog.Visible = true;
        Inspector.SphereBoardEditor.AddPressed += AddSphere;
        Inspector.SphereBoardEditor.RemovePressed += RemoveSphere;
        Inspector.SphereBoardEditor.LinkPressed += LinkSpheres;
        
        GlobalData.Instance.Load();
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
