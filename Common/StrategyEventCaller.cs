using System;
using Godot;

public static class StrategyEventCaller
{
    public static void OnSpawn(Entity entity)
    {
        foreach (var strategy in entity.Strategies)
        {
            if (strategy is IOnSpawn entityStrategy)
            {
                entityStrategy.OnSpawn(entity,entity.Position);
            }
        }
    }
    public static void OnBodyCollision(Entity entity, KinematicCollision2D collider)
    {
        foreach (var strategy in entity.Strategies)
        {
            if (strategy is IOnBodyCollision entityStrategy)
            {
                entityStrategy.OnBodyCollision(entity, collider);
            }
        }
    }
    public static void OnEntityCollision(Entity entity, Entity collider)
    {
        foreach (var strategy in entity.Strategies)
        {
            if (strategy is IOnEntityCollision entityStrategy)
            {
                entityStrategy.OnEntityCollision(entity, collider);
            }
        }
    }
}