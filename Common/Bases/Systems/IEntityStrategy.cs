using System;
using Godot;

public interface IEntityStrategy 
{
    public void OnSpawn(Entity entity, Vector2 spawnLocation);

    public void OnTouchingCollisionBody(KinematicCollision2D collision);


}