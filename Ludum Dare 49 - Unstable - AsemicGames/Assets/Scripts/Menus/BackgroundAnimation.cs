using UnityEngine;

public class BackgroundAnimation : MonoBehaviour
{
    [SerializeField] Transform background1;
    [SerializeField] Transform background2;
    [SerializeField] float speedAnimation = 1f;

    float initialPosB_1 = 0f;
    float initialPosB_2 = 0f;

    private void Start()
    {
        initialPosB_1 = background1.transform.position.y;
        initialPosB_2 = background2.transform.position.y;
    }

    private void Update()
    {
        background1.transform.position -= new Vector3(0, Time.deltaTime * speedAnimation, 0);
        background2.transform.position -= new Vector3(0, Time.deltaTime * speedAnimation, 0);

        if (background1.transform.position.y <= -initialPosB_1)
        {
            background1.transform.position = new Vector3(background1.transform.position.x, initialPosB_2, background1.transform.position.z);
        }
        
        if (background2.transform.position.y <= -initialPosB_1)
        {
            background2.transform.position = new Vector3(background2.transform.position.x, initialPosB_2, background2.transform.position.z);
        }
    }
}
