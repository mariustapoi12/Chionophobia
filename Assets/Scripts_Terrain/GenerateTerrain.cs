using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Voxel : MonoBehaviour
{
	[Range(2, 100)] public int length = 30;
	public GameObject objectToSpawn;
	public GameObject cube;
	public GameObject player;
	public int detailScale = 8;
	public int noiseHeight = 3;
	public List<GameObject> blockList;
	private Vector3 startPos = Vector3.zero;
	private Hashtable cubePos;

	private int XPlayerMove => (int)(player.transform.position.x - startPos.x);
	private int ZPlayerMove => (int)(player.transform.position.z - startPos.z);

	private int XPlayerLocation => (int)Mathf.Floor(player.transform.position.x);
	private int ZPlayerLocation => (int)Mathf.Floor(player.transform.position.z);

	// Start is called before the first frame update
	void Start()
	{
		cubePos = new Hashtable();
		GenerateTerrain(length);
	}

	private void Update()
	{
		if (Mathf.Abs(XPlayerMove) >= 1 || Mathf.Abs(ZPlayerMove) >= 1)
		{
			GenerateTerrain(length);
		}
	}

	private void GenerateTerrain(int length)
	{
		for (int x = -length; x < length; x++)
		{
			for (int z = -length; z < length; z++)
			{

				Vector3 pos = new Vector3(x + XPlayerLocation,
				yNoise(x + XPlayerLocation, z + ZPlayerLocation, detailScale) * noiseHeight,
				z + ZPlayerLocation);

				if (!cubePos.ContainsKey(pos))
				{
					var playerManhattanDistance = (player.transform.position.x + player.transform.position.z) / 16;

					cube.transform.localScale = new Vector3(1, playerManhattanDistance + 1, 1);

					GameObject cubeInstance = Instantiate(cube, pos, Quaternion.identity, transform);

					var currentColor = cubeInstance.GetComponent<MeshRenderer>().material.color;

					currentColor.r += Mathf.Abs(playerManhattanDistance) / 4;
					currentColor.g += Mathf.Abs(playerManhattanDistance) / 4;
					currentColor.b += Mathf.Abs(playerManhattanDistance) / 4;

					cubeInstance.GetComponent<MeshRenderer>().material.color = currentColor;

					blockList.Add(cubeInstance);


					cubePos.Add(pos, cubeInstance);

					if (Random.Range(0, 100) == 0)
					{
						pos.y += cube.transform.localScale.y / 2;
						Instantiate(objectToSpawn, pos, Quaternion.identity);
					}

				}
			}
		}
	}

	private float yNoise(int x, int z, float detailScale)
	{
		float xNoise = (x + transform.position.x) / detailScale;
		float zNoise = (z + transform.position.y) / detailScale;
		return Mathf.PerlinNoise(xNoise, zNoise);
	}
}