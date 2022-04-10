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
            playerCollider.height = cameraPosition.position.y;
            playerCollider.center = new Vector3(cameraPosition.localPosition.x, -(cameraPosition.localPosition.y / 2), cameraPosition.localPosition.z);
        }
    }
}
