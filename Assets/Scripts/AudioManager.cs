
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioSource sfxSource;

    public AudioClip musicClip;
    public AudioClip winClip;
    public AudioClip loseClip;
    public AudioClip collectClip;

    private void Start()
    {
        musicSource.clip = musicClip;
        musicSource.loop = true;
        musicSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        
        sfxSource.PlayOneShot(clip);
    }



}
