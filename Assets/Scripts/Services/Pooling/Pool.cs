﻿using System.Collections.Generic;
using UnityEngine;

namespace LeandroExhumed.SpaceChaos.Services.Pooling
{
    public class Pool
    {
        public Transform Container
        {
            get
            {
                if (container == null)
                {
                    container = new GameObject("Pools").transform;
                }

                return container;
            }
        }

        private readonly Dictionary<Object, Queue<Object>> pools = new();

        private Transform container;


        public void AddPool (Object prefab, int size, Transform parent = null)
        {
            if (pools.ContainsKey(prefab))
            {
                return;
            }

            Queue<Object> queue = new Queue<Object>();

            for (int i = 0; i < size; ++i)
            {
                var o = Object.Instantiate(prefab);
                GameObject gameObject = GetGameObject(o);

                gameObject.transform.SetParent(parent == null ? Container : parent);
                gameObject.gameObject.SetActive(false);

                queue.Enqueue(o);
            }

            pools[prefab] = queue;
        }

        public void AddPool (Object prefab, int size, PoolableObject.Factory prefabFactory, Transform parent = null)
        {
            if (pools.ContainsKey(prefab))
            {
                return;
            }

            Queue<Object> queue = new();

            for (int i = 0; i < size; ++i)
            {
                var o = prefabFactory.Create();
                o.transform.SetParent(parent == null ? Container : parent);

                o.gameObject.SetActive(false);
                queue.Enqueue(o);
            }

            pools[prefab] = queue;
        }

        public T GetObject<T> (Object prefab) where T : Object
        {
            if (pools.TryGetValue(prefab, out Queue<Object> queue))
            {
                Object objectToReuse = queue.Dequeue();
                queue.Enqueue(objectToReuse);

                GameObject gameObject = GetGameObject(objectToReuse);
                gameObject.SetActive(true);

                if (gameObject.TryGetComponent(out PoolableObject poolableObject))
                {
                    poolableObject.Reuse();
                }

                return objectToReuse as T;
            }

            Debug.LogError("No pool was init with this prefab");
            return null;
        }

        public void Remove (Object prefab)
        {
            pools.Remove(prefab);
        }

        private GameObject GetGameObject (Object instance)
        {
            GameObject gameObject;
            if (instance is Component component)
            {
                gameObject = component.gameObject;
            }
            else
            {
                gameObject = instance as GameObject;
            }

            return gameObject;
        }
    }
}