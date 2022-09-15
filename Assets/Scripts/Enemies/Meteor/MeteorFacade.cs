using LeandroExhumed.SpaceChaos.Common;
using LeandroExhumed.SpaceChaos.Common.Damage;
using System;
using UnityEngine;
using Zenject;

namespace LeandroExhumed.SpaceChaos.Enemies.Meteor
{
    public class MeteorFacade : EnemyFacade, ILaunchableModel, ISplittableModel
    {
        public event Action<MeteorFacade> OnNewPiece
        {
            add => splitting.OnNewPiece += value;
            remove => splitting.OnNewPiece -= value;
        }
        
        private ILaunchableModel launchable;
        private IOffscreenMovementModel offscreenMovement;
        private ISplittableModel splitting;

        [Inject]
        public void Constructor (
            ILaunchableModel launchable,
            IOffscreenMovementModel offscreenMovement,
            ISplittableModel splitting,
            string instanceID,
            IDamageableModel health,
            IController controller)
        {
            Constructor(instanceID, health, controller);

            this.launchable = launchable;
            this.offscreenMovement = offscreenMovement;
            this.splitting = splitting;
        }

        public void Initialize (Vector3 position, Quaternion rotation, Collider owner = null)
        {
            launchable.Initialize(position, rotation, owner);
            offscreenMovement.Initialize();
        }

        public void GetLaunched () => launchable.GetLaunched();

        public void Split () => splitting.Split();

        public void Decrease (int timesBroken, Vector3 scale) => splitting.Decrease(timesBroken, scale);

        public class Factory : PlaceholderFactory<MeteorFacade> { }
    }
}