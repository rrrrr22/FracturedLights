using System;
using Godot;

[GlobalClass]
public partial class DebugStrat : Strategy, IOnSpawn, IOnBodyCollision, IOnEntityCollision
{
    public void OnBodyCollision(Entity entity, KinematicCollision2D collider)
    {
        GD.Print("Debug OnBodyCollision");
    }

    public void OnEntityCollision(Entity entity, Entity collider)
    {
        GD.Print("Debug OnEntityCollision");
    }

    public void OnSpawn(Entity entity, Vector2 spawnLocation)
    {
        GD.Print("Debug OnSpawn");
    }
}