using UnityEngine;

namespace LeandroExhumed.SpaceChaos.Session
{
    public class SessionView : MonoBehaviour
    {
        [SerializeField]
        private GameObject successMessage;

        public void SetSuccessMessageActive (bool value) => successMessage.SetActive(value);
    }
}