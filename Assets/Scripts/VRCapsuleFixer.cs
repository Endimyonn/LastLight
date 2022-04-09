using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class VRCapsuleFixer : MonoBehaviour
{
    public CapsuleCollider playerCollider;

    public Transform cameraPosition;
    public Transform origin;

    private void Update()
    {
        if (playerCollider)
        {
            playerCollider.height = cameraPosition.localPosition.y;
            playerCollider.center = new Vector3(0, -(cameraPosition.localPosition.y / 2), 0);
        }
    }
}
