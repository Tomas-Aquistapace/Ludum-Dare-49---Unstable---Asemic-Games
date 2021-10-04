using UnityEngine;

public class Gizmos_Void : MonoBehaviour
{
    [SerializeField] float radius = 0.25f;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;

        Gizmos.DrawSphere(this.transform.position, radius);
    }
}
