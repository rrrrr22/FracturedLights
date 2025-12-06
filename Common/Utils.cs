using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Godot;
using Vector2 = Godot.Vector2;

public static class Utils
{

    public struct CollisionData
    {
        public Vector2 normal;
        public Vector2 hitPosition;
        public Vector2 hitDir;
    }

    //public static LivingActor GetNearestLivingActor(this LivingActor actor, string Side) 
    //{
    //    var actors = actor.GetTree().GetNodesInGroup(Side).OfType<LivingActor>();
    //    var temp = actors.First();
    //    foreach (LivingActor a in actors)
    //    {
    //        if (a != actor && actor.GlobalPosition.DistanceSquaredTo(a.GlobalPosition) < actor.GlobalPosition.DistanceSquaredTo(temp.GlobalPosition))
    //        {
    //            temp = actor;
    //        }
    //    }
    //    return temp.GlobalPosition.DistanceTo(actor.GlobalPosition) < actor.stats.GetTotal(Resources.Actors.StatsManager.Stats.FOLLOWRANGE) ? temp : null;
    //}
    public static Entity GetNearestLivingActor(this Entity entity, string Side)
    {
        var entitys = entity.GetTree().GetNodesInGroup(Side).OfType<Entity>();
        var temp = entitys.First();
        foreach (Entity e in entitys)
        {
            if (e != entity && entity.GlobalPosition.DistanceSquaredTo(e.GlobalPosition) < entity.GlobalPosition.DistanceSquaredTo(temp.GlobalPosition))
            {
                temp = entity;
            }
        }
        return temp;
    }
    public static Node AddNewInstance(this Node n, PackedScene scene)
    {
        var newScene = scene.Instantiate();
        n.AddChild(newScene);
        return newScene;
    }
    public static Timer NewAutoTimer(this Node n, float waitTime = 1)
    {
        var timer = new Timer();
        timer.Start(waitTime);
        timer.Autostart = true;
        timer.OneShot = true;
        n.AddChild(timer);
        return timer;
    }
    public static string GetTeam(this Entity entity) => entity.IsInGroup("PlayerSided") ? "PlayerSided" : "EnemySided";
    public static string GetEnemyTeam(this Entity entity) => entity.IsInGroup("PlayerSided") ? "EnemySided" : "PlayerSided";
    public static bool IsImportantForRounds(this Entity entity) => entity.IsInGroup("IsImportantForRounds");
    public static string ToAcronym(string word)
    {
        string result = string.Concat(word.Where(c => char.IsUpper(c) || c == word.First()));
        return result.ToUpper();
    }
    public static Godot.Vector2 ToVec2(this float r)
    {
        return Godot.Vector2.FromAngle(r);
    }
    public static float MoveAndSlideSpeed(this float speed) => speed * (1f / 60 * 1000);
    public static float Add(this ref float f, float n = 1f, float maxValue = float.MaxValue) => f = Mathf.Clamp(f + n, 0, maxValue);
    public static float Subtract(this ref float f, float n = 1f, float minValue = 0) => f = Mathf.Clamp(f - n, minValue, int.MaxValue);
    public interface MouseDetection
    {
        public abstract void OnMouseEntered();
        public abstract void OnMouseExited();
    }
    public static T PickRandom<T>(this T[] array) where T : class
    {
        return array[GD.RandRange(0, array.Length - 1)];
    }
}

