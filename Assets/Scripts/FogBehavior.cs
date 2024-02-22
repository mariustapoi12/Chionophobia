using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FogBehavior : MonoBehaviour
{
    public ParticleSystem Fog_PS;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        var emission = Fog_PS.emission;

        if (emission.rateOverTime.constant < 600f)
        {
            var newRate = emission.rateOverTime.constant + 0.1f;
            emission.rateOverTime = newRate;
        }
    }

}
