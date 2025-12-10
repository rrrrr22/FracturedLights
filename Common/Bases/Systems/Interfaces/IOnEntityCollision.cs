using System;
using Godot;

public interface IOnEntityCollision : IEntityStrategy
{
    
    public void OnEntityCollision(Entity entity, Entity collider);

}