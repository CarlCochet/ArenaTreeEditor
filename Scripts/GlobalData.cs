using Godot;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading;
using FileAccess = Godot.FileAccess;

public class GlobalData
{
    public Dictionary<int, SphereBoardData> SphereBoardData;
    public Dictionary<int, SphereData> SphereData;
    public Dictionary<int, SpellData> SpellData;
    public Dictionary<int, FighterCardData> FighterCardsData;
    
    public Settings Settings { get; set; }
    
    private static GlobalData _instance;
    private static readonly Lock Lock = new();
    private readonly JsonSerializerOptions _jsonOptions = new()
    {
        PropertyNameCaseInsensitive = true,
        WriteIndented = true
    };
    
    public static GlobalData Instance
    {
        get
        {
            if (_instance != null) 
                return _instance;
            
            lock (Lock)
            {
                _instance ??= new GlobalData();
            }
            return _instance;
        }
    }

    public void Load()
    {
        LoadFighterCards();
        LoadSpells();
    }
    
    public void LoadData(string path)
    {
        var spheresPath = Path.Combine(path, "spheres.json");
        var sphereBoardsPath = Path.Combine(path, "sphere_boards.json");

        if (!File.Exists(spheresPath) || !File.Exists(sphereBoardsPath))
        {
            GD.PrintErr($"Missing data file(s). Expected: {spheresPath} and {sphereBoardsPath}");
            SphereData = new Dictionary<int, SphereData>();
            SphereBoardData = new Dictionary<int, SphereBoardData>();
            return;
        }

        var sphereList = JsonSerializer.Deserialize<List<SphereData>>(File.ReadAllText(spheresPath), _jsonOptions) ?? [];
        var sphereBoardList = JsonSerializer.Deserialize<List<SphereBoardData>>(File.ReadAllText(sphereBoardsPath), _jsonOptions) ?? [];

        SphereData = new Dictionary<int, SphereData>();
        foreach (var sphere in sphereList)
        {
            SphereData[sphere.Id] = sphere;
        }

        SphereBoardData = new Dictionary<int, SphereBoardData>();
        foreach (var board in sphereBoardList)
        {
            SphereBoardData[board.Id] = board;
        }
        
        GD.Print($"Loaded {SphereData.Count} spheres and {SphereBoardData.Count} sphere boards.");
    }

    public void SaveData(string path)
    {
        Directory.CreateDirectory(path);

        var spheresPath = Path.Combine(path, "spheres.json");
        var sphereBoardsPath = Path.Combine(path, "sphere_boards.json");

        var sphereList = SphereData != null ? new List<SphereData>(SphereData.Values) : [];
        var sphereBoardList = SphereBoardData != null ? new List<SphereBoardData>(SphereBoardData.Values) : [];

        File.WriteAllText(spheresPath, JsonSerializer.Serialize(sphereList, _jsonOptions));
        File.WriteAllText(sphereBoardsPath, JsonSerializer.Serialize(sphereBoardList, _jsonOptions));
        
        GD.Print("Saved data.");
    }
    
    public void SaveSettings()
    {
        using var settingsFile = FileAccess.Open("user://settings.json", FileAccess.ModeFlags.Write);
        
        settingsFile.StoreString(JsonSerializer.Serialize(Settings));
    }
    
    public void LoadSettings()
    {
        var settingsStr = FileAccess.GetFileAsString("user://settings.json");
        if (settingsStr.Length == 0)
            return;
		
        Settings = JsonSerializer.Deserialize<Settings>(settingsStr);
    }

    
    private void LoadFighterCards()
    {
        const string path = "res://Data/fighter_cards.json";
        
        if (!FileAccess.FileExists(path))
        {
            GD.PrintErr($"Missing fighter cards data file: {path}");
            FighterCardsData = new Dictionary<int, FighterCardData>();
            return;
        }
        
        var json = FileAccess.GetFileAsString(path);
        if (string.IsNullOrWhiteSpace(json))
        {
            GD.PrintErr($"Fighter cards data file is empty: {path}");
            FighterCardsData = new Dictionary<int, FighterCardData>();
            return;
        }

        var fighterCardsList = JsonSerializer.Deserialize<List<FighterCardData>>(json, _jsonOptions) ?? [];

        FighterCardsData = new Dictionary<int, FighterCardData>();
        foreach (var fighterCardData in fighterCardsList)
        {
            FighterCardsData[fighterCardData.Id] = fighterCardData;
        }

        GD.Print($"Loaded {FighterCardsData.Count} fighter cards.");
    }

    private void LoadSpells()
    {
        const string path = "res://Data/spell_cards.json";
        

        if (!FileAccess.FileExists(path))
        {
            GD.PrintErr($"Missing spell data file: {path}");
            SpellData = new Dictionary<int, SpellData>();
            FighterCardsData = new Dictionary<int, FighterCardData>();
            return;
        }

        var json = FileAccess.GetFileAsString(path);
        var fighterCardsJson = FileAccess.GetFileAsString(path);
        if (string.IsNullOrWhiteSpace(json) || string.IsNullOrWhiteSpace(fighterCardsJson))
        {
            GD.PrintErr($"Spell data file is empty: {path}");
            SpellData = new Dictionary<int, SpellData>();
            return;
        }

        var spellList = JsonSerializer.Deserialize<List<SpellData>>(json, _jsonOptions) ?? [];

        SpellData = new Dictionary<int, SpellData>();
        foreach (var spell in spellList)
        {
            SpellData[spell.Id] = spell;
        }

        GD.Print($"Loaded {SpellData.Count} spells.");
    }
}
