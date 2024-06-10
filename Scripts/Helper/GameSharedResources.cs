using Godot;

namespace PortalD2.D.Scripts.Helper;
public partial class GameSharedResources :Resource
{
    /// <summary>
    /// Reference to the camera in the game scene
    /// </summary>
    /// <value></value>
    public Camera3D Camera { get; set; }   
}