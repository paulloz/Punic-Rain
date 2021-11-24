using Godot;

public class Muzzle : Position2D
{
    [Export]
    private PackedScene bulletScene;

    private Timer cooldown;

    public override void _Ready()
    {
        cooldown = GetNode<Timer>("Cooldown");
    }

    public bool CanShoot()
    {
        return cooldown.IsStopped();
    }

    public void Shoot(IBulletController controller)
    {
        if (!CanShoot()) { return; }

        SpawnBullet(Vector2.Right, controller);
        cooldown.Start();
    }

    private void SpawnBullet(Vector2 direction, IBulletController controller)
    {
        Bullet bullet = bulletScene.Instance<Bullet>().Configure(
            GlobalPosition,
            GlobalTransform.BasisXform(direction),
            controller
        );
        AddChild(bullet);
    }

    public void OnCooldownTimeout()
    {
        cooldown.Stop();
    }
}
