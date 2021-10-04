using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPlayer : MonoBehaviour
{
    [SerializeField] Slider slider;
    [SerializeField] Sprite spriteYellowBar;
    [SerializeField] Sprite spriteBlueBar;
    [SerializeField] Sprite spriteRedBar;
    [SerializeField] Image barImage;

    public void SetBarColor(int newColor)
    {
        switch (newColor)
        {
            case 0:
                barImage.sprite = spriteYellowBar;
                break;
            case 1:
                barImage.sprite = spriteBlueBar;
                break;
            case 2:
                barImage.sprite = spriteRedBar;
                break;
            default:
                barImage.sprite = spriteBlueBar;
                break;
        }
    }
    
    public void SetBarLength(float newLength)
    {
        slider.value = newLength;
    }
}
