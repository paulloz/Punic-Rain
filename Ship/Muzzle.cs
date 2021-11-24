using Godot;

public class Muzzle : Position2D
{
    public Bullet SpawnBullet(PackedScene bulletScene, IBulletController controller)
    {
        return bulletScene.Instance<Bullet>().Configure(
            GlobalPosition,
            GlobalTransform.BasisXform(Vector2.Right),
            controller
        );
    }
}
