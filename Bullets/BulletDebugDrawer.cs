using Godot;

public class BulletDebugDrawer : Node2D
{
    [Export]
    private float length = 30.0f;

    private Color color = new Color(0.0f, 0.0f, 1.0f, 1.0f);
    private Vector2[] polygon;

    public override void _Ready()
    {
        polygon = new Vector2[3];
        polygon[0] = new Vector2(Vector2.Right * length);
        polygon[1] = polygon[0] + Vector2.Right.Rotated(Mathf.Deg2Rad(180.0f - 45.0f)) * (length / 5.0f);
        polygon[2] = polygon[0] + Vector2.Right.Rotated(Mathf.Deg2Rad(180.0f + 45.0f)) * (length / 5.0f);
    }

    public override void _Draw()
    {
        DrawLine(Vector2.Zero, Vector2.Right * length, color, 2.0f);
        DrawColoredPolygon(polygon, color);
    }
}
