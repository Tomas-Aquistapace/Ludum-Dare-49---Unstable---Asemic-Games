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

    [Header("Levels")]
    [SerializeField] Timer timer;
    [SerializeField] GameObject[] LvlPrefab;
    [SerializeField] Animator transitionAnim;

    //=======================

    uint currentLvl = 0;

    //=======================

    protected void OnEnable()
    {
        PlayerController.OnVictory += CallVictory;
        PlayerController.OnLose += CallLose;
    }

    protected void OnDisable()
    {
        PlayerController.OnVictory -= CallVictory;
        PlayerController.OnLose -= CallLose;
    }

    public override void Awake()
    {
        base.Awake();

        foreach (GameObject lvl in LvlPrefab)
        {
            lvl.SetActive(false);
        }
        LvlPrefab[0].SetActive(true);
    }

    //=======================

    public void NextLVL()
    {
        timer.OnLevelEnd();
        SwapToNextLevel();
    }

    public void CallTransitionAnimation()
    {
        transitionAnim.SetTrigger("Start");
    }

    public void SwapToNextLevel()
    {
        currentLvl++;
        
        if (currentLvl < LvlPrefab.Length)
        {
            LvlPrefab[currentLvl - 1].SetActive(false);
            
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
        playerObject.GetCurrentPlayer().RestartPlayer();
    }

    //=======================

    public void CallVictory()
    {
        playerObject.gameObject.SetActive(false);
        victoryScreen.SetActive(true);
    }

    public void CallLose()
    {
        playerObject.gameObject.SetActive(false);
        loseScreen.SetActive(true);
    }
}
