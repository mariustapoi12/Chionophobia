using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Rendering;

public class AddSnow : MonoBehaviour
{
    private float elapsedTime = 0.0f;
    private int count = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;
        if (elapsedTime >= 30.0f && count < 4)
        {
            count++;

            var terrainLayers = GetComponent<Terrain>().terrainData.terrainLayers;

            var myList = new List<TerrainLayer>(terrainLayers);

            // Remove the first element from the list
            var firstElement = myList[0];
            myList.RemoveAt(0);

            // Add the first element to the end of the list
            myList.Add(firstElement);

            // Convert the list back to an array
            myList.CopyTo(terrainLayers);

            GetComponent<Terrain>().terrainData.terrainLayers = terrainLayers;
            
            elapsedTime = 0.0f;
        }
    }

    void OnApplicationQuit()
    {
        while (count < 5)
        {
            count++;

            var terrainLayers = GetComponent<Terrain>().terrainData.terrainLayers;

            var myList = new List<TerrainLayer>(terrainLayers);

            // Remove the first element from the list
            var firstElement = myList[0];
            myList.RemoveAt(0);

            // Add the first element to the end of the list
            myList.Add(firstElement);

            // Convert the list back to an array
            myList.CopyTo(terrainLayers);

            GetComponent<Terrain>().terrainData.terrainLayers = terrainLayers;
        }
    }
}