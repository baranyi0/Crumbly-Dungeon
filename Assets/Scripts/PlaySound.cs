using UnityEngine;

public class PlaySound : MonoBehaviour
{
    [SerializeField]AudioSource audioSource;
    [SerializeField] bool hasRandomPitch = false;
    [SerializeField] bool automatic = true;
    [SerializeField] float lowest = 0.7f;
    [SerializeField] float highest = 1.25f;

    void Start()
    {
        if (automatic)
        {
            audioSource = this.GetComponent<AudioSource>();
        }
        else
        {
            audioSource = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<AudioSource>();
        }
    }

    public void PlaySoundVoid(AudioClip audioClip)
    {
        if (hasRandomPitch)
        {
            audioSource.pitch = Random.Range(lowest, highest);
        }
        audioSource.PlayOneShot(audioClip);
    }

    public void PlaySoundWithoutClip()
    {
        if (hasRandomPitch)
        {
            audioSource.pitch = Random.Range(lowest, highest);
        }
        audioSource.Play();
    }
}