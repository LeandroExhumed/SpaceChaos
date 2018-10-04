using SpaceChaos.Constants;
using UnityEngine;

namespace SpaceChaos.UFO {
    /// <summary>
    /// Hability to move through the space using a random route.
    /// </summary>
    /// <seealso cref="UnityEngine.MonoBehaviour" />
    [AddComponentMenu("SpaceChaos/UFO/RandomRoute")]
    public class RandomRoute : MonoBehaviour, ICommand {
        /// <summary>Speed of the spaceship movement.</summary>
        [SerializeField]
        private float speed = 15;
        /// <summary>The destination that the spaceship will go.</summary>
        private Vector3 randomPosition;

        /// <summary>Limit position of game stage on X axis.</summary>
        private float stageLimitInX = 9;
        /// <summary>Limit position of game stage on Y axis.</summary>
        private float stageLimitInY = 2.5f;

        /// <summary>Event fired when this spaceship leaves the stage.</summary>
        public event System.Action onEndofRoute;

        /// <summary>
        /// Awakes this instance.
        /// </summary>
        private void Awake () {
            randomPosition = getNewDestination();
            
        }

        /// <summary>
        /// Starts this instance.
        /// </summary>
        private void Start () {
            onEndofRoute += () => GameObject.FindGameObjectWithTag(Tags.ENEMY_Manager).
                GetComponent<EnemyManager>().remove(gameObject);
        }

        /// <summary>
        /// Executes the spaceship movement through the random route.
        /// </summary>
        /// <param name="parameters">Optional parameters.</param>
        public void execute (params object[] parameters) {
            float step = speed * Time.deltaTime;

            transform.position = Vector3.MoveTowards(transform.position, randomPosition, step);

            if (Vector3.Distance(transform.position, randomPosition) <= 0) {
                if (transform.position.x == stageLimitInX) {
                    onEndofRoute();
                } else {
                    randomPosition = getNewDestination();
                }
            }
        }

        /// <summary>
        /// Return a new random destination to the route.
        /// </summary>
        /// <returns>The random destination.</returns>
        private Vector3 getNewDestination () {
            float positionInX = Random.Range(transform.position.x, stageLimitInX);
            float positionInY = Random.Range(-stageLimitInY, stageLimitInY);

            if (positionInX > (stageLimitInX - 1)) {
                positionInX = stageLimitInX;
            }

            return randomPosition = new Vector3(positionInX, positionInY, 0);
        }
    }
}