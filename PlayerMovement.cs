using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;



public class PlayerMovement : MonoBehaviour
{
    public float speed;
    private float input;

    Animator Anime;
    Rigidbody2D rb;
    public int Health;


    // Start is called b4 the 1st frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        //Animation Transition Control via C#
        Anime = GetComponent<Animator>();
    }

    private void Update()
    {
        //Running animation On off switch 
        if (input != 0)
        {
            Anime.SetBool("IsRunning", true);
        }

        else
        {
            Anime.SetBool("IsRunning", false);
        }

        //Running animation to flip Player when moving left| Rotation 180
        if (input > 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);

        }

        else if (input < 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }

    }
    // Update is called once per frame
    void FixedUpdate()

    {
        //Storing player's input
        input = Input.GetAxisRaw("Horizontal");
        //Moving player 
        rb.velocity = new Vector2(input * speed, rb.velocity.y);

    }


    public void TakeDamage ( int damageAmount)
    {
        Health -= damageAmount;
            
            if (Health <=0)
            // Remove the player from game is they die 
            {
                 Destroy(gameObject);
            }
        }
}




 





    






