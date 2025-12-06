using System;
using Godot;

public static class StrategyEventCaller
{
    public static void OnSpawn(Entity entity)
    {
        foreach (var strategy in entity.Strategies)
        {
            if (strategy is IEntityStrategy entityStrategy)
            {
                entityStrategy.OnSpawn(entity,entity.Position);
            }
        }
    }
}