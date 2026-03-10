using Godot;
using System;
using System.Text.Json.Serialization;

public class Settings
{
    [JsonPropertyName("Path")] public string Path { get; set; }
}
