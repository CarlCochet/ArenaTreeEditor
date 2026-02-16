using Godot;
using System;

public partial class Inspector : Control
{
    [Export] private Button _addNode;
    [Export] private Button _removeNode;
    [Export] private Button _linkNodes;
    [Export] private Button _newTree;
    [Export] private Button _open;
    [Export] private Button _save;
    [Export] private Button _addEffect;

    public override void _Ready()
    {
        _addNode.Pressed += AddNode;
        _removeNode.Pressed += RemoveNode;
        _linkNodes.Pressed += LinkNodes;
        _newTree.Pressed += NewTree;
        _open.Pressed += Open;
        _save.Pressed += Save;
        _addEffect.Pressed += AddEffect;
    }

    private void AddNode()
    {
        
    }

    private void RemoveNode()
    {
        
    }

    private void LinkNodes()
    {
        
    }

    private void NewTree()
    {
        
    }
    
    private void Open()
    {
        
    }
    
    private void Save()
    {
        
    }

    private void AddEffect()
    {
        
    }
}
