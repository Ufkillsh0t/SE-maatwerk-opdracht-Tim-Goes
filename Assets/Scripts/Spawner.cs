using UnityEngine;
using System.Collections;
using System;

public class Spawner : MonoBehaviour {

    public GameObject objectToSpawn;
    public int SpawnCount = 5;
    public float maxX = 100F;
    public float maxZ = 100F;
    public Vector3 spawnPoint;

	// Use this for initialization
	void Start () {
	    for(int i = 0; i < SpawnCount; i++)
        {
            Spawn();
        }
	}

    // Update is called once per frame
    void Update () {
        GameObject[] gos = GameObject.FindGameObjectsWithTag(objectToSpawn.name); //Zoekt naar alle objecten met de tag enemy
        if(gos.Length < SpawnCount)
        {
            Spawn();
        }
	}

    private void Spawn()
    {
        GenerateNewSpawnPoint();
        SpawnGameObject();
    }

    private void GenerateNewSpawnPoint()
    {
        float randomX = UnityEngine.Random.Range(0F, (maxX * 2)) - maxX;
        float randomZ = UnityEngine.Random.Range(0F, (maxZ * 2)) - maxZ;
        float ySpawnPoint = Terrain.activeTerrain.GetPosition().y; //misschien Terrain.activeTerrain.SampleHeight(new Vector3(randomX, 0, randomZ)); voor betere spawnpoints.

        spawnPoint = new Vector3(randomX, ySpawnPoint, randomZ);
    }

    private void SpawnGameObject()
    {
        GameObject toSpawn = objectToSpawn;
        toSpawn = Instantiate(objectToSpawn, spawnPoint, Quaternion.identity) as GameObject; //Spawnt het object op het gegenereerde spawnpoint.
        Debug.Log("Object:" + gameObject.name + "[Spawned]" + "[x]" + spawnPoint.x + "[Y]" + spawnPoint.y + "[z]" + spawnPoint.z);
    }
}
