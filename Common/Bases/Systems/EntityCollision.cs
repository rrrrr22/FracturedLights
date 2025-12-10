using Godot;
using System;

public partial class EntityCollision : Area2D
{
    [Export] public Entity Entity {get; set;}
    [Export] public bool IsCollisionPhysicsEnabled {get; set;} = true;
    public override void _PhysicsProcess(double delta)
    {
        if(HasOverlappingAreas())
        {
            foreach(Area2D area in GetOverlappingAreas())
            {
                if(area is EntityCollision softCollider && softCollider.IsCollisionPhysicsEnabled)
                {
                    CollisionPhysics(softCollider);
                }   
            }
        }
    }
    public virtual void CollisionPhysics(EntityCollision softCollider)
    {
        Vector2 dir = Entity.Position.DirectionTo(softCollider.Entity.Position);
        if(dir == Vector2.Zero || dir == Vector2.Inf)
            dir = Vector2.Right.Rotated(GD.Randf() * (MathF.PI * 2));
        softCollider.Entity.Velocity += dir;
        softCollider.Entity.CollideAndSlideNoDelta();
        softCollider.Entity.Velocity = Vector2.Zero;
    }

    public void OnAreaEntered(Area2D area)
    {
        if(area is EntityCollision entityCollision)
            StrategyEventCaller.OnEntityCollision(Entity,entityCollision.Entity);
    }
}
