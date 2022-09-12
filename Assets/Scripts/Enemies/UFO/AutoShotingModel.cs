using LeandroExhumed.SpaceChaos.Common;
using UnityEngine;

namespace LeandroExhumed.SpaceChaos.Enemies.UFO
{
    public abstract class AutoShotingModel : IAutoShotingModel
    {
        private float timer = 0;
        private float shotingRate = 1;

        protected readonly float gunRotationSpeed;

        protected readonly Transform[] guns;

        private readonly IShooterModel shooter;

        public AutoShotingModel (float gunRotationSpeed, Transform[] guns, IShooterModel shooter)
        {
            this.gunRotationSpeed = gunRotationSpeed;
            this.guns = guns;
            this.shooter = shooter;
        }

        public void Tick ()
        {
            Rotate();

            if (timer >= shotingRate)
            {
                timer = 0;
                Shot();
            }

            timer += Time.deltaTime;
        }

        protected virtual void Shot ()
        {
            shooter.Shot();
        }

        protected abstract void Rotate ();
    }
}