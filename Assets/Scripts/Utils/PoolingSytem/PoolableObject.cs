using UnityEngine;

namespace SpaceChaos.Utils.PoolingSystem {
    /// <summary>
    /// Common behaviour for objects that can be pooled.
    /// </summary>
    /// <seealso cref="UnityEngine.MonoBehaviour" />
    [AddComponentMenu("SpaceChaos/Utils/PoolingSystem/PoolableObject")]
    public class PoolableObject : MonoBehaviour {
        /// <summary>Pool where this instance is created.</summary>
        public Pool pool { get; set; }

        /// <summary>
        /// Reset some aspects of the object when reused, acting as a Start().
        /// </summary>
        public virtual void OnObjectReuse () {}

        /// <summary>
        /// 'Destroys' this object by setting it false.
        /// </summary>
        public void destroy () {
            gameObject.SetActive(false);
        } 
    } 
}