using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Collider2D col;
    public ParticleSystem particleSystem;
    
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
        Physics2D.IgnoreLayerCollision(gameObject.layer, LayerMask.NameToLayer("IgnoreBoatCollision"));
        //particleSystem = particleObject.GetComponent<ParticleSystem>();
    }
    
    private void FixedUpdate()
    {
        Vector2 movement = Input.GetAxis("Vertical") * transform.up;
        float forwardVelocity = Mathf.Abs(transform.InverseTransformDirection(rb.velocity).y);
        float turningSpeed = -Input.GetAxis("Horizontal") * forwardVelocity * 20 * Time.deltaTime;
        transform.Rotate(new Vector3(0, 0, turningSpeed));
        rb.AddForce(movement);
        UpdateParticleSystem();
        
    }

    private void UpdateParticleSystem()
    {
        if (rb.velocity != Vector2.zero) particleSystem.transform.forward = Quaternion.Euler(0, 0, -180) * rb.velocity.normalized;
        particleSystem.startSpeed = rb.velocity.magnitude * 5;
    }
}
