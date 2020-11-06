using System.Collections;
using UberPlanetary.Core.ExtensionMethods;
using UnityEngine;

namespace Audio
{
    public class MusicManager : MonoBehaviour
    {
        public AudioSource ghostMusic;
        public AudioSource creatureMusic;

        public float timeToFadeIn;
        public AnimationCurve fadeInCurve;

        public void LerpAudio()
        {
            StartCoroutine(FadeInGhostAudio());
            creatureMusic.volume = 0;
        }

        public void CreatureAudioOn()
        {
            StartCoroutine(FadeInCreatureAudio());
            ghostMusic.volume = 0;
        }
        private IEnumerator FadeInGhostAudio()
        {
            float t = 0;
            while (t <= timeToFadeIn)
            {
                ghostMusic.volume = Mathf.Lerp(0, 1, fadeInCurve.Evaluate(t.Remap(0, timeToFadeIn, 0, 1)));
                t += Time.deltaTime;
                yield return new WaitForEndOfFrame();
            }
        }
        private IEnumerator FadeInCreatureAudio()
        {
            float t = 0;
            while (t <= timeToFadeIn)
            {
                creatureMusic.volume = Mathf.Lerp(0, 1, fadeInCurve.Evaluate(t.Remap(0, timeToFadeIn, 0, 1)));
                t += Time.deltaTime;
                yield return new WaitForEndOfFrame();
            }
        }
    }
}
