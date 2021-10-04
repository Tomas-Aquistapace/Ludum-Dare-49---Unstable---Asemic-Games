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

    public void PlayTransitionSound()
    {
        SoundController.Get().PlaySound(SoundController.Sounds.transition);
    }
}
