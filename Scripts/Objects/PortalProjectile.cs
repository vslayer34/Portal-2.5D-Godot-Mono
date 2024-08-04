using Godot;
using System;

public partial class PortalProjectile : Area3D
{
	[ExportGroup("Required Materials")]
	[Export]
	public MeshInstance3D ProjectileMaterial { get; private set; }

	



	// Game Loop Methods---------------------------------------------------------------------------
	// Memeber Methods-----------------------------------------------------------------------------
	/// <summary>
	/// Set the type of the portal projectile at launch
	/// </summary>
	private void SetPortalType()
	{

	}
}
