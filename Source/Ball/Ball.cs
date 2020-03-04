using Godot;
using System;

public class Ball : RigidBody2D
{
    [Export] public float speed = 800;

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

    public override void _Process(float delta)
    {
        // Check if in reset state so we can disable physics
        if (isReset)
        {
            Position = GetStartPosition();
        }

        // Check if left click was pressed when in reset set to enable physics
        if (Input.IsActionPressed("click") && isReset)
        {
            isReset = false;
            LinearVelocity = new Vector2(0, speed);
        }
    }

    public void OnScreenExited()
    {
        QueueFree();
        ((Game)GetParent()).BallCount--;
    }

    public void OnBodyEntered(Node2D node)
    {
        if (node is Brick)
        {
            node.EmitSignal("Hit");
        }

        if (node is Player) {

            // TODO: Touch this up
            var paddleLength = node.GetNode<Sprite>("Sprite").RegionRect.Size.x;
            var ballX = Position.x;
            var playerX = node.Position.x;
            var offsetX = ballX - playerX;
            var ratio = offsetX / paddleLength;

            LinearVelocity = new Vector2(LinearVelocity.y * ratio * -1, LinearVelocity.y).Normalized() * speed;
        }
    }

    private Vector2 GetStartPosition()
    {
        return player.Position - new Vector2(0, player.GetNode<Sprite>("Sprite").RegionRect.Size.y + 10);
    }
}
