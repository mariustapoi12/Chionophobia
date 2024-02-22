using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudsBehavior : MonoBehaviour
{
    public ParticleSystem Clouds_PS;
    private float sizeChangeSpeed = 10f;
    private float colorChangeSpeed = 0.01f;
    private float elapsedTime = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;

        // Increase cloud size gradually after each second
        if (elapsedTime >= 1.0f && Clouds_PS.startSize < 150)
        {
            Clouds_PS.startSize += sizeChangeSpeed;
            elapsedTime = 0.0f;
        }

        // Change cloud color gradually
        if (Clouds_PS.startColor.r > 0.54)
        {
            float colorChange = colorChangeSpeed * Time.deltaTime;
            Color newColor = new Color(
                Mathf.Max(Clouds_PS.startColor.r - colorChange, 0),
                Mathf.Max(Clouds_PS.startColor.g - colorChange, 0),
                Mathf.Max(Clouds_PS.startColor.b - colorChange, 0),
                Clouds_PS.startColor.a
            );
            Clouds_PS.startColor = newColor;
        }
    }
}
