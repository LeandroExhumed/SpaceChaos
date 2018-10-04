using System.Collections.Generic;
using UnityEngine;

namespace SpaceChaos.Utils.PoolingSystem {
    /// <summary>
    /// Pooling system for reutilizing instances.
    /// </summary>
    public class Pool {
        /// <summary>Queue containing all the pool instances.</summary>
        Queue<PoolableObject> poolQueue = new Queue<PoolableObject>();

        /// <summary>
        /// Initializes a new instance of the <see cref="Pool"/> class.
        /// </summary>
        /// <param name="prefab">The prefab to instantiate.</param>
        /// <param name="poolSize">Size of the pool.</param>
        public Pool (PoolableObject prefab, int poolSize) {
            GameObject objectContainer = new GameObject("PoolableObjects");
            for (int i = 0; i < poolSize; i++) {
                PoolableObject newObject = Object.Instantiate(prefab) as PoolableObject;
                newObject.pool = this;
                newObject.transform.SetParent(objectContainer.transform);
                newObject.gameObject.SetActive(false);

                poolQueue.Enqueue(newObject);
            }
        }

        /// <summary>
        /// Get a instance of the object by reusing from the pool.
        /// </summary>
        /// <param name="position">The position.</param>
        /// <param name="rotation">The rotation.</param>
        /// <returns></returns>
        public PoolableObject reuse (Vector3 position, Quaternion rotation) {
            PoolableObject objectToReuse = poolQueue.Dequeue();
            poolQueue.Enqueue(objectToReuse);

            objectToReuse.gameObject.SetActive(true);
            objectToReuse.transform.position = position;
            objectToReuse.transform.rotation = rotation;

            objectToReuse.OnObjectReuse();

            return objectToReuse;
        }
    } 
}