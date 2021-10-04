using UnityEngine;

public class CallAnimationsEvents : MonoBehaviour
{
    [SerializeField] PlayerController playerController;

    public void RestartPlayer()
    {
        playerController.RestartPlayer();
    }
}
