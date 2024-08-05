using Godot;
using Portal2_5D.Scripts.Objects;
using PortalD2.D.Scripts.Objects;
using System.Collections.Generic;

namespace Portal2_5D.Scripts.Helper;
public partial class SharedPool : Resource
{
	// [Export]
	public List<PortalProjectile> PortalProjectilesPool = new List<PortalProjectile>();

	public List<Portal> AvailablePortals { get; set; } = new List<Portal>();

	public BluePortal BluePortal { get; set; }
	public OrangePortal OrangePortal { get; set; }



	// Member Methods------------------------------------------------------------------------------

	public PortalProjectile GetPortalProjectileFromPool()
	{
		GD.Print($"Number of items in the pool: {PortalProjectilesPool.Count}");
		foreach (var projectile in PortalProjectilesPool)
		{
			if (projectile.Visible == false)
			{
				SetNodeActiveState<PortalProjectile>(projectile, true);
				PortalProjectilesPool.Remove(projectile);
				return projectile;
			}
		}

		GD.PrintErr("Can't fetch from the pool");
		return null;
	}


	public Portal GetPortalFromPool(PortalType portalType)
	{
		foreach (var portal in AvailablePortals)
		{
			if (portalType == PortalType.Blue && portal is BluePortal bluePortal)
			{
				SetNodeActiveState<Portal>(portal, true);
				portal.Position = Vector3.Zero;
				// AvailablePortals.Remove(portal);
				return bluePortal;
			}
			else if (portalType == PortalType.Orange && portal is OrangePortal orangePortal)
			{
				SetNodeActiveState<Portal>(portal, true);
				portal.Position = Vector3.Zero;
				// AvailablePortals.Remove(portal);
				return orangePortal;
			}
		}

		GD.PrintErr("Can't fetch from the pool");
		return null;
	}

	


	/// <summary>
	/// Deactivate the node and add it to the pool
	/// </summary>
	/// <typeparam name="T">Node3D node</typeparam>
	/// <param name="node">The object to be stored</param>
	/// <param name="pool">The pool where the object is stored</param>
	public void AddToPool<T>(T node, List<T> pool) where T : Node3D
	{
		SetNodeActiveState<T>(node, false);
		pool.Add(node);
	}


	private void SetNodeActiveState<T>(T node, bool isActive) where T : Node3D
	{
		node.Visible = isActive;
		node.SetProcess(isActive);
		node.SetPhysicsProcess(isActive);
		
		if (!isActive)
		{
			node.ProcessMode = Node.ProcessModeEnum.Disabled;
		}
		else
		{
			node.ProcessMode = Node.ProcessModeEnum.Inherit;
		}
	}
}
