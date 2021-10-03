using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] float generalTimer;
    [SerializeField] float baseLvlTime = 30;
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] TextMeshProUGUI leftoverTimeText;
    [SerializeField] Animator timerAnimator;
    int leftoverTime;
    bool timerRunning;

    private void Start()
    {
        generalTimer = baseLvlTime;
        timerText.text = generalTimer.ToString();
        timerRunning = true;
    }

    private void Update()
    {
        if (timerRunning) UpdateTimer();
    }

    public void OnLevelStart()
    {
        generalTimer = baseLvlTime;
        leftoverTimeText.text = "leftover: " + leftoverTime.ToString();
        UpdateTimerVisual();
        timerAnimator.SetTrigger("AddLeftover");
    }

    public void AddLeftoverTimeAndStartTimer()
    {
        generalTimer = leftoverTime + baseLvlTime;
        UpdateTimerVisual();
        timerRunning = true;
    }

    public void OnLevelEnd()
    {
        timerRunning = false;
        leftoverTime = (int)generalTimer;
        
    }

    void UpdateTimer()
    {
        if (generalTimer == 0)
        {
            timerRunning = false;
            return;
        }
        generalTimer -= Time.deltaTime;
        if (generalTimer < 0)
        {
            generalTimer = 0;
            Debug.Log("Perdiste :(");
        }
        UpdateTimerVisual();
    }

    void UpdateTimerVisual()
    {
        int timerAsInt = (int)generalTimer;
        timerText.text = timerAsInt.ToString();
    }
}
