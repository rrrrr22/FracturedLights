using Godot;
using System;
using System.Collections.Generic;
public partial class StateMachine : Node
{
    [Export] private State OnSpawnState{ get; set;}
    public State State { get; set;}
    private Dictionary<string, State> states = new Dictionary<string, State>();
    public override void _Ready()
    {
        foreach (Node child in GetChildren())
        {
            if (child is State state)
            {
                states.Add(state.Name.ToString().ToLower(), state);
                state.ChangeState += OnStateChange;
            }
        }
        if (OnSpawnState != null)
        {
            State = OnSpawnState;
            OnSpawnState.OnEntered();
        }
    }
    private void OnStateChange(State state, string nextState)
    {
        if (state != this.State)
        {
            return;
        }
        State newState = states[nextState.ToLower()];
        if (newState == null)
        {
            return;
        }
        if (this.State != null)
        {
            this.State.OnExited();
            this.State.StateTimer = 0;
        }
        newState.PlayStateAnimation();
        newState.OnEntered();
        this.State = newState;
    }
    public override void _PhysicsProcess(double delta)
    {
        if (State != null)
        {
            State.UpdateSpriteDir();
            State.Process(delta);
            State.StateTimer++;
            State.CheckIfIsDead();
        }
    }
}
