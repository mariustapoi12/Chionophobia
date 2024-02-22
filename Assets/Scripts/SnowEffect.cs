using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowEffect : MonoBehaviour
{
    public ParticleSystem Snow_PS;
    public GameObject Body;

    private float initialY;

    // Start is called before the first frame update
    void Start()
    {
        // Store the initial Y position
        initialY = Snow_PS.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        // Increase emission rate
        var emission = Snow_PS.emission;
        if (emission.rateOverTime.constant < 1000f)
        {
            var newRate = emission.rateOverTime.constant + 0.005f;
            emission.rateOverTime = newRate;
        }

        // Move snow particle system to player position while keeping the Y unchanged
        Vector3 newPosition = new Vector3(Body.transform.position.x, initialY, Body.transform.position.z);
        Snow_PS.transform.position = newPosition;
    }
}
