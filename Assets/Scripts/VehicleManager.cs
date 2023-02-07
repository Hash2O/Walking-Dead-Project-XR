using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleManager : MonoBehaviour
{
    public GameObject[] vehiclePrefabs;

    private float startDelay = 1.0f;
    private float spawnInterval;

    // Start is called before the first frame update
    void Start()
    {
            spawnInterval = Random.Range(4.0f, 5.0f); //M�thode appel�e une fois au d�marrage
            InvokeRepeating("SpawnRandomVehicle", startDelay, spawnInterval);     
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnRandomVehicle()
    {
        int vehicleIndex = Random.Range(0, vehiclePrefabs.Length);

        Vector3 spawnPos = new Vector3(-45.8f, 0.0f, -73.0f);

        Instantiate(vehiclePrefabs[vehicleIndex], spawnPos,
            vehiclePrefabs[vehicleIndex].transform.rotation);
    }
}
