using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundColor : MonoBehaviour
{
    Camera cam;
    [SerializeField] Color[] colors;
    Color fromColor;
    Color toColor;
    int currentColor = 0;
    [SerializeField] float timeBetweenColors;
    float timer;
    private void Awake()
    {
        cam = GetComponent<Camera>();
    }

    private void Start()
    {
        fromColor = colors[currentColor];
        toColor = colors[currentColor+1];
    }
    private void Update()
    {
        ChangeBackgroundColor();
    }

    void ChangeBackgroundColor()
    {
        if (timer >= timeBetweenColors)
        {
            timer = 0.0f;
            SetFromAndTo();
        }
        timer += Time.deltaTime;
        cam.backgroundColor = Color.Lerp(fromColor, toColor, timer);
    }

    void SetFromAndTo()
    {
        currentColor++;
        if (currentColor >= colors.Length) currentColor = 0;
        fromColor = colors[currentColor];
        if ((currentColor + 1) >= colors.Length) toColor = colors[0];
        else toColor = colors[currentColor + 1];
    }
}
