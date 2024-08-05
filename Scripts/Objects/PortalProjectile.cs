using Godot;
using Portal2_5D.Scripts.Helper;
using System;

namespace Portal2_5D.Scripts.Objects;
public partial class PortalProjectile : Area3D
{
	[ExportCategory("Required")]
	[Export]
	public SharedPool SharedPool { get; private set; }

	[Export]
	public Timer DisableSelfTimer { get; private set; }

	[ExportCategory("")]
	
	[ExportGroup("Required Materials")]
	[Export]
	public MeshInstance3D ProjectileMaterial { get; private set; }

	private PortalType _portalType;

	private const float SPEED = 10.0f;



    // Game Loop Methods---------------------------------------------------------------------------

    public override void _Ready()
    {
        DisableSelfTimer.Timeout += DisableSelfTimer_Timeout;
		BodyEntered += Projectile_BodyEntered;
    }

    public override void _PhysicsProcess(double delta)
    {
        base._PhysicsProcess(delta);
		
		// The -1 because forward is (0, 0, -1)
		Translate(Vector3.Forward * -1 * SPEED * (float)delta);
    }
    // Memeber Methods-----------------------------------------------------------------------------

    /// <summary>
    /// Set the type of the portal projectile at launch
    /// </summary>
    public void SetPortalType(PortalType portalType)
	{
		_portalType = portalType;
		DisableSelfTimer.Start();
		// GlobalPosition
	}

	// Signal Methods------------------------------------------------------------------------------

	private void DisableSelfTimer_Timeout()
	{
		SharedPool.AddToPool(this, SharedPool.PortalProjectilesPool);
	}

	private void Projectile_BodyEntered(Node3D area)
	{
		if (area is PortableWall wall)
		{
			GD.Print("Hit a portable wall");
		}
	}
}
