using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxMovement : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    [SerializeField] private float screenLimit = 7f;

    [SerializeField] private Rigidbody2D rb;

    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        limitmove();
        movebox();
    }

    void movebox(){
        
        float moveInput = Input.GetAxis("Horizontal");

        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
    }
    
    void limitmove(){

        float clampedX = Mathf.Clamp(transform.position.x, -screenLimit, screenLimit);
        transform.position = new Vector3(clampedX, transform.position.y, transform.position.z);

    }
}
