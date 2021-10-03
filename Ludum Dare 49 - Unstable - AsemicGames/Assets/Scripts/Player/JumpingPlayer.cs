using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpingPlayer : PlayerController
{
    protected override void CheckSpaceAndMove(RaycastHit hit)
    {
        if (!hit.transform) return;
        base.CheckSpaceAndMove(hit);
        if (hit.transform.tag == "Step")
        {
            StartCoroutine(MoveCharacter(hit.transform.position));
        }
    }
}