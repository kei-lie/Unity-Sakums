using UnityEngine;

public class SFXScript : MonoBehaviour
{
    public AudioSource sfxSource;
    public AudioClip[] audioClips;

    public void PlaySFX(int ix)
    {
        sfxSource.PlayOneShot(audioClips[ix]);
    }
}
