using Godot;
using System;

public class Ball : KinematicBody2D
{
    // Declare member variables here. Examples:
    Vector2 screenSize;

    [Export] float speed = 300;

    Vector2 velocity = new Vector2();

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        screenSize = GetViewport().Size;
        velocity = new Vector2(0, speed).Rotated(Rotation);
    }

    public override void _Process(float delta)
    {

    }

    public override void _PhysicsProcess(float delta)
    {
        var collision = MoveAndCollide(velocity * delta);

        if (collision != null)
        {
            velocity = velocity.Bounce(collision.Normal);
        }
        
        if (Position.x > screenSize.x || Position.x < 0 || Position.y > screenSize.y + 100)
        {
           Position = new Vector2(100,100);
        }
		    
    }
}
