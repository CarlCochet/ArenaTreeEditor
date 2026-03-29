using Godot;
using System;
using System.Linq;
using Godot.Collections;

public partial class SphereBoardEditor : MarginContainer
{
    [Export] private Button _new;
    [Export] private Button _open;
    [Export] private Button _save;
    [Export] private Button _add;
    [Export] private Button _remove;
    [Export] private Button _link;
    [Export] private OptionButton _sphereBoardId;
    [Export] private OptionButton _breed;
    [Export] private SpinBox _x;
    [Export] private SpinBox _y;
    [Export] private Array<OptionButton> _startingSpells;
    
    public event EventHandler NewPressed;
    public event EventHandler OpenPressed;
    public event EventHandler SavePressed;
    public event EventHandler AddPressed;
    public event EventHandler RemovePressed;
    public event EventHandler LinkPressed;
    public event EventHandler<int> SphereBoardIdSelected;
    public event EventHandler<int> BreedSelected;
    public event EventHandler<int> XChanged;
    public event EventHandler<int> YChanged;
    public event EventHandler<(int index, int id)> StartingSpellSelected;

    public override void _Ready()
    {
        _new.Pressed += _OnNewPressed;
        _open.Pressed += _OnOpenPressed;
        _save.Pressed += _OnSavePressed;
        _add.Pressed += _OnAddPressed;
        _remove.Pressed += _OnRemovePressed;
        _link.Pressed += _OnLinkPressed;
        _sphereBoardId.ItemSelected += _OnSphereBoardIdSelected;
        _breed.ItemSelected += _OnBreedSelected;
        _x.Changed += _OnXChanged;
        _y.Changed += _OnYChanged;

        for (var i = 0; i < _startingSpells.Count; i++)
        {
            var spellIndex = i;
            _startingSpells[spellIndex].ItemSelected += itemIndex => _OnStartingSpellSelected(spellIndex, itemIndex);
        }
    }

    public void Init()
    {
        foreach (var key in GlobalData.Instance.SphereBoardData.Keys)
        {
            _sphereBoardId.AddItem(key.ToString(), key);
        }
        
        foreach (var value in Enum.GetValues<Enums.Breeds>())
        {
            _breed.AddItem(value.ToString(), (int)value);
        }

        foreach (var startingSpell in _startingSpells)
        {
            var breedSpells = GlobalData.Instance.SpellData.Values
                .Where(s => s.Category == GlobalData.Instance.CurrentBreed);
            foreach (var spell in breedSpells)
            {
                startingSpell.AddItem(spell.Name, spell.Id);
            }
        }
    }
    
    private void _OnNewPressed()
    {
        NewPressed?.Invoke(this, EventArgs.Empty);
    }
    
    private void _OnOpenPressed()
    {
        OpenPressed?.Invoke(this, EventArgs.Empty);
    }
    
    private void _OnSavePressed()
    {
        SavePressed?.Invoke(this, EventArgs.Empty);
    }
    
    private void _OnAddPressed()
    {
        GlobalData.Instance.CurrentMode = Enums.EditorMode.Add;
        _remove.SetPressedNoSignal(false);
        _link.SetPressedNoSignal(false);
        AddPressed?.Invoke(this, EventArgs.Empty);
    }
    
    private void _OnRemovePressed()
    {
        GlobalData.Instance.CurrentMode = Enums.EditorMode.Remove;
        _add.SetPressedNoSignal(false);
        _link.SetPressedNoSignal(false);
        RemovePressed?.Invoke(this, EventArgs.Empty);
    }
    
    private void _OnLinkPressed()
    {
        GlobalData.Instance.CurrentMode = Enums.EditorMode.Link;
        _add.SetPressedNoSignal(false);
        _remove.SetPressedNoSignal(false);
        LinkPressed?.Invoke(this, EventArgs.Empty);
    }
    
    private void _OnSphereBoardIdSelected(long index)
    {
        SphereBoardIdSelected?.Invoke(this, _sphereBoardId.GetItemId((int)index));
    }
    
    private void _OnBreedSelected(long index)
    {
        var id = _breed.GetItemId((int)index);
        GlobalData.Instance.CurrentBreed = (Enums.Breeds)id;
        foreach (var startingSpell in _startingSpells)
        {
            startingSpell.Clear();
            var breedSpells = GlobalData.Instance.SpellData.Values
                .Where(s => s.Category == GlobalData.Instance.CurrentBreed);
            foreach (var spell in breedSpells)
            {
                startingSpell.AddItem(spell.Name, spell.Id);
            }
        }
        BreedSelected?.Invoke(this, id);
    }
    
    private void _OnXChanged()
    {
        XChanged?.Invoke(this, (int)_x.Value);
    }
    
    private void _OnYChanged()
    {
        YChanged?.Invoke(this, (int)_y.Value);
    }

    private void _OnStartingSpellSelected(int spellIndex, long itemIndex)
    {
        StartingSpellSelected?.Invoke(this, (spellIndex, _startingSpells[spellIndex].GetItemId((int)itemIndex)));
    }
}
