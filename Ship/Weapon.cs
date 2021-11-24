using System.Linq;
using Godot;

public class Weapon : Node2D
{
    [Export]
    private PackedScene bulletScene;

    private Timer cooldown;
    private Muzzle[] muzzles;

    public override void _Ready()
    {
        cooldown = GetNode<Timer>("Cooldown");
        muzzles = GetChildren().OfType<Muzzle>().ToArray();
    }

    public bool CanShoot()
    {
        return cooldown.IsStopped();
    }

    public void Shoot(IBulletController controller)
    {
        if (!CanShoot()) { return; }

        foreach (Muzzle muzzle in muzzles)
            AddChild(muzzle.SpawnBullet(bulletScene, controller));
        cooldown.Start();
    }

    public void OnCooldownTimeout()
    {
        cooldown.Stop();
    }
}
