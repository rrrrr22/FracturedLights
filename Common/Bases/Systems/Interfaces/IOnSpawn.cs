using System;
using Godot;

public interface IOnSpawn : IEntityStrategy
{
    public void OnSpawn(Entity entity, Vector2 spawnLocation);

}