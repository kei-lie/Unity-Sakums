using UnityEngine;
using UnityEngine.UI;

public class DonutCounter : MonoBehaviour
{
    public int donutCounter;
    public Text donutText;

    void Update()
    {
        donutText.text = donutCounter.ToString();

    }
}
