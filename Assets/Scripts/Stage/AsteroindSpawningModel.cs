using LeandroExhumed.SpaceChaos.Enemies.Meteor;
using UnityEngine;

namespace LeandroExhumed.SpaceChaos.Stage
{
    public class AsteroindSpawningModel : IAsteroindSpawningModel
    {
        private const float SAFE_SPAWN_RADIUS = 4F;

        private float timer = 0;
        private float secondsToCheckProbability = 10;

        private readonly Camera camera;
        private readonly MeteorFacade.Factory meteorFactory;

        public AsteroindSpawningModel (Camera camera, MeteorFacade.Factory meteorFactory)
        {
            this.camera = camera;
            this.meteorFactory = meteorFactory;
        }

        public void Spawn ()
        {
            MeteorFacade meteor = meteorFactory.Create();
            meteor.Initialize(GetRandomPosition(), Quaternion.Euler(Random.value * 360, 90f, 0f));
            meteor.GetLaunched();
        }

        public void Tick ()
        {
            if (timer >= secondsToCheckProbability)
            {
                float probability = Random.value;
                if (probability >= 0.5f)
                {
                    //ufoSpawner.createUFO();
                    Debug.Log("UFO spawned");
                }

                timer = 0;
            }

            timer += Time.deltaTime;
        }

        private Vector3 GetRandomPosition ()
        {
            Vector3 randomPosition;

            do
            {
                float positionInX = Random.Range(0, Screen.width);
                float positionInY = Random.Range(0, Screen.height);

                randomPosition = camera.ScreenToWorldPoint(
                    new Vector3(positionInX, positionInY, camera.transform.position.z));
            } while (Physics.OverlapSphere(randomPosition, SAFE_SPAWN_RADIUS).Length > 0);

            return randomPosition;
        }
    }
}