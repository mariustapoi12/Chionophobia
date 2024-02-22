using UnityEngine;

public class DisplayText : MonoBehaviour
{
    public Camera targetCamera;
    public string message = "A storm is coming... I have to go home";
    public float floatSpeed = 5.0f;
    public float destroyTime = 6.0f;
    private GameObject textObject;

    void Start()
    {
        // Create a new TextMesh component
        textObject = new GameObject("FloatingText");
        TextMesh textMesh = textObject.AddComponent<TextMesh>();
        textMesh.text = message;

        // Set the position of the text in front of the camera
        textObject.transform.position = targetCamera.transform.position + targetCamera.transform.forward * 3.0f;

        textObject.transform.Translate(Vector3.right * 5.0f);

        // Make the text face the camera
        textObject.transform.LookAt(targetCamera.transform);
        textObject.transform.Rotate(0.0f, 180.0f, 0.0f);

        // Set other properties
        textMesh.characterSize = 0.1f;
        textMesh.fontSize = 30;

        textMesh.GetComponent<Renderer>().sortingLayerName = "UI";
        textMesh.GetComponent<Renderer>().sortingOrder = 999;
        // Attach this script to handle movement and destruction
        Destroy(textObject, destroyTime);
    }

    void Update()
    {
        if (textObject != null)
            textObject.transform.Translate(Vector3.up * floatSpeed * Time.deltaTime);
    }
}