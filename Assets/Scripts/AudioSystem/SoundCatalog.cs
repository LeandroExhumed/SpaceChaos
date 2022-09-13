using UnityEngine;

namespace LeandroExhumed.SpaceChaos.Audio
{
    [CreateAssetMenu(fileName = "SoundsCatalog", menuName = "Audio/Sound Catalog")]
    public class SoundCatalog : ScriptableObject
    {
        [SerializeField]
        private AudioClip[] clips;

        public AudioClip GetSound (SoundType type)
        {
            return clips[(int)type];
        }
    }
}