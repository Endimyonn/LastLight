using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class VRForwardSourcer : MonoBehaviour
{
    public ActionBasedContinuousMoveProvider provider;

    public Transform moveController;
    public Transform playerCamera;

    public void SetController()
    {
        provider.forwardSource = moveController;
    }

    public void SetCamera()
    {
        provider.forwardSource = playerCamera;
    }
}
