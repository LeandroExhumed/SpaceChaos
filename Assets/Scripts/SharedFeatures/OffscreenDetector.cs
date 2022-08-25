using System;
using UnityEngine;

namespace LeandroExhumed.SpaceChaos.Common
{
    public class OffscreenDetector : MonoBehaviour
    {
        public event Action OnOffscreen;

        private void OnBecameInvisible ()
        {
            OnOffscreen?.Invoke();
        }
    }
}