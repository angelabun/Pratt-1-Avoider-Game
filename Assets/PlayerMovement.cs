using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public ForceMode2D forceMode;
    public float jumpStatus;

    public float jumpPower;

    private float movement;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (jumpStatus > 0f)
        {
            rb.AddForce(new Vector2(0, jumpPower), forceMode);
            // OR rb.AddForce(new Vector(Vector2.up * jumpPower));
            // rb.AddForce(new Vector2(0, jumpPower), ForceMode2D.Impulse);
        }
    }

    public void OnJump(InputValue input)
    {
        jumpStatus = input.Get<float>();
        
    }

    public void OnMovement(InputValue input)
    {
        movement = input.Get<float>();
    }
}
