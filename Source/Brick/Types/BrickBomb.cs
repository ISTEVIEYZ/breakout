using Godot;
using System;

public class BrickBomb : Brick
{
    public override void OnBrickHit()
    {

        var bodies = GetNode<Area2D>("Area2D").GetOverlappingBodies();

        foreach (Node2D body in bodies)
        {
            if (body is Brick)
            {
                body.QueueFree();
            }
        }
        base.OnBrickHit();
    }

}
