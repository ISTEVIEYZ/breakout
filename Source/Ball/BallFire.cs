using Godot;
using System;

public class BallFire : BallBase
{
    
    private Vector2 screenSize;
    private KinematicBody2D player;
    private bool isReset = true;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        Connect("body_entered", this, "OnBodyEntered");
        player = GetParent().GetNode<KinematicBody2D>("Player");
        screenSize = GetViewport().Size;
        LinearVelocity = new Vector2(0, speed);
        Position = GetStartPosition();
        isReset = ((Game)GetParent()).BallCount <= 1;
    }


    public override void OnBodyEntered(Node2D node)
    {
        if (node is Brick)
        {
            this.Bounce = 0;
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
