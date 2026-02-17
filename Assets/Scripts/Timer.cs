using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{

    public Toggle timer;
    public TMP_Text timerText;

    private float elapsedTime = 0f;
    private bool isRunning = false;
    void Start()
    {
        UpdateTimerDisplay(0f);

        timer.onValueChanged.AddListener(OnToggleChanged);
    }

    void Update()
    {
        if (isRunning)
        {
            elapsedTime += Time.deltaTime;
            UpdateTimerDisplay(elapsedTime);
        }

    }

    void OnToggleChanged(bool isOn)
    {
        isRunning = isOn;
    }

    void UpdateTimerDisplay(float time)
    {
        int minutes = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time % 60);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
