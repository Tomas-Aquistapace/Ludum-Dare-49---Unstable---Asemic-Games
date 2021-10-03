using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public PlayerController[] playerPrefabs;
    Vector3 kindChangePos;
    
    public enum PlayerKind
    {
        fast,
        jumping,
        tough
    }
    PlayerKind playerKind;

    private void Start()
    {
    }
    void SetPlayerKind(PlayerKind newPlayerKind)
    {
        kindChangePos = playerPrefabs[(int)playerKind].transform.position;
        playerPrefabs[(int)playerKind].gameObject.SetActive(false);
        playerKind = newPlayerKind;
        playerPrefabs[(int)playerKind].gameObject.SetActive(true);
        playerPrefabs[(int)playerKind].transform.position = kindChangePos;
        StartCoroutine(WaitAndChangePlayerKind());
    }

    IEnumerator WaitAndChangePlayerKind()
    {
        yield return new WaitForSeconds(5);
        int aux = Random.Range(1, 2);
        PlayerKind newPlayerKind;
        aux += (int)playerKind;
        if (aux < playerPrefabs.Length)
            newPlayerKind = (PlayerKind)aux;
        else
            newPlayerKind = 0;
        SetPlayerKind(newPlayerKind);
    }

    public PlayerController GetCurrentPlayer()
    {
        return playerPrefabs[(int)playerKind];
    }
}
