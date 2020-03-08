using Godot;
using System;

public class LevelBase : Node
{
    protected Game GameNode { get; private set; }
    protected KinematicBody2D Player { get; private set; }

    public override void _Ready()
    {
        GetNode<Node>("/root/Signals").Connect("GameLoaded", this, "Start");
    }

    private void Start()
    {
        GameNode = GetNode<Node>("/root/Game") as Game;
        GameNode.Start();
        Player = GameNode.GetNode<KinematicBody2D>("Player");
    }
}
