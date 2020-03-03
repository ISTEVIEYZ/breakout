using Godot;
using System;

public class BrickMoveHorizontal : Brick
{
    [Export] public Vector2 InitialDirection;

    public override void _Ready()
    {
        InitialDirection = InitialDirection == Vector2.Zero ? new Vector2(2, 0) : InitialDirection;
    }

    public override void _Process(float delta)
    {
        KinematicCollision2D colliders = MoveAndCollide(InitialDirection);

        if (colliders != null)
        {
            InitialDirection.x = -InitialDirection.x;
        }
    }
}
