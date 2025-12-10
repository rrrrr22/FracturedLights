using System;
using Godot;
using Godot.Collections;
public partial class SceneInstanceCreater<[MustBeVariant] T> where T : Node
{
    public Dictionary<string, PackedScene> _scenes = new();
    public Dictionary<string, T> _scenesInstantiate = new();
    public T NewInstance(string name, Vector2 Position = default, bool ignorePosition = false)
    {
        var scene = _scenes[name].Instantiate() as T;
        if (scene is Node2D scene2D && !ignorePosition)
            scene2D.GlobalPosition = Position;
        return scene;
    }
}