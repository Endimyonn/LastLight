using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public bool holdInteract = false;
    private GameObject holdInteractSource;

    public virtual void Interact(GameObject argSource)
    {

    }

    protected virtual void InteractWhileHeld()
    {

    }

    public void ToggleHoldInteract(GameObject argSource, bool argToggle)
    {
        holdInteract = argToggle;
        holdInteractSource = argSource;
    }

    public virtual void Update()
    {
        if (holdInteract)
        {
            InteractWhileHeld();
        }
    }
}
