using Godot;
using System;

public class BrickMoveHorizontal : Brick
{
    public override void _Process(float delta)
    {
        Position = new Vector2(0, 2);
    }
}
