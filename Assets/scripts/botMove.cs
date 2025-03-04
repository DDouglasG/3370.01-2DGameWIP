using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class botMove : MonoBehaviour {

    float speedX;
    public float speed;
    public float jump;

    Rigidbody2D rb;
    private bool isFacingRight = true;

    public Transform inGround;
    public LayerMask groundLayer;
    bool isGrounded;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update() {
        isGrounded = Physics2D.OverlapCapsule(inGround.position, new Vector2(0.5f, 0.1f), CapsuleDirection2D.Horizontal, 0, groundLayer);
        
        speedX = Input.GetAxisRaw("Horizontal") * speed;
        rb.linearVelocity = new Vector2(speedX, rb.linearVelocity.y);


        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetButtonDown("Jump"))) { // && isGrounded
            Debug.Log("Jumping!");  // Debug message
            rb.AddForce(Vector2.up * jump, ForceMode2D.Impulse);
        }



        Flip();
    }

    private void Flip()
    {
        if (isFacingRight && speedX >0f || !isFacingRight && speedX < 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }

    }

}
