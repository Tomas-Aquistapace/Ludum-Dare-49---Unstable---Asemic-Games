using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour, IDamageable
{
    [Header("Stats")]
    public int gridMovement = 1;
    public float speed = 0.5f;
    [SerializeField] bool ableToMove = true;
    [SerializeField] bool isDead = false;

    [Header("Table")]
    [SerializeField] LayerMask tableLayer;

    [Header("Grid")]
    [SerializeField] LayerMask gridLayer;
    [SerializeField] float gridDistance = 1f;

    //==============================
    
    Animator anim;

    //==============================

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        InputMovement();
    }

    //==============================

    public void TakeDamage()
    {
        isDead = true;
        anim.SetTrigger("IsDeath");
    }

    void SetDirection(Vector3 direction)
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, direction, out hit, gridDistance, gridLayer))
        {
            if (hit.transform.tag == "Table")
            {
                StartCoroutine(MoveCharacter(hit.transform.position));
            }
            else if (hit.transform.tag == "Void")
            {
                StartCoroutine(MoveCharacter(hit.transform.position));
                anim.SetTrigger("IsFalling");
                isDead = true;
            }
        }
    }

    void InputMovement()
    {
        if (ableToMove == true && isDead == false)
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

            yield return null;
        }

        ableToMove = true;
    }
}
