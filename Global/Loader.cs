using Godot;
using System;
using System.Collections.Generic;

public partial class Loader : Node
{
    public SceneInstanceCreater<Entity> Entities = new();
    public static void Init<[MustBeVariant] T>(string folderPath, ref SceneInstanceCreater<T> sic) where T : Node
    {
        var list = ResourceLoader.ListDirectory(folderPath);
        for (int i = 0; i < list.Length; i++)
            {
                if (!list[i].EndsWith(".tscn"))
                    continue;
                string name = list[i].ToSnakeCase().Replace(".tscn", "");
                GD.Print(name);
                sic._scenes[name] = ResourceLoader.Load<PackedScene>(folderPath + "/" + list[i]);
                Node node = sic.NewInstance(name, Vector2.Zero, true);
                sic._scenesInstantiate[name] = (T)node;
            }
    }
    
}
