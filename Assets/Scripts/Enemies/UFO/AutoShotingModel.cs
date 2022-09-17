using LeandroExhumed.SpaceChaos.Common;
using UnityEngine;

namespace LeandroExhumed.SpaceChaos.Enemies.UFO
{
    public abstract class AutoShotingModel : IAutoShotingModel
    {
        private float timer = 0;

        protected readonly Transform[] guns;

        protected readonly UFOData data;
        private readonly IShooterModel shooter;

        public AutoShotingModel (UFOData data, Transform[] guns, IShooterModel shooter)
        {
            this.data = data;
            this.guns = guns;
            this.shooter = shooter;
        }

        public void Tick ()
        {
            Rotate();

            if (timer >= data.FireRate)
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