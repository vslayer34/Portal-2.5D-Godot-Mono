using Godot;
using Portal2_5D.Scripts.Objects;
using System;

namespace Portal2_5D.Scripts.Helper;
public partial class PoolManager : Node
{
	[ExportGroup("Required")]
	[Export]
	public GameSharedResources SharedResources { get; private set; }

	[Export]
	public SharedPool SharedPool { get; private set; }

	[ExportGroup("")]

	[ExportCategory("Packed scenes")]
	[Export]
	public PackedScene PortalProjectileScene { get; private set; }

	private const int POOL_COUNT = 4;



    // Game Loop Methods---------------------------------------------------------------------------

    public override void _Ready()
    {
        SetProjectilePool();
    }
    // Member Methods------------------------------------------------------------------------------


	/// <summary>
	/// Add portal projectiles to the scene and set their visibility to false for later use
	/// </summary>
	private void SetProjectilePool()
	{
		PortalProjectile newProjectile;

		for (int i = 0; i < POOL_COUNT; i++)
		{
			newProjectile = PortalProjectileScene.Instantiate() as PortalProjectile;
			// SharedResources.GameManager.AddChild(newProjectile);
			newProjectile.Name = $"PortalProjectil@{i}";
			// DeactivateNode<PortalProjectile>(newProjectile);
			SharedResources.GameManager.CallDeferred(MethodName.AddChild, newProjectile);

			SharedPool.AddToPool<PortalProjectile>(newProjectile, SharedPool.PortalsPool);
		}
	}


	/// <summary>
	/// Deactivate the node before storing it in the pool
	/// </summary>
	private void DeactivateNode<T>(T node) where T : Node3D
	{
		node.Visible = false;
		node.SetProcess(false);
		node.SetPhysicsProcess(false);
	}
}
