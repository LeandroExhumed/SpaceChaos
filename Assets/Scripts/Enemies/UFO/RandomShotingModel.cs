using LeandroExhumed.SpaceChaos.Common;
using UnityEngine;

namespace LeandroExhumed.SpaceChaos.Enemies.UFO
{
    public class RandomShotingModel : AutoShotingModel
    {
        private float gunsDirection;

        public RandomShotingModel (
            UFOData data,
            Transform[] guns,
            IShooterModel shooter) : base (data, guns, shooter) { }

        protected override void Rotate ()
        {
            for (int i = 0; i < guns.Length; i++)
            {
                guns[i].Rotate(0, -gunsDirection * data.GunRotationSpeed * Time.deltaTime, 0);
            }
        }

        /// <summary>
        /// Executes the shot.
        /// </summary>
        protected override void Shot ()
        {
            base.Shot();
            gunsDirection = getRandomDirection();
        }

        private float getRandomDirection ()
        {
            return Random.Range(0, 360);
        }
    }
}