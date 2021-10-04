using UnityEngine;
using UnityEngine.SceneManagement;

public class UIGameplay : MonoBehaviour
{
    [Header("Pause Screen")]
    [SerializeField] GameObject pauseScreen;

    //==============================

    bool gamePaused;

    //==============================

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

    public void ClosePause()
    {
        gamePaused = !gamePaused;
        pauseScreen.SetActive(gamePaused);
        Time.timeScale = 1;
    }

    public void CloseGame()
    {
        Application.Quit();
        Debug.Log("GameClosed");
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("Gameplay");
    }
}
