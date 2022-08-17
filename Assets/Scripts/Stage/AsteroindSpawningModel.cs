using UnityEngine;

namespace LeandroExhumed.SpaceChaos.Stage
{
    public class AsteroindSpawningModel : IAsteroindSpawningModel
    {
        private float timer = 0;
        private float secondsToCheckProbability = 10;

        public void Spawn ()
        {
            Debug.Log("Asteroid spawned");
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
    }
}