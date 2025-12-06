using System;
using Godot;

[GlobalClass]
public partial class DebugStrat : Strategy, IEntityStrategy
{
    public void OnSpawn(Entity entity, Vector2 spawnLocation)
    {
        GD.Print("Debug OnSpawn");
    }

    public void OnTouchingCollisionBody(KinematicCollision2D collision)
    {
        GD.Print("Debug OnTouchingCollisionBody");
    }
}