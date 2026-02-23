using Godot;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

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
        
        
    }
    
    private void LoadData(string path)
    {
        var spheresPath = Path.Combine(path, "spheres.json");
        var sphereBoardsPath = Path.Combine(path, "sphere_boards.json");

        if (!File.Exists(spheresPath) || !File.Exists(sphereBoardsPath))
        {
            GD.PrintErr($"Missing data file(s). Expected: {spheresPath} and {sphereBoardsPath}");
            _sphereData = new Dictionary<int, SphereData>();
            _sphereBoardData = new Dictionary<int, SphereBoardData>();
            return;
        }

        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

        var sphereList = JsonSerializer.Deserialize<List<SphereData>>(File.ReadAllText(spheresPath), options) ?? [];
        var sphereBoardList = JsonSerializer.Deserialize<List<SphereBoardData>>(File.ReadAllText(sphereBoardsPath), options) ?? [];

        _sphereData = new Dictionary<int, SphereData>();
        foreach (var sphere in sphereList)
        {
            _sphereData[sphere.Id] = sphere;
        }

        _sphereBoardData = new Dictionary<int, SphereBoardData>();
        foreach (var board in sphereBoardList)
        {
            _sphereBoardData[board.Id] = board;
        }
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
        if (sphereData == null)
        {
            EffectEditor.Visible = false;
            return;
        }
        EffectEditor.Visible = true;
        EffectEditor.SetData(sphereData);
    }
}
