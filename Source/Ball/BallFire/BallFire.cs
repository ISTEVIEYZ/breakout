using Godot;
using System;

public class BallFire : BallBase
{
    private KinematicBody2D player;

    public override void _Ready()
    {
        Connect("body_entered", this, "OnBodyEntered");

        player = GetParent().GetNode<KinematicBody2D>("Player");
        LinearVelocity = new Vector2(0, speed);
        Position = GetStartPosition();
    }

    public override void OnBodyEntered(Node2D node)
    {
        if (node is Brick)
        {
            node.EmitSignal("Hit");
        }

        if (node is Player)
        {
            this.OnPlayerHit(node);
        }
    }

    private Vector2 GetStartPosition()
    {
        return player.Position - new Vector2(0, player.GetNode<Sprite>("Sprite").RegionRect.Size.y + 10);
    }
}
