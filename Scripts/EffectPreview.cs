using Godot;
using System;

public partial class EffectPreview : HBoxContainer
{
    [Export] private Button _preview;
    [Export] private Button _delete;

    public override void _Ready()
    {
        _preview.Pressed += _OnPreviewPressed;
        _delete.Pressed += _OnDeletePressed;
    }
    
    private void _OnPreviewPressed()
    {
        
    }

    private void _OnDeletePressed()
    {
        
    }
}
