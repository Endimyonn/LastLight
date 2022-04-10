using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TravelNode : MonoBehaviour
{
    public float setObjectSpeed;
    public float setObjectDelay;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawSphere(transform.position, 0.25f);

        if (transform.GetSiblingIndex() != transform.parent.childCount - 1)
        {
            Gizmos.DrawLine(transform.position, transform.parent.GetChild(transform.GetSiblingIndex() + 1).position);
        }
        else
        {
            Gizmos.DrawLine(transform.position, transform.parent.GetChild(0).position);
        }
    }
}
