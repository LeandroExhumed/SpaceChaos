using LeandroExhumed.SpaceChaos.Common;
using UnityEngine;

namespace LeandroExhumed.SpaceChaos.Enemies.UFO
{
    public class PreciseShotingModel : AutoShotingModel
    {
        private readonly Transform target;

        public PreciseShotingModel (
            Transform target,
            UFOData data,
            Transform[] guns,
            IShooterModel shooter) : base(data, guns, shooter)
        {
            this.target = target;
        }

        protected override void Rotate ()
        {
            if (target)
            {
                for (int i = 0; i < guns.Length; i++)
                {
                    var newRotation = Quaternion.LookRotation(target.position - guns[i].position, Vector3.forward);
                    guns[i].rotation = Quaternion.Slerp(
                        guns[i].rotation, newRotation, Time.deltaTime * data.GunRotationSpeed);
                }
            }
        }
    }
}