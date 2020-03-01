using Godot;
using System;

public class Player : KinematicBody2D
{
    private Vector2 screenSize;
    private float xOffset = 10f;
    private float yOffset = 100f;

    public override void _Ready()
    {
        screenSize = GetViewport().Size;
    }

    public override void _Process(float delta)
    {
        float mouseX = GetGlobalMousePosition().x;
        Vector2 spriteSize = GetNode<Sprite>("Sprite").RegionRect.Size;

        Position = new Vector2(
            x: Mathf.Clamp(mouseX, (spriteSize.x - xOffset), (screenSize.x - spriteSize.x + xOffset)),
            y: Mathf.Clamp(Position.y, (screenSize.y - yOffset), (screenSize.y - yOffset))
        );
    }

    public void AddPowerUp(Powerup powerup)
    {
        GD.Print("asdasd");
    }
}
