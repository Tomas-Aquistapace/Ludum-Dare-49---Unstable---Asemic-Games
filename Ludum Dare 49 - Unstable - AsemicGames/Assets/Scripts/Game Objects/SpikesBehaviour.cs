using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikesBehaviour : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.GetComponent<IDamageable>() != null)
            other.transform.GetComponent<IDamageable>().TakeDamage();
    }

}
