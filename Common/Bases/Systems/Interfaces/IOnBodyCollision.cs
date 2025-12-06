using Godot;
using System;

public interface IOnBodyCollision : IEntityStrategy
{
    public void OnBodyCollision(KinematicCollision2D collider);
}
