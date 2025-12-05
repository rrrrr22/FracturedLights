using Godot;
using System;

public partial class SoftCollider : Area2D
{
    [Export] public Entity Entity {get; set;}
    [Export] public bool isCollisionEnabled {get; set;} = true;
    public override void _PhysicsProcess(double delta)
    {
        if(isCollisionEnabled && HasOverlappingAreas())
        {
            foreach(Area2D area in GetOverlappingAreas())
            {
                if(area is SoftCollider softCollider)
                {
                    CollideWithHandler(softCollider);
                }   
            }
        }
    }
    public virtual void CollideWithHandler(SoftCollider softCollider)
    {
        Vector2 dir = Entity.Position.DirectionTo(softCollider.Entity.Position);
        if(dir == Vector2.Zero || dir == Vector2.Inf)
            dir = Vector2.Right.Rotated(GD.Randf() * (MathF.PI * 2));
        softCollider.Entity.Velocity += dir;
        softCollider.Entity.CollideAndSlideNoDelta();
        softCollider.Entity.Velocity = Vector2.Zero;
    }
    
}
