using Flax.Build;

public class AURASaveKitTarget : GameProjectTarget
{
    /// <inheritdoc />
    public override void Init()
    {
        base.Init();

        // Reference the modules for game
        Modules.Add("AURASaveKit");
    }
}
