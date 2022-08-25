using UnityEngine;

namespace LeandroExhumed.SpaceChaos.Common
{
    public interface ILaunchableModel
    {
        void Initialize (Vector3 position, Quaternion rotation, Collider owner = null);
        void GetLaunched ();
    }
}