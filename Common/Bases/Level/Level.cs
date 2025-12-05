using Godot;
using System;

public partial class Level : Node2D
{
    [Export] public Camera2D Camera { get; set; }
    public Entity CameraTarget { get; set; }
    public Entity Player { get; set; }
    //temp camera
    public override void _PhysicsProcess(double delta)
    {
        if(Camera != null && Player != null && Player.IsAlive)
        {
            Camera.Position = Player.Position;
        }
    }
}
