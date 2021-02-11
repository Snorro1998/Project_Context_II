using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Collider2D col;
    
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
        //Physics.IgnoreLayerCollision(gameObject.layer, LayerMask.NameToLayer("IgnoreBoatCollision"));
        Physics2D.IgnoreLayerCollision(gameObject.layer, LayerMask.NameToLayer("IgnoreBoatCollision"));
    }
    
    private void FixedUpdate()
    {
        Vector2 movement = Input.GetAxis("Vertical") * transform.up;
        float forwardVelocity = Mathf.Abs(transform.InverseTransformDirection(rb.velocity).y);
        float turningSpeed = -Input.GetAxis("Horizontal") * forwardVelocity * 20 * Time.deltaTime;

        transform.Rotate(new Vector3(0, 0, turningSpeed));
        rb.AddForce(movement);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        //Physics2D.IgnoreLayerCollision
        //Physics2D.IgnoreCollision(col, collision.collider);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Physics2D.IgnoreCollision(col, collision.collider);
        /*
        if (collision.gameObject.layer != LayerMask.NameToLayer("BoatCollision"))
        {
            Physics2D.IgnoreCollision(col, collision.collider);
            //Physics.IgnoreCollision(rb.collider, collider);
        }
        */
    }
}
