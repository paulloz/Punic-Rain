using Godot;

public interface IBulletController
{
    Vector2 GetPosition(float t);
}

public class LinearBulletController : IBulletController
{
    private float speed;

    public LinearBulletController(float speed)
    {
        this.speed = speed;
    }

    public Vector2 GetPosition(float t)
    {
        float x = GetX(t);
        return new Vector2(x, GetY(x));
    }

    protected float GetX(float t)
    {
        return t * speed;
    }

    protected virtual float GetY(float x)
    {
        return 0.0f;
    }
}

public class WaveBulletController : LinearBulletController
{
    private float amplitude;
    private float frequency;

    public WaveBulletController(float speed, float amplitude, float frequency) : base(speed)
    {
        this.amplitude = amplitude;
        this.frequency = frequency;
    }

    protected override float GetY(float x)
    {
        return Mathf.Sin(frequency * x) * amplitude;
    }
}
