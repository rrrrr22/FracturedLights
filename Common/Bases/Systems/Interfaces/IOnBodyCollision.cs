using Godot;
using System;

public interface IOnBodyCollision : IEntityStrategy
{
    public void OnBodyCollision(Entity entity, KinematicCollision2D collider);
}
