using UnityEngine;
using TMPro;

public class ChangeLoseText : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI loseText;
    [SerializeField] string[] tittles;

    void Start()
    {
        int num = Random.Range(0, tittles.Length);
        loseText.text = tittles[num];
    }
}
