using Godot;
using System;

public partial class GameManager : Node
{
    public Camera2D Camera { get; set; }
    public Entity CameraTarget { get; set; }
    public Entity Player { get; set; }

    public override void _Ready()
    {
        base._Ready();
        EnterNewLevel(-1);
    }

    public void EnterNewLevel(int stage)
    {

    }

}
