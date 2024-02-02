using UnityEngine;
//using System.Collections;

public class PlayerMovement : MonoBehaviour {
    private Rigidbody2D rb;
    private Animator An;

    public float moveSpeed = 10f;
    public float jumpForce = 400f;
    public float maxVeloX = 4f;
    private bool grounded;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        An = GetComponent<Animator>();
    }
    void FixedUpdate()
    {
        Vector2 force = new Vector2(0f, 0f);

        float moveHoriz = Input.GetAxis("Horizontal");

        float absVelocityX = Mathf.Abs(rb.velocity.x);
        float absVelocityY = Mathf.Abs(rb.velocity.y);

        if (absVelocityY == 0) { grounded = true; }
        else { grounded = false; }
        //Set X force
        if (absVelocityX < maxVeloX) { force.x = (moveSpeed * moveHoriz); }

        if (grounded && Input.GetButton("Jump"))
        {
            grounded = false;
            force.y = jumpForce;
            An.SetInteger("AnimState", 2);
        }
        if (grounded && Input.GetButton("Horizontal"))
        {
            An.SetInteger("AnimState", 1);
            if (moveHoriz < 0) {  transform.localScale = new Vector3(-1, 1, 1); }
            if (moveHoriz > 0) {  transform.localScale = new Vector3(1, 1, 1); }
        }
        else if (grounded) { An.SetInteger("AnimState", 0); }
        //Setup force vector
        rb.AddForce(force);
    }


}
