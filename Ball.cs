using Godot;
using System;

public class Ball : RigidBody2D
{
    // Declare member variables here. Examples:
    Vector2 screenSize;
    Vector2 startPosition;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        screenSize = GetViewport().Size;
        startPosition = Position;
    }

    public override void _Process(float delta)
    {

    }
    public override void _IntegrateForces(Physics2DDirectBodyState state)
    {
        if (Position.x > screenSize.x || Position.x < 0 || Position.y > screenSize.y + 100)
        {
            state.LinearVelocity = new Vector2(Mathf.Clamp(state.LinearVelocity.x, 5, 10), Mathf.Clamp(state.LinearVelocity.y, 5, 10));
            state.Transform = new Transform2D(0, startPosition);
        }

    }
}
