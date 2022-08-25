using System;
using System.Collections;
using UnityEngine;

namespace LeandroExhumed.SpaceChaos.Player
{
    public class PlayerView : MonoBehaviour
    {
        public event Action OnUpdate;
        public event Action<Collider> OnCollision;
        public event Action OnInvencibleBlinkinhEffectOver;

        [SerializeField]
        private GameObject[] meshes;
        [SerializeField]
        private new Collider collider;
        [SerializeField]
        private GameObject thrusterFire;
        [SerializeField]
        private GameObject explosion;

        [Header("Respawn")]
        [SerializeField]
        private int timesToBlink = 10;
        [SerializeField]
        private float blinkInterval = 0.2f;

        private int timesBlinked = 0;

        public void SetThrusterActive (bool value) => thrusterFire.SetActive(value);

        public void SetColliderActive (bool value) => collider.enabled = value;

        public void DisableMeshes ()
        {
            for (int i = 0; i < meshes.Length; i++)
            {
                meshes[i].SetActive(false);
            }
        }

        public void PlayExplosionVFX ()
        {
            explosion.SetActive(true);
        }

        public void StartRespawnBlinking ()
        {
            StartCoroutine(RespawnBlinkingRoutine());
        }

        private void Update ()
        {
            OnUpdate?.Invoke();
        }

        private void OnTriggerEnter (Collider other)
        {
            OnCollision?.Invoke(other);
        }

        private void SetRenderersActive (bool value)
        {
            for (int i = 0; i < meshes.Length; i++)
            {
                meshes[i].SetActive(value);
            }
        }

        private IEnumerator RespawnBlinkingRoutine ()
        {
            while (timesBlinked < timesToBlink)
            {
                SetRenderersActive(false);
                yield return new WaitForSeconds(blinkInterval);
                SetRenderersActive(true);
                timesBlinked++;

                yield return null;
            }

            timesBlinked = 0;
            OnInvencibleBlinkinhEffectOver?.Invoke();
        }
    }
}