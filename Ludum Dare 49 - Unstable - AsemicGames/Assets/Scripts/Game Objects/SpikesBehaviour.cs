using UnityEngine;

public class SpikesBehaviour : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        if(other.transform.GetComponent<IDamageable>() != null)
        {
            other.transform.GetComponent<IDamageable>().TakeDamage();
        }
    }
}
