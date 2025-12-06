using System;
using Godot;

[GlobalClass]
public partial class Strategy : Resource
{
    [Export] public Texture2D Texture { get; set; }
    [Export] public string DisplayName { get; set; }
    [Export] public string Description { get; set; }
    
}