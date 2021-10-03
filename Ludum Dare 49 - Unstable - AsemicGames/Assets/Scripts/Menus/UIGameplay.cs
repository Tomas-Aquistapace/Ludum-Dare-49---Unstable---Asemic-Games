using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIGameplay : MonoBehaviour
{
    [Header("Pause Screen")]
    [SerializeField] GameObject pauseScreen;

    [Header("Victory Screen")]
    [SerializeField] GameObject victoryScreen;

    [Header("Lose Screen")]
    [SerializeField] GameObject loseScreen;

    //==============================

    bool gamePaused;

    //==============================

    private void OnEnable()
    {
        PlayerController.OnVictory += CallVictory;
        PlayerController.OnLose += CallLose;
    }

    private void OnDisable()
    {
        PlayerController.OnVictory -= CallVictory;
        PlayerController.OnLose -= CallLose;
    }

    private void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            gamePaused = !gamePaused;
            pauseScreen.SetActive(gamePaused);
            if (gamePaused) Time.timeScale = 0;
            else Time.timeScale = 1;
        }
    }

    //==============================

    public void GoToMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    public void CloseGame()
    {
        Application.Quit();
        Debug.Log("GameClosed");
    }

    public void CallVictory()
    {
        victoryScreen.SetActive(true);
    }

    public void CallLose()
    {
        loseScreen.SetActive(true);
    }
}
