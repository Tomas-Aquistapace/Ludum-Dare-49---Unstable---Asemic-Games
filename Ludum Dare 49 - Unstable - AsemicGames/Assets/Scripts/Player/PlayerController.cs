using System.Collections;
using UnityEngine;
using System;

public class PlayerController : MonoBehaviour, IDamageable
{
    public static Action OnVictory;
    public static Action OnLose;

    [Header("Stats")]
    public int gridMovement = 1;
    public float speed = 3f;
    [SerializeField] protected bool ableToMove = true;
    [SerializeField] protected bool isDead = false;

    [Header("Grid")]
    [SerializeField] LayerMask gridLayer;
    [SerializeField] float gridDistance = 1f;

    [Header("Animations")]
    [SerializeField] protected Animator anim;

    //==============================
    
    Vector3 initialPosition;
    protected Coroutine movementCorotine;

    //==============================

    private void Start()
    {
        initialPosition = transform.position;
    }

    private void Update()
    {
        InputMovement();
    }

    //==============================

    public virtual void TakeDamage()
    {
        isDead = true;
        anim.SetTrigger("IsDeath");
    }

    protected virtual RaycastHit GetSpaceRaycastHit(Vector3 direction)
    {
        RaycastHit hit;
        Physics.Raycast(transform.position, direction, out hit, gridDistance, gridLayer);
        return hit;
    }

    void InputMovement()
    {
        if (ableToMove == true && isDead == false)
        {
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
            {
                CheckSpaceAndMove(GetSpaceRaycastHit(transform.forward));
            }
            else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
            {
                CheckSpaceAndMove(GetSpaceRaycastHit(-transform.forward));
            }
            else if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
            {
                CheckSpaceAndMove(GetSpaceRaycastHit(-transform.right));
            }
            else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
            {
                CheckSpaceAndMove(GetSpaceRaycastHit(transform.right));
            }
        }
    }

    protected virtual void CheckSpaceAndMove(RaycastHit hit)
    {
        if (!hit.transform) return;
        if (hit.transform.tag == "Table")
        {
            movementCorotine = StartCoroutine(MoveCharacter(hit.transform.position));
            anim.SetTrigger("IsMoving");
        }
        else if (hit.transform.tag == "Void")
        {
            movementCorotine = StartCoroutine(MoveCharacter(hit.transform.position));
            anim.SetTrigger("IsFalling");
            isDead = true;
        }
    }

    public virtual IEnumerator MoveCharacter(Vector3 gridPos)
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

    public Coroutine GetMovementCoroutine()
    {
        return movementCorotine;
    }

    public virtual void RestartPlayer()
    {
        if (GetMovementCoroutine() != null)
            StopCoroutine(GetMovementCoroutine());

        ableToMove = true;
        isDead = false;

        transform.position = initialPosition;
    }
}
