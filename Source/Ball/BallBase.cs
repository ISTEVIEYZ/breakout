using Godot;
using System;

public abstract class BallBase : RigidBody2D, Ball
{
    [Export] public float speed = 800;

    public abstract void OnBodyEntered(Node2D node);

    public void OnScreenExited()
    {
        QueueFree();
        (GetParent() as Game).BallCount--;
    }

    protected void OnPlayerHit(Node2D node)
    {
        var paddleLength = node.GetNode<Sprite>("Sprite").RegionRect.Size.x;
        var ballX = Position.x;
        var playerX = node.Position.x;
        var offsetX = ballX - playerX;
        var ratio = offsetX / paddleLength;

        LinearVelocity = new Vector2(LinearVelocity.y * ratio * -1, LinearVelocity.y).Normalized() * speed;
    }
}
