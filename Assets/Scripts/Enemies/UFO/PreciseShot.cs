using SpaceChaos.Constants;
using SpaceChaos.Stage;
using UnityEngine;

namespace SpaceChaos.UFO {
    /// <summary>
    /// Hability to shot on the player direction.
    /// </summary>
    /// <seealso cref="UnityEngine.MonoBehaviour" />
    [AddComponentMenu("SpaceChaos/UFO/PreciseShot")]
    public class PreciseShot : AutoShoting {
        /// <summary>Target to shot in.</summary>
        private Transform target;

        /// <summary>All important data related to the stage.</summary>
        private StageData stageData;

        /// <summary>
        /// Starts this instance.
        /// </summary>
        private void Start () {
            target = GameObject.FindGameObjectWithTag(Tags.PLAYER).GetComponent<Transform>();

            improveShoting();
        }

        /// <summary>
        /// Increases shoting angle range by improving the gun speed based on how long player advances.
        /// </summary>
        public void improveShoting () {
            speed *= GameObject.FindGameObjectWithTag(Tags.STAGE_DATA).
                GetComponent<StageData>().currentStage;
        }

        /// <summary>
        /// Executes the guns rotation process.
        /// </summary>
        protected override void processRotation () {
            if (target) {
                for (int i = 0; i < guns.Length; i++) {
                    var newRotation = Quaternion.LookRotation(guns[i].position - target.position, Vector3.forward);
                    newRotation.x = 0;
                    newRotation.y = 0;
                    guns[i].rotation = Quaternion.Slerp(guns[i].rotation, newRotation, Time.deltaTime * speed);
                }
            }
        }
    } 
}