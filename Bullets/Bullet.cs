using Godot;

public class Bullet : Node2D
{
    private float time = 0.0f;
    private Vector2 startPosition = Vector2.Zero;
    private IBulletController controller;

    public override void _Process(float delta)
    {
        time += delta;
        Position = startPosition + Transform.BasisXform(controller.GetPosition(time));
    }

    public Bullet Configure(Vector2 position, Vector2 direction, IBulletController controller)
    {
        this.controller = controller;

        SetAsToplevel(true);

        startPosition = position;
        GlobalPosition = startPosition;

        Rotation = direction.Angle();

        return this;
    }

    public void OnArea2DEntered(Area2D other)
    {
        QueueFree();
    }
}
