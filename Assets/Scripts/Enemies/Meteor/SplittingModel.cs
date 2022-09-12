using System;
using UnityEngine;

namespace LeandroExhumed.SpaceChaos.Enemies.Meteor
{
    public class SplittingModel : ISplittableModel
    {
        public event Action<MeteorFacade> OnNewPiece;

        private int timesBroken = 0;

        private readonly MeteorData data;
        private readonly MeteorFacade.Factory meteorFactory;

        private readonly Transform transform;

        public SplittingModel (MeteorData data, MeteorFacade.Factory meteorFactory, Transform transform)
        {
            this.data = data;
            this.meteorFactory = meteorFactory;
            this.transform = transform;
        }

        public void Split ()
        {
            if (timesBroken < data.PieceAmount)
            {
                for (int i = 0; i < data.PieceAmount; i++)
                {
                    MeteorFacade meteor = meteorFactory.Create();
                    meteor.Initialize(transform.position, Quaternion.Euler(UnityEngine.Random.value * 360, 90f, 0f));
                    meteor.Decrease(timesBroken + 1, transform.localScale / 2);
                    meteor.GetLaunched();

                    OnNewPiece?.Invoke(meteor);
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