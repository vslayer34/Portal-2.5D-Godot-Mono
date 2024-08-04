using Godot;

namespace Portal2_5D.Scripts.Helper;
public partial class GameSharedResources : Resource
{
    /// <summary>
    /// Reference to the camera in the game scene
    /// </summary>
    /// <value></value>
    public Camera3D Camera { get; set; }

    public GameManager GameManager { get; set; }
}