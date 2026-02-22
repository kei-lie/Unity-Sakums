
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SwitchChannels : MonoBehaviour
{
    public TMP_Text ChanelLog;
    public GameObject tvBlackScreen;
    public Slider VolumeSlider;
    public GameObject[] chanels;

    private int currentChanelIndex = 0;
    private bool tvIsOn = false;

    public void ToggleTV()
    {
        tvIsOn = !tvIsOn;

        tvBlackScreen.SetActive(!tvIsOn);

        if (tvIsOn)
        {
            ShowChanel(currentChanelIndex);
            VolumeSlider.onValueChanged.AddListener(ChangeVolume);
        }
        else
        {
            HideAllChanels();
            ChanelLog.text = "OFF";
        }
    }

    public void NextChanel()
    {
        if (tvIsOn && currentChanelIndex < chanels.Length - 1)
        {
            currentChanelIndex++;
            ShowChanel(currentChanelIndex);
        }
    }

    public void PreviousChanel()
    {
        if (tvIsOn && currentChanelIndex > 0)
        {
            currentChanelIndex--;
            ShowChanel(currentChanelIndex);
        }
    }

    private void ShowChanel(int index)
    {
        HideAllChanels();
        chanels[index].SetActive(true);
        ChanelLog.text = "Channel: " + (index + 1).ToString();
    }

    private void HideAllChanels()
    {
        foreach (GameObject c in chanels)
        {
            c.SetActive(false);
        }
    }

    public void ChangeVolume(float value)
    {
        AudioListener.volume = value;
    }

}