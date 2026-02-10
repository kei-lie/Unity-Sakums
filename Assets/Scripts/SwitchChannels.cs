
using UnityEngine;
using UnityEngine.UI;

public class SwitchChannels : MonoBehaviour
{
    public GameObject Background;
    public AudioClip[] Sound;
    public AudioSource sfxSource;
    public Sprite[] characterSprite;

    public void TurnOn()
    {
        if (Background.activeSelf == true)
            Background.SetActive(false);
        else
        {
            Background.SetActive(true);
        }
    }
    public void ChangeBackground(int Kanals)
    {
        sfxSource.Pause();
        Background.GetComponent<Image>().sprite = characterSprite[Kanals];
    }

}
