using Godot;
using System;

public class Ball : KinematicBody2D
{
    // Declare member variables here. Examples:
    Vector2 screenSize;

    KinematicBody2D Player;

    private bool isReset = true;

    [Export] float speed = 300;

    Vector2 velocity = new Vector2();

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        Player = GetParent().GetNode<KinematicBody2D>("Player");
        screenSize = GetViewport().Size;
        velocity = Vector2.Zero;

        GD.Print(GetParent().GetNode<StaticBody2D>("Brick2").Position);
        Position = Player.Position - new Vector2(0, Player.GetNode<Sprite>("Sprite").Texture.GetWidth());
    }

    public override void _PhysicsProcess(float delta)
    {
        var collision = MoveAndCollide(velocity * delta);

        if (collision != null)
        {
            if (collision.Collider is Brick)
            {
                collision.Collider.EmitSignal("Hit");
            }

            velocity = velocity.Bounce(collision.Normal);
        }

        if (Position.x > screenSize.x || Position.x < 0 || Position.y > screenSize.y + 100)
        {
            velocity = Vector2.Zero;
            isReset = true;

        }

        if (isReset)
        {
            GetNode<CollisionShape2D>("CollisionShape2D").Disabled = true;
            Position = Player.Position - new Vector2(0, Player.GetNode<Sprite>("Sprite").Texture.GetWidth());
        }

    }

    public override void _Process(float delta)
    {
        if (Input.IsActionPressed("click") && isReset)
        {
            velocity = new Vector2(0, speed).Rotated(Rotation);
            isReset = false;
            GetNode<CollisionShape2D>("CollisionShape2D").Disabled = false;
        }
    }
}
