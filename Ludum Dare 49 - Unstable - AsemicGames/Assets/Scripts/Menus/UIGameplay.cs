using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIGameplay : MonoBehaviour
{
    bool gamePaused;
    [SerializeField] GameObject pauseMenu;
    private void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            gamePaused = !gamePaused;
            pauseMenu.SetActive(gamePaused);
            if (gamePaused) Time.timeScale = 0;
            else Time.timeScale = 1;
        }
    }

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
}
