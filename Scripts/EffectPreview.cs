using Godot;
using System;

public partial class EffectPreview : HBoxContainer
{
    [Export] private Button _preview;
    [Export] private Button _delete;
    
    public event EventHandler PreviewPressed;
    public event EventHandler DeletePressed;

    public override void _Ready()
    {
        _preview.Pressed += _OnPreviewPressed;
        _delete.Pressed += _OnDeletePressed;
    }
    
    private void _OnPreviewPressed()
    {
        PreviewPressed?.Invoke(this, EventArgs.Empty);
    }

    private void _OnDeletePressed()
    {
        DeletePressed?.Invoke(this, EventArgs.Empty);
    }
}
