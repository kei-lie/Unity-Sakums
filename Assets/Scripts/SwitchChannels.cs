using UnityEngine;
using UnityEngine.UI;

public class SwitchChannels : MonoBehaviour
{
    public GameObject Channel;
    public GameObject Channel1;
    public GameObject Channel2;
    public Sprite[] chan;
    public bool on;


    public void On(bool value)
    {
        on = value;
        Channel1.GetComponent<Toggle>().interactable = value;
        Channel2.GetComponent<Toggle>().interactable = value;
    }
    public void ChannelOne()
    {
        if (on == true)
        {
            Channel1.SetActive(true);
            Channel2.SetActive(false);
        }
    }
    public void ChannelTwo()
    {
        if (on == true)
        {
            Channel1.SetActive(false);
            Channel2.SetActive(true);
        }
    }
}
