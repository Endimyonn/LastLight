using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battery : MonoBehaviour
{
    public float restorationAmount = 25;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Battery hit object named " + other.gameObject.name + " tagged " + other.gameObject.tag);

        if (other.gameObject.tag == "Flashlight")
        {
            other.GetComponent<Flashlight>().RestorePower(restorationAmount);
            Destroy(gameObject);
        }
    }
}
