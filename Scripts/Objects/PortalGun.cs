using Godot;
using System;


namespace Portal2_5D.Scripts.Objects;
public partial class PortalGun : Node3D
{
	[ExportGroup("Required Nodes")]	
	[Export]
	public GameSharedEvents SharedEvents { get; private set; }
	[Export]
	public Node3D LaunchPoint { get; private set; }
	
	private PortalType _portalType;



    // Game Loop Methods---------------------------------------------------------------------------

    public override void _Ready()
    {
        SharedEvents.OnPrimaryAction += PlayerInput_OnPrimaryAction;
        SharedEvents.OnSeconderyAction += PlayerInput_OnSeconderyAction;
    }

    public override void _ExitTree()
    {
        SharedEvents.OnPrimaryAction -= PlayerInput_OnPrimaryAction;
        SharedEvents.OnSeconderyAction -= PlayerInput_OnSeconderyAction;
    }
    // Mebmer Methods------------------------------------------------------------------------------

    public void ShootPortal(PortalType portalType)
	{
		// RayCastOrigin.
	}

	// Signal Methods------------------------------------------------------------------------------
	private void PlayerInput_OnPrimaryAction()
	{
		GD.Print("primary attack is pressed");
		_portalType = PortalType.Blue;
		ShootPortal(_portalType);
	}

	private void PlayerInput_OnSeconderyAction()
	{
		GD.Print("secondary attack is pressed");
		_portalType = PortalType.Orange;
		ShootPortal(_portalType);
	}
}
