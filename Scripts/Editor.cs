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
        
        LoadSpells();
    }

    private void LoadSpells()
    {
        const string spellsPath = "res://Data/spell_cards.json";

        if (!FileAccess.FileExists(spellsPath))
        {
            GD.PrintErr($"Missing spell data file: {spellsPath}");
            _spellData = new Dictionary<int, SpellData>();
            return;
        }

        var json = FileAccess.GetFileAsString(spellsPath);
        if (string.IsNullOrWhiteSpace(json))
        {
            GD.PrintErr($"Spell data file is empty: {spellsPath}");
            _spellData = new Dictionary<int, SpellData>();
            return;
        }

        var spellList = JsonSerializer.Deserialize<List<SpellData>>(json, _jsonOptions) ?? [];

        _spellData = new Dictionary<int, SpellData>();
        foreach (var spell in spellList)
        {
            _spellData[spell.Id] = spell;
        }

        GD.Print($"Loaded {_spellData.Count} spells.");
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

        var sphereList = JsonSerializer.Deserialize<List<SphereData>>(File.ReadAllText(spheresPath), _jsonOptions) ?? [];
        var sphereBoardList = JsonSerializer.Deserialize<List<SphereBoardData>>(File.ReadAllText(sphereBoardsPath), _jsonOptions) ?? [];

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
        
        GD.Print($"Loaded {_sphereData.Count} spheres and {_sphereBoardData.Count} sphere boards.");
    }

    private void SaveData(string path)
    {
        Directory.CreateDirectory(path);

        var spheresPath = Path.Combine(path, "spheres.json");
        var sphereBoardsPath = Path.Combine(path, "sphere_boards.json");

        var sphereList = _sphereData != null ? new List<SphereData>(_sphereData.Values) : [];
        var sphereBoardList = _sphereBoardData != null ? new List<SphereBoardData>(_sphereBoardData.Values) : [];

        File.WriteAllText(spheresPath, JsonSerializer.Serialize(sphereList, _jsonOptions));
        File.WriteAllText(sphereBoardsPath, JsonSerializer.Serialize(sphereBoardList, _jsonOptions));
        
        GD.Print("Saved data.");
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
