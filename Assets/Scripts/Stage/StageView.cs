using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace LeandroExhumed.SpaceChaos.Stage
{
    public class StageView : MonoBehaviour
    {
        [SerializeField]
        private GameObject successMessage;

        public void SetSuccessMessageActive (bool value) => gameObject.SetActive(value);
    }
}