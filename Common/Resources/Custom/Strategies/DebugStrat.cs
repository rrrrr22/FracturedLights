using System;
using Godot;

[GlobalClass]
public partial class DebugStrat : Strategy, IOnSpawn, IOnBodyCollision
{
    public void OnBodyCollision(KinematicCollision2D collider)
    {
        GD.Print("Debug OnBodyCollision");
    }

    public void OnSpawn(Entity entity, Vector2 spawnLocation)
    {
        GD.Print("Debug OnSpawn");
    }
}