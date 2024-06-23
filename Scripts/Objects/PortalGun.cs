using Godot;
using System;

public partial class PortalGun : Node3D
{
	[ExportGroup("Required Nodes")]	
	[Export]
	public Node3D LaunchPoint { get; private set; }



	// Game Loop Methods---------------------------------------------------------------------------

	// Mebmer Methods------------------------------------------------------------------------------

	public void ShootPortal()
	{
		// RayCastOrigin.
	}
}
