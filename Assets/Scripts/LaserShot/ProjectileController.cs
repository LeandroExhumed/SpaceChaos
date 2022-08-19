using UnityEngine;

namespace LeandroExhumed.SpaceChaos.Projectile
{
    class ProjectileController : IController
    {
        private readonly IProjectileModel model;
        private readonly ProjectileView view;

        public ProjectileController (IProjectileModel model, ProjectileView view)
        {
            this.model = model;
            this.view = view;
        }

        public void Setup ()
        {
            model.OnDestroyed += HandleDestroyed;
            view.OnTriggerEntered += HandleTriggerEntered;
        }

        private void HandleTriggerEntered (Collider collider)
        {
            model.HandleCollision(collider);
        }

        private void HandleDestroyed ()
        {
            view.Destroy();
        }

        public void Dispose ()
        {
            model.OnDestroyed -= HandleDestroyed;
            view.OnTriggerEntered -= HandleTriggerEntered;
        }
    }
}