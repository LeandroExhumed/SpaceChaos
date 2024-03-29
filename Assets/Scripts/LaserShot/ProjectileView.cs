﻿using System;
using UnityEngine;

namespace LeandroExhumed.SpaceChaos.Projectile
{
    public class ProjectileView : MonoBehaviour
    {
        public event Action OnUpdate;
        public event Action<Collider> OnTriggerEntered;

        private GameObject parent;

        private void Awake ()
        {
            parent = transform.parent.gameObject;
        }

        private void Update ()
        {
            OnUpdate?.Invoke();
        }

        private void OnTriggerEnter (Collider other)
        {
            OnTriggerEntered?.Invoke(other);
        }

        public void Destroy () => parent.SetActive(false);
    }
}