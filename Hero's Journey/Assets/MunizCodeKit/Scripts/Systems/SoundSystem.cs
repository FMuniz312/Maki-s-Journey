using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace MunizCodeKit.Systems
{
    public class SoundSystem : MonoBehaviour
    {
        [SerializeField] private AudioClipData[] audioClipData;


        static public SoundSystem instance;
        public float volumeMultiplier { get; private set; }

        private void Awake()
        {
            if (instance == null) instance = this;
        }

        public enum Sound
        {
            EarthHealthCritical,
            GarbageCanCorrect,
            GarbageCanIncorrect,
            GarbageCollect,
            GarbageSpawn,
            RoundLose,
            RoundWin,
            Music,
            UIClick,
            UIText,
            GarbageThrow
        }

        public void PlaySound(Sound soundType, bool loops = false)
        {
            GameObject gameObject = new GameObject("SoundEffect_", typeof(AudioSource));
            AudioSource audioSource = gameObject.GetComponent<AudioSource>();
            AudioClip audioClip = GetAudioClip(soundType);
            audioSource.volume *= volumeMultiplier;
            audioSource.PlayOneShot(audioClip);
            if (loops)
            {
                audioSource.loop = true;
            }
            else
            {
                Destroy(gameObject, audioClip.length + 0.5f);
            }


            if (soundType == Sound.UIText) textSoundSource = audioSource;
        }

        AudioSource textSoundSource;
        public void StopTextSound()
        {
           if(textSoundSource) Destroy(textSoundSource.gameObject);
        }

        public void ChangeVolumeMultiplier(float volume)
        {
            volumeMultiplier = volume;
        }
        AudioClip GetAudioClip(Sound sound)
        {
            foreach (AudioClipData ClipData in audioClipData)
            {
                if (ClipData.Sound == sound)
                {
                    ChangeVolumeMultiplier(ClipData.volume);
                    return ClipData.AudioClip;
                }
            }
            return null;
        }

        [System.Serializable]
        public class AudioClipData
        {
            public AudioClip AudioClip;
            public Sound Sound;
            [Range(0, 1)]
            public float volume;
        }

        private void OnDestroy()
        {
            // instance = null;
        }
    }


}