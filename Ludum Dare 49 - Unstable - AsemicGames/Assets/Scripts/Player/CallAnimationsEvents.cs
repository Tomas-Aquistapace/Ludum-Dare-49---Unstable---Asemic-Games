using UnityEngine;

public class CallAnimationsEvents : MonoBehaviour
{
    [SerializeField] PlayerController playerController;

    public void RestartPlayer()
    {
        playerController.RestartPlayer();
    }

    public void OnEndMorph()
    {
        playerController.SetAsIdle(); //cuidado porque esto pone el isDead en false
    }

}
