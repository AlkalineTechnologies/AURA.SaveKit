using Flax.Build;

public class AURASaveKitEditorTarget : GameProjectEditorTarget
{
    /// <inheritdoc />
    public override void Init()
    {
        base.Init();

        // Reference the modules for editor
        Modules.Add("AURASaveKit");
        Modules.Add("AURASaveKitEditor");
    }
}
