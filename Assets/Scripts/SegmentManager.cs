using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SegmentManager : MonoBehaviour {

    public GameObject[] tilePrefabs;

    public Transform playerTransform;

    private float spawnZ = 0.0f;

    private float tileLength = 400.0f;
    private int amnTilesOnScreen = 2;

    private float safeZone =300.0f;
    private int lastPrefabIndex = 0; 

    private List<GameObject> activeTiles;


	// Use this for initialization
	void Start ()
    {
        activeTiles = new List<GameObject>();
        if (GameObject.FindGameObjectWithTag("Player"))
        {
            playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        }
        else if (GameObject.FindGameObjectWithTag("Player1"))
        {
            playerTransform = GameObject.FindGameObjectWithTag("Player1").transform;

        }
        else if (GameObject.FindGameObjectWithTag("Player2"))
        {
            playerTransform = GameObject.FindGameObjectWithTag("Player2").transform;
        }
        else if (GameObject.FindGameObjectWithTag("Player3"))
        {
            playerTransform = GameObject.FindGameObjectWithTag("Player3").transform;
        }
        else if (GameObject.FindGameObjectWithTag("Player4"))
        {
            playerTransform = GameObject.FindGameObjectWithTag("Player4").transform;
        }
        else if (GameObject.FindGameObjectWithTag("Player5"))
        {
            playerTransform = GameObject.FindGameObjectWithTag("Player5").transform;
        }

       for(int i = 0; i<amnTilesOnScreen; i++)
        {
            SpawnTile();
        }
    }
	
	// Update is called once per frame
	void Update () {
		if(playerTransform.position.z - safeZone >(spawnZ - amnTilesOnScreen * tileLength))
        {
            SpawnTile();
            DeleteTile();
        }
	}

    private void SpawnTile(int prefabIndex = -1)
    {
        GameObject go;

        go = Instantiate(tilePrefabs[RandomPrefabIndex()]) as GameObject;
        go.transform.SetParent(transform);
            go.transform.position = Vector3.forward * spawnZ;
        spawnZ += tileLength;
        activeTiles.Add(go);

    }

    private void DeleteTile()
    {
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
    }

    private int RandomPrefabIndex()
    {
        if(tilePrefabs.Length <= 1)
        {
            return 0;
        }
        int randomIndex = lastPrefabIndex;
        while(randomIndex == lastPrefabIndex)
        {
            randomIndex = Random.Range(0, tilePrefabs.Length);
        }

        lastPrefabIndex = randomIndex;
        return randomIndex;
    }
}
