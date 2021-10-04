using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToughPlayer : PlayerController
{
    public override void TakeDamage()
    {
        return;
    }

    protected override void CheckSpaceAndMove(RaycastHit hit)
    {
        if (!hit.transform || hit.transform.CompareTag("Step"))
        {
            int rand = UnityEngine.Random.Range(0, 3);
            if (rand == 0) SoundController.Get().PlaySound(SoundController.Sounds.walk_blocked_a);
            else if (rand == 1) SoundController.Get().PlaySound(SoundController.Sounds.walk_blocked_b);
            else SoundController.Get().PlaySound(SoundController.Sounds.walk_blocked_c);
            return;
        }
        base.CheckSpaceAndMove(hit);
    }

    public override IEnumerator MoveCharacter(Vector3 gridPos)
    {
        int rand = Random.Range(0, 2);
        if (rand == 0) SoundController.Get().PlaySound(SoundController.Sounds.walk_deca_a);
        else SoundController.Get().PlaySound(SoundController.Sounds.walk_deca_b);
        return base.MoveCharacter(gridPos);
    }

    public override void AnimatePlayerMorph(bool morphToNext)
    {
        base.AnimatePlayerMorph(morphToNext);
        if (morphToNext) SoundController.Get().PlaySound(SoundController.Sounds.switch_triangulo);
        else SoundController.Get().PlaySound(SoundController.Sounds.switch_circulo);
    }
}
