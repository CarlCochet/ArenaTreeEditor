using Godot;
using System;

public partial class SphereEditor : ScrollContainer
{
    [Export] private SpinBox _xpNumber;
    [Export] private OptionButton _type;
    [Export] private SpinBox _x;
    [Export] private SpinBox _y;
    [Export] private ComponentPreviewList _spells;
    [Export] private ComponentPreviewList _fighterCards;
    [Export] private VBoxContainer _links;
    [Export] private ComponentPreviewList _effects;
    [Export] private PackedScene _componentPreviewScene;
    
    public event EventHandler<int> XpNumberChanged;
    public event EventHandler<int> TypeSelected;
    public event EventHandler<int> XChanged;
    public event EventHandler<int> YChanged;
    public event EventHandler SpellAdded;
    public event EventHandler FighterCardAdded;
    public event EventHandler EffectAdded;
    public event EventHandler<(int index, SpellData spellData)> SpellChanged;
    public event EventHandler<(int index, FighterCardData fighterCardData)> FighterCardChanged;
    public event EventHandler<int> LinkPressed;
    public event EventHandler<int> EffectPressed;
    public event EventHandler<int> SpellDeleted;
    public event EventHandler<int> FighterCardDeleted;
    public event EventHandler<int> LinkDeleted;
    public event EventHandler<int> EffectDeleted;
    
    public override void _Ready()
    {
        _xpNumber.ValueChanged += _OnXpNumberChanged;
        _type.ItemSelected += _OnTypeSelected;
        _x.ValueChanged += _OnXChanged;
        _y.ValueChanged += _OnYChanged;
        _spells.AddPressed += _OnAddSpellPressed;
        _spells.DeletePressed += _OnSpellDeleted;
        _spells.SpellDataChanged += _OnSpellChanged;
        _fighterCards.AddPressed += _OnAddFighterCardPressed;
        _fighterCards.DeletePressed += _OnFighterCardDeleted;
        _fighterCards.FighterCardDataChanged += _OnFighterCardChanged;
        _effects.AddPressed += _OnAddEffectPressed;
        _effects.DeletePressed += _OnEffectDeleted;
        _effects.PreviewPressed += _OnEffectPressed;
    }
    
    public void AddLink(SphereData sphereData)
    {
        var linkPreview = _componentPreviewScene.Instantiate<ComponentPreview>();
        linkPreview.SetLinkData(sphereData);
        linkPreview.Index = _links.GetChildCount() - 1;
        linkPreview.PreviewPressed += _OnLinkPressed;
        linkPreview.DeletePressed += _OnLinkDeleted;
        _links.AddChild(linkPreview);
    }
    
    private void _OnXpNumberChanged(double value)
    {
        XpNumberChanged?.Invoke(this, (int)value);
    }
    
    private void _OnTypeSelected(long index)
    {
        TypeSelected?.Invoke(this, (int)index);
    }
    
    private void _OnXChanged(double value)
    {
        XChanged?.Invoke(this, (int)value);
    }
    
    private void _OnYChanged(double value)
    {
        YChanged?.Invoke(this, (int)value);   
    }
    
    private void _OnAddSpellPressed(object sender, EventArgs eventArgs)
    {
        SpellAdded?.Invoke(this, EventArgs.Empty);
    }
    
    private void _OnAddFighterCardPressed(object sender, EventArgs eventArgs)
    {
        FighterCardAdded?.Invoke(this, EventArgs.Empty);
    }
    
    private void _OnAddEffectPressed(object sender, EventArgs eventArgs)
    {
        EffectAdded?.Invoke(this, EventArgs.Empty);
    }

    private void _OnSpellChanged(object sender, (int index, SpellData spellData) args)
    {
        SpellChanged?.Invoke(this, args);
    }
    
    private void _OnFighterCardChanged(object sender, (int index, FighterCardData fighterCardData) args)
    {
        FighterCardChanged?.Invoke(this, args);
    }

    private void _OnLinkPressed(object sender, int index)
    {
        LinkPressed?.Invoke(this, index);
    }
    
    private void _OnEffectPressed(object sender, int index)
    {
        EffectPressed?.Invoke(this, index);
    }

    private void _OnSpellDeleted(object sender, int index)
    {
        SpellDeleted?.Invoke(this, index);
    }
    
    private void _OnFighterCardDeleted(object sender, int index)
    {
        FighterCardDeleted?.Invoke(this, index);
    }

    private void _OnLinkDeleted(object sender, int index)
    {
        LinkDeleted?.Invoke(this, index);
    }
    
    private void _OnEffectDeleted(object sender, int index)
    {
        EffectDeleted?.Invoke(this, index);
    }
}
