using UnityEngine;

namespace LeandroExhumed.SpaceChaos.Stage
{
    public class StageView : MonoBehaviour
    {
        [SerializeField]
        private GameObject successMessage;

        public void SetSuccessMessageActive (bool value) => successMessage.SetActive(value);
    }
}