using Godot;
using Portal2_5D.Scripts.Helper;


namespace PortalD2.D.Scripts.Objects;
public abstract partial class Portal : Node3D
{
    [ExportCategory("swap area")]
    [Export]
    public Area3D SwapArea { get; protected set; }


    [Export]
    public Node3D PlayerSpawnArea { get; protected set; }

    [Export]
    public SharedPool SharedPool { get; protected set; }



    // Game Loop Methods---------------------------------------------------------------------------

    public override void _EnterTree()
    {
        // SwapArea.BodyEntered += SwapArea_BodyEntered;

        // if ()
    }
    public override void _Ready()
    {
        GD.Print(SwapArea);
        SwapArea.BodyEntered += SwapArea_BodyEntered;
    }
    // Member Methods------------------------------------------------------------------------------
    // Signal Methods------------------------------------------------------------------------------

    protected virtual void SwapArea_BodyEntered(Node3D body) { }
}
