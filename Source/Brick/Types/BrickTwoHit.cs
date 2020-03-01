using Godot;
using System;

public class BrickTwoHit : Brick
{
    private int hitCount = 0;

    private const int MAX_HIT_COUNT = 2;

    public override void OnBrickHit()
    {
        hitCount++;

        if (hitCount == 1)
        {
            GetNode<Sprite>("Sprite").RegionRect = new Rect2(84, 8, 32, 16);
        }

        if (hitCount >= MAX_HIT_COUNT)
        {
            base.OnBrickHit();
        }
    }
}
