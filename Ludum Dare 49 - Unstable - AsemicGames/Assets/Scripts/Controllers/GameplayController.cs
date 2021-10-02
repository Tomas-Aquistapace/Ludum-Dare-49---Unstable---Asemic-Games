using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayController : MonoBehaviour
{
    [SerializeField] Timer timer;
    [SerializeField] GameObject[] LvlPrefab;
    uint currentLvl = 0;

    private void Start()
    {
        
    }

    public void NextLVL()
    {
        timer.OnLevelEnd();  
    }

    void SwapToNextLevel()
    {
        LvlPrefab[currentLvl].SetActive(false);
        currentLvl++;
        if (currentLvl < LvlPrefab.Length)
            LvlPrefab[currentLvl].SetActive(true);
        else
            Debug.Log("ganaste :)");
    }
}
