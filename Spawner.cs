using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Spawner : MonoBehaviour
{
	public Transform[] spawnPoints;
	public GameObject[] hazzards;

	public GameObject player;
	private float timeBtSpawns;
	public float startTimeBtSpawns;

	//Below is used to create max diff, fastest time for spawn
	public float minTimeBtSpawn;

	// Determine how much you want to descrease spawn time
	public float descrease;

	void Update()
	{
		// if statement created to avoid error message when player dies
		if (player != null)
		{
			//Tell to spawn new hazard if time between spawns is less than or equal to 0
			if (timeBtSpawns <= 0)
			{

				//Need to chose random spawn point and random hazzard from array
				Transform randomSpawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
				GameObject randomHazard = hazzards[Random.Range(0, hazzards.Length)];


				//Reads: Spawn object at random range of Spawn Points and keep rotation the same
				Instantiate(randomHazard, randomSpawnPoint.position, Quaternion.identity);// <- No particular rotation 

				timeBtSpawns = startTimeBtSpawns; // <- resets timer to starting value 
				if (startTimeBtSpawns > minTimeBtSpawn)
				{
					startTimeBtSpawns -= descrease;
				}
			}
			else
			{
				//acts as counter for it to reach 0 to spawn
				timeBtSpawns -= Time.deltaTime;
				minTimeBtSpawn += Time.deltaTime;
			}

			


		}
	}

}
		
