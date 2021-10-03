using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayController : MonoBehaviourSingleton<GameplayController>
{
    [Header("Screen")]
    [SerializeField] GameObject victoryScreen;
    [SerializeField] GameObject loseScreen;

    [Header("Player")]
    [SerializeField] PlayerData playerObject;
    [SerializeField] Vector3 playerInitialPosition;

    [Header("Levels")]
    [SerializeField] Timer timer;
    [SerializeField] GameObject[] LvlPrefab;

    //=======================

    uint currentLvl = 0;

    //=======================

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

    private void Start()
    {
        foreach (GameObject lvl in LvlPrefab)
        {
            lvl.SetActive(false);
        }
        LvlPrefab[0].SetActive(true);

        SetPlayerPosition();
    }

    //=======================

    public void NextLVL()
    {
        timer.OnLevelEnd();
        SwapToNextLevel();
    }

    public void SwapToNextLevel()
    {
        LvlPrefab[currentLvl].SetActive(false);
        currentLvl++;
        
        if (currentLvl < LvlPrefab.Length)
        {
            SetPlayerPosition();

            LvlPrefab[currentLvl].SetActive(true);
        }
        else
        {
            CallVictory();
        }
    }

    void SetPlayerPosition()
    {
        playerObject.GetCurrentPlayer().RestartPlayer(playerInitialPosition);
    }

    //=======================

    public void CallVictory()
    {
        victoryScreen.SetActive(true);
    }

    public void CallLose()
    {
        loseScreen.SetActive(true);
    }
}
