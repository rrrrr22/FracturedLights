using Godot;
using System;
using System.ComponentModel;
using System.Linq;
public partial class State : Node
{
    [Signal] public delegate void ChangeStateEventHandler(State state, string nextState);
    protected int stateTimer { get; set;} = 0;
    protected Entity Target { get; set;}
    protected Entity Entity { get; set;}
    [Export] public string stateAnimation { get; set;}
    [Export] public bool freezeStateAnimation { get; set;}
    public override void _Ready()
    {
        Entity = GetOwner<Entity>();
    }
    public void UpdateSpriteDir() 
    {
        if (Entity.Velocity.X > 0)
            Entity.Sprite.FlipH = false;
        if (Entity.Velocity.X < 0)
            Entity.Sprite.FlipH = true;
    }
    public void PlayStateAnimation() 
    {
        Entity.Sprite.Play(stateAnimation);
        Entity.Sprite.Frame = 0;
        if (freezeStateAnimation)
             Entity.Sprite.Pause();
    }
    public virtual void CheckIfIsDead() 
    {
        if(Entity.IsAlive)
            return;
        if(Name != "dead")
            EmitSignal(SignalName.ChangeState,this,"dead");
    }
    public int StateTimer 
    {
        get { return stateTimer; }
        set { stateTimer = value; }    
    }
    public virtual void OnEntered() { }
    public virtual void Process(double delta) { }
    public virtual void OnExited() { }
}
