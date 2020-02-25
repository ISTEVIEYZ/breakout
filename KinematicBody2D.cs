using Godot;
using System;

public class KinematicBody2D : Godot.KinematicBody2D
{
    public Vector2 velocity = new Vector2();



    [Export] public int speed = 2000;

    public void GetInput()
    {
        Vector2 _screenSize = GetViewport().Size;

        LookAt(GetGlobalMousePosition());
        velocity = new Vector2();

        velocity = (new Vector2(1f, 0).Rotated(Rotation));

        velocity = velocity.Normalized() * speed;

        float width = GetNode<Sprite>("Sprite").Texture.GetSize().x;
        float height = GetNode<Sprite>("Sprite").Texture.GetSize().y;

        Position = new Vector2(x: Mathf.Clamp(Position.x, 0,  _screenSize.x - width), 0);
    }

    public override void _PhysicsProcess(float delta)
    {
        GetInput();
        Rotation = 0f;
        velocity.y = 0f;
        velocity = MoveAndSlide(velocity);
        
    }
}
