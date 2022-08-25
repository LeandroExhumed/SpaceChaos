using System;
using UnityEngine;

namespace LeandroExhumed.SpaceChaos.Enemies.Meteor
{
    public class SplittingModel : ISplittableModel
    {
        public event Action OnNewPiece;

        private int timesBroken = 0;
        private int maximumPieces = 2;

        private readonly MeteorFacade.Factory meteorFactory;

        private readonly Transform transform;

        public SplittingModel (MeteorFacade.Factory meteorFactory, Transform transform)
        {
            this.meteorFactory = meteorFactory;
            this.transform = transform;
        }

        public void Split ()
        {
            if (timesBroken < maximumPieces)
            {
                for (int i = 0; i < maximumPieces; i++)
                {
                    MeteorFacade meteor = meteorFactory.Create();
                    meteor.Initialize(transform.position, Quaternion.Euler(UnityEngine.Random.value * 360, 90f, 0f));
                    meteor.Decrease(timesBroken + 1, transform.localScale / 2);
                    meteor.GetLaunched();

                    //OnNewPiece(obj);
                }
            }
        }

        public void Decrease (int timesBroken, Vector3 scale)
        {
            this.timesBroken = timesBroken;
            transform.localScale = scale;
            //GetComponent<Damage>().increaseValue();
        }
    }
}