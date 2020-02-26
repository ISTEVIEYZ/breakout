using Godot;
using System;

public class Player : KinematicBody2D
{
    public Vector2 velocity = new Vector2();
    [Export] public int speed = 2000;

    public override void _Ready()
    {
        Position = new Vector2(69,69);
    }

    public void GetInput()
    {
        Vector2 _screenSize = GetViewport().Size;

        LookAt(GetGlobalMousePosition());
        velocity = new Vector2();

        velocity = (new Vector2(1f, 0).Rotated(Rotation));

        velocity = velocity.Normalized() * speed;

        float width = GetNode<Sprite>("Sprite").Texture.GetSize().x;
        float height = GetNode<Sprite>("Sprite").Texture.GetSize().y;

        Position = new Vector2(x: Mathf.Clamp(Position.x, width / 2,  _screenSize.x - width), _screenSize.y - (height / 2));
    }

    public override void _PhysicsProcess(float delta)
    {
        GetInput();
        Rotation = 0f;
        velocity.y = 0f;
        velocity = MoveAndSlide(velocity);
        
    }
}
