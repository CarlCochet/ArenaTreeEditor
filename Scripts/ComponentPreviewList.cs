using Godot;
using System;
using System.Collections.Generic;

public partial class ComponentPreviewList : VBoxContainer
{
    [Export] private Label _label;
    [Export] private Button _add;
    [Export] private PackedScene _componentPreviewScene;
    
    public event EventHandler AddPressed;
    public event EventHandler<int> PreviewPressed;
    public event EventHandler<(int index, double value)> ValueChanged;
    public event EventHandler<(int index, SpellData spellData)> SpellDataChanged;
    public event EventHandler<(int index, FighterCardData fighterCardData)> FighterCardDataChanged;
    public event EventHandler<(int index, Enums.TriggerType trigger)> TriggerDataChanged;
    public event EventHandler<(int index, Enums.TargetType target)> TargetDataChanged;
    public event EventHandler<int> DeletePressed;
    
    private Mode _mode;

    public override void _Ready() { }

    public void SetTitle(string title)
    {
        _label.Text = title;
    }
    
    public void SetSpellData(List<SpellData> spells)
    {
        _mode = Mode.Spell;
        for (var i = 0; i < spells.Count; i++)
        {
            AddSpellComponent(i, spells[i]);
        }
    }
    
    public void SetLinkData(List<SphereData> spheres)
    {
        _mode = Mode.Link;
        for (var i = 0; i < spheres.Count; i++)
        {
            AddLinkComponent(i, spheres[i]);
        }
    }

    public void SetEffectData(List<EffectData> effects)
    {
        _mode = Mode.Effect;
        for (var i = 0; i < effects.Count; i++)
        {
            AddEffectComponent(i, effects[i]);
        }
    }

    public void SetFighterCardData(List<FighterCardData> fighterCards)
    {
        _mode = Mode.FighterCard;
        for (var i = 0; i < fighterCards.Count; i++)
        {
            AddFighterCardComponent(i, fighterCards[i]);
        }
    }

    public void SetTriggerData(List<Enums.TriggerType> triggers)
    {
        _mode = Mode.Trigger;
        for (var i = 0; i < triggers.Count; i++)
        {
            AddTriggerComponent(i, triggers[i]);
        }
    }

    public void SetTargetData(List<Enums.TargetType> targets)
    {
        _mode = Mode.Target;
        for (var i = 0; i < targets.Count; i++)
        {
            AddTargetComponent(i, targets[i]);
        }
    }

    public void SetValue(List<double> values)
    {
        _mode = Mode.Value;
        for (var i = 0; i < values.Count; i++)
        {
            AddValueComponent(i, values[i]);
        }
    }

    private void _OnAddPressed()
    {
        switch (_mode)
        {
            case Mode.Spell:
                AddSpellComponent(GetChildCount() - 1, new SpellData());
                break;
            case Mode.Link:
                AddLinkComponent(GetChildCount() - 1, new SphereData());
                break;
            case Mode.Effect:
                AddEffectComponent(GetChildCount() - 1, new EffectData());
                break;
            case Mode.FighterCard:
                AddFighterCardComponent(GetChildCount() - 1, new FighterCardData());
                break;
            case Mode.Trigger:
                AddTriggerComponent(GetChildCount() - 1, Enums.TriggerType.None);
                break;
            case Mode.Target:
                AddTargetComponent(GetChildCount() - 1, Enums.TargetType.Always);
                break;
            case Mode.Value:
                AddValueComponent(GetChildCount() - 1, 0);
                break;
            default:
                GD.PrintErr($"Wtf? {_mode}");
                break;
        }
        AddPressed?.Invoke(this, EventArgs.Empty);
    }

    private void AddSpellComponent(int index, SpellData spellData)
    {
        var spellPreview = _componentPreviewScene.Instantiate<ComponentPreview>();
        spellPreview.SetSpellData(spellData);
        spellPreview.Index = index;
        spellPreview.SpellDataChanged += _OnSpellChanged;
        spellPreview.DeletePressed += _OnDeletePressed;
        AddChild(spellPreview);
    }

    private void AddLinkComponent(int index, SphereData sphereData)
    {
        var linkPreview = _componentPreviewScene.Instantiate<ComponentPreview>();
        linkPreview.SetLinkData(sphereData);
        linkPreview.Index = index;
        linkPreview.PreviewPressed += _OnLinkPressed;
        linkPreview.DeletePressed += _OnDeletePressed;
        AddChild(linkPreview);
    }
    
    private void AddEffectComponent(int index, EffectData effectData)
    {
        var effectPreview = _componentPreviewScene.Instantiate<ComponentPreview>();
        effectPreview.SetEffectData(effectData);
        effectPreview.Index = index;
        effectPreview.PreviewPressed += _OnEffectPressed;
        effectPreview.DeletePressed += _OnDeletePressed;
        AddChild(effectPreview);
    }

    private void AddFighterCardComponent(int index, FighterCardData fighterCardData)
    {
        var fighterCardPreview = _componentPreviewScene.Instantiate<ComponentPreview>();
        fighterCardPreview.SetFighterCardData(fighterCardData);
        fighterCardPreview.Index = index;
        fighterCardPreview.FighterCardDataChanged += _OnFighterCardChanged;
        fighterCardPreview.DeletePressed += _OnDeletePressed;
        AddChild(fighterCardPreview);
    }
    
    private void AddTriggerComponent(int index, Enums.TriggerType trigger)
    {
        var triggerPreview = _componentPreviewScene.Instantiate<ComponentPreview>();
        triggerPreview.SetTriggerData(trigger);
        triggerPreview.Index = index;
        triggerPreview.TriggerDataChanged += _OnTriggerChanged;
        triggerPreview.DeletePressed += _OnDeletePressed;
        AddChild(triggerPreview);
    }
    
    private void AddTargetComponent(int index, Enums.TargetType target)
    {
        var targetPreview = _componentPreviewScene.Instantiate<ComponentPreview>();
        targetPreview.SetTargetData(target);
        targetPreview.Index = index;
        targetPreview.TargetDataChanged += _OnTargetChanged;
        targetPreview.DeletePressed += _OnDeletePressed;
        AddChild(targetPreview);
    }

    private void AddValueComponent(int index, double value)
    {
        var valuePreview = _componentPreviewScene.Instantiate<ComponentPreview>();
        valuePreview.SetValue(value);
        valuePreview.Index = index;
        valuePreview.ValueChanged += _OnValueChanged;
        valuePreview.DeletePressed += _OnDeletePressed;
        AddChild(valuePreview);
    }
    
    private void _OnSpellChanged(object sender, (int index, SpellData spellData) args)
    {
        SpellDataChanged?.Invoke(this, args);
    }
    
    private void _OnLinkPressed(object sender, int index)
    {
        PreviewPressed?.Invoke(this, index);
    }
    
    private void _OnEffectPressed(object sender, int index)
    {
        PreviewPressed?.Invoke(this, index);
    }
    
    private void _OnFighterCardChanged(object sender, (int index, FighterCardData fighterCardData) args)
    {
        FighterCardDataChanged?.Invoke(this, args);
    }
    
    private void _OnTriggerChanged(object sender, (int index, Enums.TriggerType trigger) args)
    {
        TriggerDataChanged?.Invoke(this, args);
    }
    
    private void _OnTargetChanged(object sender, (int index, Enums.TargetType target) args)
    {
        TargetDataChanged?.Invoke(this, args);
    }
    
    private void _OnValueChanged(object sender, (int index, double value) args)
    {
        ValueChanged?.Invoke(this, args);
    }
    
    private void _OnDeletePressed(object sender, int index)
    {
        
        DeletePressed?.Invoke(this, index);
    }

    private enum Mode
    {
        Spell,
        Link,
        Effect,
        FighterCard,
        Trigger,
        Target,
        Value,
    }
}
