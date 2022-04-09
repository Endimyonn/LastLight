using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Flashlight : MonoBehaviour
{
    public float powerLevel = 100;
    public Light lightSource;
    public float initialIntensity;

    public float drainSpeed = 1;
    public bool drainActive = true;

    public float dimThreshold = 40;

    public Slider powerMonitor;

    public AudioSource reloadSound;

    
    private void Awake()
    {
        initialIntensity = lightSource.intensity;
    }

    
    private void Update()
    {
        //drain
        if (drainActive)
        {
            if (powerLevel > 0)
            {
                powerLevel -= drainSpeed * Time.deltaTime;
            }
        }

        //update light level
        if (powerLevel <= dimThreshold)
        {
            lightSource.intensity = initialIntensity * (powerLevel / 100);
        }
        else if (lightSource.intensity != initialIntensity)
        {
            lightSource.intensity = initialIntensity;
        }

        //update UI
        powerMonitor.value = powerLevel / 100;
    }

    public void RestorePower(float argAmount)
    {
        powerLevel += argAmount;

        if (powerLevel > 100)
        {
            powerLevel = 100;
        }

        reloadSound.Stop();
        reloadSound.Play();
    }
}
