using Godot;
using System;

public partial class Strategy : Node
{
    public StrategyManager Manager {get; set;}
    public override void _Ready()
    {
        var parent = GetParentOrNull<Node>();
        if(parent == null) 
            return;

        if(parent is StrategyManager strategyManager)
        {
            Manager = strategyManager;
            Manager.OnUpdate += OnUpdate;
            Manager.OnSpawn += OnSpawn;
        }
    }

    public virtual void OnSpawn(Vector2 spawnLocation)
    {
        GD.Print("Ready");
    }


    public virtual void OnUpdate()
    {
        GD.Print("Update");
    }


    public override void _ExitTree()
    {
        base._ExitTree();
        Manager.OnUpdate -= OnUpdate;
        Manager.OnSpawn -= OnSpawn;
    }


}
