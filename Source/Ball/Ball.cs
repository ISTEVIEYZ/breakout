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
        player = GetParent().GetNode<KinematicBody2D>("Player");
        screenSize = GetViewport().Size;
        LinearVelocity = new Vector2(0, speed);
        Position = GetPlayerPosition();
    }

    public override void _Process(float delta)
    {
        // Check collisions
        var collisionBodies = GetCollidingBodies();
        foreach (Node2D body in collisionBodies)
        {
            if (body is Brick)
            {
                body.EmitSignal("Hit");
            }
        }

        // Check if in reset state so we can disable physics
        if (isReset)
        {
            Position = GetPlayerPosition();
            GetNode<CollisionShape2D>("CollisionShape2D").SetDeferred("Disabled", true);
        }

        // Check if left click was pressed when in reset set to enable physics
        if (Input.IsActionPressed("click") && isReset)
        {
            isReset = false;
            LinearVelocity = new Vector2(0, speed);
            GetNode<CollisionShape2D>("CollisionShape2D").SetDeferred("Disabled", false);
        }
    }

    public void OnScreenExited()
    {
        isReset = true;
    }

    private Vector2 GetPlayerPosition()
    {
        return player.Position - new Vector2(0, player.GetNode<Sprite>("Sprite").RegionRect.Size.y + 10);
    }
}
