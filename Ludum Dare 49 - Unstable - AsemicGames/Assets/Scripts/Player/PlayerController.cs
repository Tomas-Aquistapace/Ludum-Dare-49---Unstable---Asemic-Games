using System.Collections;
using UnityEngine;
using System;

public class PlayerController : MonoBehaviour, IDamageable
{
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
    [SerializeField] SpriteRenderer spriteRenderer;

    //==============================
    
    [HideInInspector] public Vector3 initialPosition;
    protected Coroutine movementCorotine;

    //==============================

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
                spriteRenderer.flipX = true;
                CheckSpaceAndMove(GetSpaceRaycastHit(transform.forward));
            }
            else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
            {
                spriteRenderer.flipX = false;
                CheckSpaceAndMove(GetSpaceRaycastHit(-transform.forward));
            }
            else if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
            {
                spriteRenderer.flipX = true;
                CheckSpaceAndMove(GetSpaceRaycastHit(-transform.right));
            }
            else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
            {
                spriteRenderer.flipX = false;
                CheckSpaceAndMove(GetSpaceRaycastHit(transform.right));
            }
        }
    }

    protected virtual void CheckSpaceAndMove(RaycastHit hit)
    {
        if (!hit.transform) return;
        if (hit.transform.CompareTag("Table"))
        {
            movementCorotine = StartCoroutine(MoveCharacter(hit.transform.position));
            anim.SetTrigger("IsMoving");
        }
        else if (hit.transform.CompareTag("Void"))
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

        SetAsIdle();

        transform.position = initialPosition;
    }

    public virtual void SetAsIdle()
    {
        isDead = false;
        ableToMove = true;
    }

    public bool GetIdle()
    {
        return (isDead == false && ableToMove == true);
    }

    public void AnimatePlayerMorph(bool morphToNext)
    {
        ableToMove = false;
        if (morphToNext) anim.SetTrigger("Morph_A");
        else anim.SetTrigger("Morph_B");
    }
}
