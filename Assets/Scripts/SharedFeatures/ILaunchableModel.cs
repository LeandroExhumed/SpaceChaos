using UnityEngine;

namespace LeandroExhumed.SpaceChaos.Common
{
    public interface ILaunchableModel
    {
        void Initialize (Vector3? position = null, Quaternion? rotation = null, Collider owner = null);
        void GetLaunched ();
    }
}