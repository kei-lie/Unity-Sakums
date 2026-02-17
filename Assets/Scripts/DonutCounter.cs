using UnityEngine;
using TMPro;

public class DonutCounter : MonoBehaviour
{
    public int donutCount = 0;
    public TextMeshProUGUI donutText;

    void Start()
    {
        UpdateDonutUI();
    }

    public void AddDonut(int amount)
    {
        donutCount += amount;
        UpdateDonutUI();
    }

    void UpdateDonutUI()
    {
        donutText.text = "Donuts: " + donutCount.ToString();
    }
}