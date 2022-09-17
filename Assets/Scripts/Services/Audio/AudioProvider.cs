using LeandroExhumed.SpaceChaos.Services.Pooling;
using UnityEngine;
using Zenject;

namespace LeandroExhumed.SpaceChaos.Services.Audio
{
    public class AudioProvider
    {
        private const int POOL_SIZE = 32;

        private readonly SoundCatalog catalog;
        private readonly AudioSource musicSource;

        private readonly Pool pool;

        private readonly AudioSource sfxSourcePrefab;

        public AudioProvider (
            SoundCatalog catalog,
            AudioSource musicSource,
            [Inject(Id = "SFX")] AudioSource sfxSourcePrefab,
            Pool pool,
            Transform effectsSourcePoolContainer)
        {
            this.catalog = catalog;
            this.musicSource = musicSource;
            this.sfxSourcePrefab = sfxSourcePrefab;
            this.pool = pool;

            pool.AddPool(sfxSourcePrefab, POOL_SIZE, effectsSourcePoolContainer);
        }

        public void PlayMusic (AudioClip clip)
        {
            musicSource.clip = clip;
            musicSource.Play();
        }

        public void PlayOneShot (SoundType soundType, Vector3? position = null, float volume = 1f)
        {
            SetupAudioSource(position, out AudioSource source, volume);

            source.clip = catalog.GetSound(soundType);
            source.Play();
        }

        private void SetupAudioSource (Vector3? position, out AudioSource source, float volume = 1)
        {
            source = pool.GetObject<AudioSource>(sfxSourcePrefab);

            if (position != null)
            {
                source.transform.position = position.Value;
                source.spatialBlend = 1;
            }
            else
            {
                source.spatialBlend = 0;
            }

            source.volume = volume;
        }
    }
}