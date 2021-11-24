using System.Linq;
using Godot;

public class Ship : Node2D
{
    [Export]
    private float baseSpeed;

    [Export]
    private float slowModeMultiplier;

    private IBulletController controller;
    private Weapon weapon;

    public override void _Ready()
    {
        controller = new LinearBulletController(750.0f);
        weapon = GetNode<Weapon>("Weapon");
    }

    public override void _PhysicsProcess(float delta)
    {
        Position += GetDirection() * GetSpeed() * delta;

        if (Input.IsActionPressed("shoot") && weapon.CanShoot())
            weapon.Shoot(controller);
    }

    private float GetSpeed()
    {
        return baseSpeed * (Input.IsActionPressed("slow") ? slowModeMultiplier : 1.0f);
    }

    private static Vector2 GetDirection()
    {
        return Input.GetVector("move_left", "move_right", "move_up", "move_down");
    }
}