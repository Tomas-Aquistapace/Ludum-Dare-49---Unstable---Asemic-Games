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
        if (!hit.transform)
        {
            repeatStep = true;
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
        yield return base.MoveCharacter(gridPos);
        if (repeatStep)
        {
            repeatStep = false;
            if (!isDead) CheckSpaceAndMove(GetSpaceRaycastHit(lastDirection));
        }
        else repeatStep = true;
    }

    public override void RestartPlayer(Vector3 restartPos)
    {
        base.RestartPlayer(restartPos);

        repeatStep = true;
    }

}
