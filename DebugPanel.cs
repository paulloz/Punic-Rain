using Godot;

public class DebugPanel : CanvasLayer
{
    private Control gui;
    private Label fpsDisplay;

    public override void _Ready()
    {
        gui = GetNode<Control>("GUI");
        fpsDisplay = gui.GetNode<Label>("FPS");
    }

    public override void _Process(float delta)
    {
        if (Input.IsActionJustPressed("ui_cancel") && Input.IsKeyPressed((int)KeyList.Shift))
            gui.Visible = !gui.Visible;
    }

    public override void _PhysicsProcess(float delta)
    {
        fpsDisplay.Text = $"{Performance.GetMonitor(Performance.Monitor.TimeFps):0} fps";
    }
}
