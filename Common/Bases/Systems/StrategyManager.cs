using Godot;
using System;

public partial class StrategyManager : Node
{
    [Export] public Entity Entity {get; set;}
    [Signal] public delegate void OnUpdateEventHandler();
    [Signal] public delegate void OnSpawnEventHandler(Vector2 spawnLocation);
    public override void _Ready()
    {
        base._Ready();
        Entity.Ready += OnEntityReady;
    }
    private void OnEntityReady()
    {
        EmitSignal(SignalName.OnSpawn,Entity.Position);
    }
    public override void _PhysicsProcess(double delta)
    {
        base._PhysicsProcess(delta);
        EmitSignal(SignalName.OnUpdate);
    }
    public override void _ExitTree()
    {
        base._ExitTree();
        Entity.Ready -= OnEntityReady;
    }
}
