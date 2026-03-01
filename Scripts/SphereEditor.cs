using Godot;
using System;

public partial class SphereEditor : ScrollContainer
{
    [Export] private SpinBox _xpNumber;
    [Export] private OptionButton _type;
    [Export] private SpinBox _x;
    [Export] private SpinBox _y;
    [Export] private VBoxContainer _spells;
    [Export] private Button _addSpell;
    [Export] private VBoxContainer _fighterCards;
    [Export] private Button _addFighterCard;
    [Export] private VBoxContainer _links;
    [Export] private VBoxContainer _effects;
    [Export] private Button _addEffect;
    [Export] private PackedScene _componentPreviewScene;
    
    public event EventHandler<int> XpNumberChanged;
    public event EventHandler<int> TypeSelected;
    public event EventHandler<int> XChanged;
    public event EventHandler<int> YChanged;
    public event EventHandler SpellAdded;
    public event EventHandler FighterCardAdded;
    public event EventHandler EffectAdded;
    public event EventHandler<int> SpellPressed;
    public event EventHandler<int> FighterCardPressed;
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
        _addSpell.Pressed += _OnAddSpellPressed;
        _addFighterCard.Pressed += _OnAddFighterCardPressed;
        _addEffect.Pressed += _OnAddEffectPressed;
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
    
    private void _OnAddSpellPressed()
    {
        var spellPreview = _componentPreviewScene.Instantiate<ComponentPreview>();
        spellPreview.SetSpellData(new SpellData());
        spellPreview.Index = _spells.GetChildCount() - 1;
        spellPreview.PreviewPressed += _OnSpellPressed;
        spellPreview.DeletePressed += _OnSpellDeleted;
        _spells.AddChild(spellPreview);
        SpellAdded?.Invoke(this, EventArgs.Empty);
    }
    
    private void _OnAddFighterCardPressed()
    {
        var cardPreview = _componentPreviewScene.Instantiate<ComponentPreview>();
        cardPreview.SetFighterCardData(new FighterCardData());
        cardPreview.Index = _fighterCards.GetChildCount() - 1;
        cardPreview.PreviewPressed += _OnFighterCardPressed;
        cardPreview.DeletePressed += _OnFighterCardDeleted;
        _fighterCards.AddChild(cardPreview);
        FighterCardAdded?.Invoke(this, EventArgs.Empty);
    }
    
    private void _OnAddEffectPressed()
    {
        var effectPreview = _componentPreviewScene.Instantiate<ComponentPreview>();
        effectPreview.SetEffectData(new EffectData());
        effectPreview.Index = _effects.GetChildCount() - 1;
        effectPreview.PreviewPressed += _OnEffectPressed;
        effectPreview.DeletePressed += _OnEffectDeleted;
        _effects.AddChild(effectPreview);
        EffectAdded?.Invoke(this, EventArgs.Empty);
    }

    private void _OnSpellPressed(object sender, int index)
    {
        SpellPressed?.Invoke(this, index);
    }
    
    private void _OnFighterCardPressed(object sender, int index)
    {
        FighterCardPressed?.Invoke(this, index);
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
