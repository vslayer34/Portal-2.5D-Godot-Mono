using Godot;
using Portal2_5D.Scripts.Objects;
using PortalD2.D.Scripts.Objects;
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

	[Export]
	public PackedScene[] PortalsScenes { get; private set; }


	private const int POOL_COUNT = 4;



    // Game Loop Methods---------------------------------------------------------------------------

    public override void _Ready()
    {
        SetProjectilePool();
		SetPortalsPool();
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

			SharedPool.AddToPool<PortalProjectile>(newProjectile, SharedPool.PortalProjectilesPool);
		}
	}
	
	
	/// <summary>
	/// Add the portals to the portals pool in the shared pool resource
	/// </summary>
	private void SetPortalsPool()
	{
		Portal newPortal;

		foreach (var portal in PortalsScenes)
		{
			newPortal = portal.Instantiate() as Portal;

			SharedResources.GameManager.CallDeferred(MethodName.AddChild, newPortal);
			SharedPool.AddToPool<Portal>(newPortal, SharedPool.AvailablePortals);
		}
	}
}
