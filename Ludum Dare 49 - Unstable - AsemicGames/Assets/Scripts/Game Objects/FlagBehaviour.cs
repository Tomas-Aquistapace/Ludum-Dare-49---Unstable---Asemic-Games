using UnityEngine;

public class FlagBehaviour : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == "Player")
            GameplayController.Get().SwapToNextLevel();
    }
}
