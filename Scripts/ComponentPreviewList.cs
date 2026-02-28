using Godot;
using System;

public partial class ComponentPreviewList : VBoxContainer
{
    [Export] private Label _label;
    [Export] private Button _add;
    [Export] private PackedScene _componentPreviewScene;
    
    public event EventHandler AddPressed;
    public event EventHandler<int> PreviewPressed;
    public event EventHandler<(int index, int value)> ValueChanged;
    public event EventHandler<(int index, SpellData spellData)> SpellDataChanged;
    public event EventHandler<(int index, FighterCardData fighterCardData)> FighterCardDataChanged;
    
    public event EventHandler<int> DeletePressed;

    public override void _Ready()
    {
        
    }
    
    
    
}
