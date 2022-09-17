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
        private Renderer[] renderers;
        [SerializeField]
        private new Collider collider;
        [SerializeField]
        private TrailRenderer[] thrustersFire;
        [SerializeField]
        private GameObject thrusterFire;

        [SerializeField]
        private GameObject explosion;

        [Header("Respawn")]
        [SerializeField]
        private int timesToBlink = 3;
        [SerializeField]
        private float blinkInterval = 0.5f;

        private int timesBlinked = 0;

        public void ClearThrustersFire ()
        {
            for (int i = 0; i < thrustersFire.Length; i++)
            {
                thrustersFire[i].Clear();
            }
        }

        public void SetColliderActive (bool value) => collider.enabled = value;

        public void DisableMeshes ()
        {
            for (int i = 0; i < renderers.Length; i++)
            {
                SetRenderersActive(false);
            }
        }

        public void PlayExplosionVFX ()
        {
            Instantiate(explosion, transform.position, explosion.transform.rotation);
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
            for (int i = 0; i < renderers.Length; i++)
            {
                renderers[i].enabled = value;
            }
        }

        private IEnumerator RespawnBlinkingRoutine ()
        {
            WaitForSeconds interval = new(blinkInterval);
            while (timesBlinked < timesToBlink)
            {
                SetRenderersActive(true);
                yield return interval;
                SetRenderersActive(false);
                yield return interval;
                timesBlinked++;

                yield return null;
            }

            SetRenderersActive(true);
            timesBlinked = 0;
            OnInvencibleBlinkinhEffectOver?.Invoke();
        }
    }
}