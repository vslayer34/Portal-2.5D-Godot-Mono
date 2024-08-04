using Godot;
using System;


namespace Portal2_5D.Scripts.Objects;
public partial class PortalGun : Node3D
{
	[ExportGroup("Required Nodes")]	
	[Export]
	public Node3D LaunchPoint { get; private set; }
	
	private PortalType _portalType;



	// Game Loop Methods---------------------------------------------------------------------------

	// Mebmer Methods------------------------------------------------------------------------------

	public void ShootPortal(PortalType portalType)
	{
		// RayCastOrigin.
	}
}
