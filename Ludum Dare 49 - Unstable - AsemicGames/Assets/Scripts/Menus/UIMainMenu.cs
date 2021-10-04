using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class UIMainMenu : MonoBehaviour
{
    private void Start()
    {
        SoundController.Get().PlayMenuSong();
    }
    public void GoToGameplayScene()
    {
        SoundController.Get().StopMusic();
        SceneManager.LoadScene(1);
    }

    public void CloseGame()
    {
        Application.Quit();
        Debug.Log("GameClosed");
    }

}
