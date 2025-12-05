using Godot;
using RisingShot;
using System;
using System.Xml.XPath;

public partial class Entity : CharacterBody2D
{
    [Export] public StateMachine StateMachineNode { get; set; }
    [Export] public AnimatedSprite2D Sprite { get; set; }
    [Export] public bool IsAlive { get; set; } = true;
    [Export] public CollisionShape2D ColShape { get; set; }
    [Export] public Area2D SoftCollider { get; set; }
    [Export] public bool NoTileCollide { get; set; } = false;
    public Vector2 OldPosition { get; set; } = Vector2.Zero;
    public override void _PhysicsProcess(double delta)
    {
        base._PhysicsProcess(delta);
        OldPosition = Position;

        if (NoTileCollide)
        {
            CollisionLayer = 1;
        }
        CollideAndSlideNoDelta();
    }
    public void CollideAndSlideNoDelta()
    {
        var collision = MoveAndCollide(Velocity);
        if(collision != null)
        {
            Velocity = Velocity.Slide(collision.GetNormal());
            MoveAndCollide(collision.GetRemainder().Slide(collision.GetNormal()));
        }
    }
}
