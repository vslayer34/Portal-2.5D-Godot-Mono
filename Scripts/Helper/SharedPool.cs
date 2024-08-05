using Godot;
using Portal2_5D.Scripts.Objects;
using System;
using System.Collections.Generic;

namespace Portal2_5D.Scripts.Helper;
public partial class SharedPool : Resource
{
	// [Export]
	public List<PortalProjectile> PortalsPool = new List<PortalProjectile>();



	// Member Methods------------------------------------------------------------------------------

	public PortalProjectile GetPortalFromPool()
	{
		GD.Print($"Number of items in the pool: {PortalsPool.Count}");
		foreach (var projectile in PortalsPool)
		{
			if (projectile.Visible == false)
			{
				SetNodeActiveState<PortalProjectile>(projectile, true);
				PortalsPool.Remove(projectile);
				return projectile;
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
	}
}
