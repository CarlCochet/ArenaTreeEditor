using Godot;
using System;

public partial class ComponentPreview : HBoxContainer
{
    [Export] private Button _preview;
    [Export] private Button _delete;
    
    public int Index { get; set; }
    
    public event EventHandler<int> PreviewPressed;
    public event EventHandler<int> DeletePressed;

    public override void _Ready()
    {
        _preview.Pressed += _OnPreviewPressed;
        _delete.Pressed += _OnDeletePressed;
    }

    public void SetSpellData(SpellData spellData)
    {
        
    }

    public void SetLinkData(SphereData sphereData)
    {
        
    }

    public void SetEffectData(EffectData effectData)
    {
        
    }

    public void SetFighterCardData(FighterCardData fighterCardData)
    {
        
    }
    
    private void _OnPreviewPressed()
    {
        PreviewPressed?.Invoke(this, Index);
    }

    private void _OnDeletePressed()
    {
        DeletePressed?.Invoke(this, Index);
    }
}
