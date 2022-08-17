using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace LeandroExhumed.SpaceChaos.Enemies.Meteor
{
    public class SplittingModel : ISplittableModel
    {
        public event Action OnNewPiece;

        private int timesBroken = 0;
        private int maximumPieces = 2;

        public void Split ()
        {
            if (timesBroken < maximumPieces)
            {
                Quaternion randomRotation;

                for (int i = 0; i < maximumPieces; i++)
                {
                    randomRotation = Quaternion.Euler(0, 0, UnityEngine.Random.Range(0, 360));
                    //GameObject obj = Instantiate(gameObject, transform.localPosition, randomRotation);
                    //obj.GetComponent<Splitting>().decrease();

                    //OnNewPiece(obj);
                }
            }
        }

        private void Decrease ()
        {

        }
    }
}