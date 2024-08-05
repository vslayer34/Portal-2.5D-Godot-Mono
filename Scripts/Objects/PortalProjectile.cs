using Godot;
using Portal2_5D.Scripts.Helper;
using System;

namespace Portal2_5D.Scripts.Objects;
public partial class PortalProjectile : Area3D
{
	[ExportCategory("Required")]
	[Export]
	public SharedPool SharedPool { get; private set; }

	[ExportCategory("")]
	
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
