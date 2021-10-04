using UnityEngine;

public class TransitionBetweenLvl : MonoBehaviour
{
    public void SwapToNextLevel()
    {
        GameplayController.Get().SwapToNextLevel();
    }

    public void OnLevelStarted()
    {
        GameplayController.Get().OnLevelStarted();
    }
}
