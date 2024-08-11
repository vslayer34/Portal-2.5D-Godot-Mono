using Godot;
using Portal2_5D.Scripts.Helper;
using System;


namespace Portal2_5D.Scripts.Objects;
public partial class PortalGun : Node3D
{
	[ExportGroup("Required Nodes")]
	[Export]
	public GameSharedEvents SharedEvents { get; private set; }

	[Export]
	public SharedPool SharedPool { get; private set; }


	[Export]
	public Node3D LaunchPoint { get; private set; }

	[Export]
	public GpuParticles3D PortalFormationParticle { get; private set; }

	[Export]
	public StandardMaterial3D PortalGunParticleMaterial { get; private set; }
	
	private PortalType _portalType;
	private PortalProjectile _newProjectile;



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

    public async void ShootPortal(PortalType portalType)
	{
		const float PORTAL_FORMATION_TIME = 0.5f;

		if (portalType == PortalType.Orange)
		{
			PortalGunParticleMaterial.AlbedoColor = Colors.Orange;
		}
		else
		{
			PortalGunParticleMaterial.AlbedoColor = Colors.Blue;
		}
		PortalFormationParticle.Emitting = true;
		await ToSignal(GetTree().CreateTimer(PORTAL_FORMATION_TIME), Timer.SignalName.Timeout);
		// RayCastOrigin.
		_newProjectile = SharedPool.GetPortalProjectileFromPool();
		_newProjectile.SetPortalType(portalType);

		_newProjectile.GlobalTransform = LaunchPoint.GlobalTransform;
		
		// switch (_portalType)
		// {
		// 	case PortalType.Blue:
		// 		_newProjectile.SetPortalType(PortalType.Blue);
		// 		break;
			
		// 	case PortalType.Orange:
		// 		_newProjectile.SetPortalType(PortalType.Orange);
		// 		break;
			
		// 	default:
		// 		GD.Print("There's no such type for the portals");
		// 		break;
		// }
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
