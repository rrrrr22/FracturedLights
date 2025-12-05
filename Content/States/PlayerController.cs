using Godot;
using System;
using System.Collections.Generic;
public partial class PlayerController : State
{
    public bool isMoving {get; set;} = false;
    public bool FaceLeft {get; set;} = false;
    public float cooldown {get; set;}
    public override void OnEntered()
    {
    }
    public override void Process(double delta)
    {
        ImportantUpdate();
        Resetting();
        Movement();
        Shooting();
        Reloading();
        Sprite();
        Physics(delta);
    }
    public void ImportantUpdate() 
    {
    }
    public void Resetting() 
    {
        Entity.Velocity = Vector2.Zero;
        isMoving = false;
    }
    public void Physics(double delta)
    {
        Entity.Velocity = Entity.Velocity.Normalized();
        Entity.Velocity *= 3; // place holder untill stats are implmented
    }
    public void Sprite() 
    {
        var sprite = Entity.Sprite;
        if (isMoving && Entity.Velocity != Vector2.Zero)
            sprite.Play("moving");
        else
            sprite.Play("idle");
        sprite.FlipH = FaceLeft;
    }
    public void Reloading() 
    {
    }
    public void Shooting() 
    {
    }
    public void Movement() 
    {
        if (Input.IsActionPressed("Down"))
        {
            Entity.Velocity += new Vector2(0, 1);
            isMoving = true;
        }
        if (Input.IsActionPressed("Up"))
        {
            Entity.Velocity += new Vector2(0, -1);
            isMoving = true;
        }
        if (Input.IsActionPressed("Left"))
        {
            Entity.Velocity += new Vector2(-1, 0);
            isMoving = true;
            FaceLeft = true;
        }
        if (Input.IsActionPressed("Right"))
        {
            Entity.Velocity += new Vector2(1, 0);
            isMoving = true;
            FaceLeft = false;
        }
    }
}

