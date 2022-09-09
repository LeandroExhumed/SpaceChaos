using System;
using UnityEngine;

namespace LeandroExhumed.SpaceChaos.Session
{
    public class SessionView : MonoBehaviour
    {
        public event Action OnUpdate;

        [SerializeField]
        private GameObject successMessage;

        public void SetSuccessMessageActive (bool value) => successMessage.SetActive(value);

        private void Update ()
        {
            OnUpdate?.Invoke();
        }
    }
}