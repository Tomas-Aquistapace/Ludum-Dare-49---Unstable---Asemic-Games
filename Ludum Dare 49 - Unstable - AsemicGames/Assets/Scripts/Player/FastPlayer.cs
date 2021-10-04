using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastPlayer : PlayerController
{
    Vector3 lastDirection;
    [SerializeField] float fastSpeed = 6;
    bool repeatStep = true;

    private void OnEnable()
    {
        speed = fastSpeed;
    }

    protected override void CheckSpaceAndMove(RaycastHit hit)
    {
        if (!hit.transform || hit.transform.CompareTag("Step"))
        {
            repeatStep = true;
            int rand = UnityEngine.Random.Range(0, 3);
            if (rand == 0) SoundController.Get().PlaySound(SoundController.Sounds.walk_blocked_a);
            else if (rand == 1) SoundController.Get().PlaySound(SoundController.Sounds.walk_blocked_b);
            else SoundController.Get().PlaySound(SoundController.Sounds.walk_blocked_c);
            return;
        }
        base.CheckSpaceAndMove(hit);
    }

    protected override RaycastHit GetSpaceRaycastHit(Vector3 direction)
    {
        RaycastHit hit = base.GetSpaceRaycastHit(direction);
        lastDirection = direction;
        return hit;
    }

    public override IEnumerator MoveCharacter(Vector3 gridPos)
    {
        int rand = Random.Range(0, 2);
        if (rand == 0) SoundController.Get().PlaySound(SoundController.Sounds.walk_triangulo_a);
        else SoundController.Get().PlaySound(SoundController.Sounds.walk_triangulo_b);
        yield return base.MoveCharacter(gridPos);
        if (repeatStep)
        {
            repeatStep = false;
            if (!isDead) CheckSpaceAndMove(GetSpaceRaycastHit(lastDirection));
        }
        else repeatStep = true;
    }

    public override void RestartPlayer()
    {
        base.RestartPlayer();

        repeatStep = true;
    }

    public override void SetAsIdle()
    {
        base.SetAsIdle();

        repeatStep = true;
    }

    public override void AnimatePlayerMorph(bool morphToNext)
    {
        base.AnimatePlayerMorph(morphToNext);
        if (morphToNext) SoundController.Get().PlaySound(SoundController.Sounds.switch_circulo);
        else SoundController.Get().PlaySound(SoundController.Sounds.switch_deca);
    }
}
