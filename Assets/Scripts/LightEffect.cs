using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightEffect : MonoBehaviour
{
    public Light directionalLight;
    private float elapsedTime = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;
        float currentRotationX = directionalLight.transform.eulerAngles.x;

        // Convert to the range [-180, 180]
        if (currentRotationX > 180)
        {
            currentRotationX -= 360;
        }

        // Check if greater than -10
        if (elapsedTime >= 0.01f && currentRotationX > -10)
        {
            float newRotationX = currentRotationX - 0.01f;
            directionalLight.transform.eulerAngles = new Vector3(newRotationX, directionalLight.transform.eulerAngles.y, directionalLight.transform.eulerAngles.z);
            elapsedTime =0.0f;
        }
    }
}
