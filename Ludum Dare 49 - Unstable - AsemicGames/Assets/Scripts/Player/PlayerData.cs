using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public PlayerController[] playerPrefabs;
    [SerializeField] UIPlayer uiPlayer;
    Vector3 kindChangePos;

    public enum PlayerKind
    {
        fast,
        jumping,
        tough
    }
    PlayerKind playerKind; //cambiar a int
    [SerializeField] Vector3 playerInitialPos;
    [SerializeField] int timeBeforeChanging;
    public float currentTimeBeforeChanging;

    private void Start()
    {
        foreach (PlayerController player in playerPrefabs)
        {
            player.initialPosition = playerInitialPos;
        }
        kindChangePos = playerInitialPos;
        playerKind = GetRandomPlayerKind();
        ActivateCurrentPlayer();
        StartCoroutine(WaitAndChangePlayerKind());
    }


    void SetPlayerKind(PlayerKind newPlayerKind)
    {
        DeactivateCurrentPlayer();
        playerKind = newPlayerKind;
        ActivateCurrentPlayer();
        StartCoroutine(WaitAndChangePlayerKind());
    }

    void DeactivateCurrentPlayer()
    {
        kindChangePos = playerPrefabs[(int)playerKind].transform.position;
        playerPrefabs[(int)playerKind].gameObject.SetActive(false);
    }

    void ActivateCurrentPlayer()
    {
        playerPrefabs[(int)playerKind].gameObject.SetActive(true);
        playerPrefabs[(int)playerKind].transform.position = kindChangePos;
        playerPrefabs[(int)playerKind].SetAsIdle();
        uiPlayer.SetBarColor((int)playerKind);
    }

    PlayerKind GetRandomPlayerKind()
    {
        int aux = Random.Range(1, playerPrefabs.Length);
        PlayerKind newPlayerKind;
        aux += (int)playerKind;
        if (aux < playerPrefabs.Length)
            newPlayerKind = (PlayerKind)aux;
        else
            newPlayerKind = (PlayerKind)(aux - playerPrefabs.Length);
        return newPlayerKind;
    }

    IEnumerator WaitAndChangePlayerKind()
    {
        currentTimeBeforeChanging = timeBeforeChanging;
        while (currentTimeBeforeChanging > 0f)
        {
            currentTimeBeforeChanging -= Time.deltaTime;
            if (currentTimeBeforeChanging < 0) currentTimeBeforeChanging = 0;
            uiPlayer.SetBarLength(currentTimeBeforeChanging / timeBeforeChanging);
            yield return null;
        }

        yield return new WaitUntil(playerPrefabs[(int)playerKind].GetIdle);
        PlayerKind newPlayerKind = GetRandomPlayerKind();
        int aux = (int)playerKind + 1;
        if (aux >= playerPrefabs.Length)
            aux -= playerPrefabs.Length;
        playerPrefabs[(int)playerKind].AnimatePlayerMorph((int)newPlayerKind == aux);
        StartCoroutine(WaitAnimationAndChangePlayerKind(newPlayerKind));
        
    }

    IEnumerator WaitAnimationAndChangePlayerKind(PlayerKind newPlayerKind)
    {
        yield return new WaitUntil(playerPrefabs[(int)playerKind].GetIdle);
        SetPlayerKind(newPlayerKind);
    }

    public PlayerController GetCurrentPlayer()
    {
        return playerPrefabs[(int)playerKind];
    }
}
