using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeOutSounds : MonoBehaviour
{
    [SerializeField] AudioSource[] audioSources;
    [SerializeField] float target = 0f;
    [SerializeField] float duration = 1f;
    private void Start()
    {
        foreach (var item in audioSources)
        {
            StartCoroutine(FadeOut(item, duration, target));
        }
    }


    public IEnumerator FadeOut(AudioSource audioSource, float duration, float targetVolume)
    {
        float currentTime = 0;
        float start = audioSource.volume;
        while (currentTime < duration)
        {
            currentTime += Time.deltaTime;
            audioSource.volume = Mathf.Lerp(start, targetVolume, currentTime / duration);
            yield return null;
        }
        yield break;
    }
}
