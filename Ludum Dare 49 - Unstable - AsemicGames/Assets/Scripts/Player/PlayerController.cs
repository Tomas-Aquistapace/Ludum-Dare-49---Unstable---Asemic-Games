using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Stats")]
    public int gridMovement = 1;
    public float speed = 0.5f;
    [SerializeField] bool ableToMove = true;

    [Header("Grid")]
    [SerializeField] LayerMask gridLayer;
    [SerializeField] float gridDistance = 1f;

    //==============================

    private void Update()
    {
        InputMovement();
    }

    //==============================

    void SetDirection(Vector3 direction)
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, direction, out hit, gridDistance, gridLayer))
        {
            StartCoroutine(MoveCharacter(hit.transform.position));
        }
    }

    void InputMovement()
    {
        if (ableToMove)
        {
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
            {
                SetDirection(transform.forward);
            }
            else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
            {
                SetDirection(-transform.forward);
            }
            else if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
            {
                SetDirection(-transform.right);
            }
            else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
            {
                SetDirection(transform.right);
            }
        }
    }

    IEnumerator MoveCharacter(Vector3 gridPos)
    {
        float time = 0f;

        ableToMove = false;

        while (time < 1)
        {
            transform.position = Vector3.Lerp(transform.position, gridPos, time);

            time += Time.deltaTime * speed;

            Debug.Log(time);

            yield return null;
        }

        ableToMove = true;
    }
}
