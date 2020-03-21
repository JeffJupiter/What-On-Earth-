using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTwo : MonoBehaviour {


	public float MinSpeed;
	public float MaxSpeed;
	public float Speed;
	public int Damage;

	PlayerMovement playerScript; 

	void Start()
	{
		// Speed is determined by a random range between Min & Max
		Speed = Random.Range(MinSpeed, MaxSpeed);
		// This means that we are caling on the script from another script, 
		playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
		
	}
	// tranform.Translate = move object around  || * deltaTime makes effect the same regadless of || down literally means down 


	void Update()
	{

		transform.Translate(Vector2.down * Speed * Time.deltaTime);
	}
	// Once the object collids the console will read the below statment. Used for testing. 
	
	 void OnTriggerEnter2D(Collider2D hitObject)
    {

		if (hitObject.tag == "Player")
		{
			playerScript.TakeDamage(Damage);
			Debug.Log("Hit the player");
			{
				Destroy(gameObject);
			}
		}
		
			if (hitObject.tag == "Ground")
		{
			Destroy(gameObject);
		}

		}
    }

