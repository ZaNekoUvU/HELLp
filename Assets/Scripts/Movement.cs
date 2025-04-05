using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    [SerializeField] private int jump = 0;
    [SerializeField] private bool isGrounded = false;
    [SerializeField] private float airSpeed = 5f;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float horizontalInput = 0;

        horizontalInput = 0;
        if (Input.GetKey(KeyCode.A) && airSpeed > 0)
        {
            horizontalInput = -1;

            if (!isGrounded && airSpeed > 0)
            {
                horizontalInput *= airSpeed / speed; // use airSpeed when not grounded
                airSpeed -= 0.04f;
            }
        }
        else if (Input.GetKey(KeyCode.D) && airSpeed > 0)
        {
            horizontalInput = 1;

            if (!isGrounded && airSpeed > 0 )
            {

                horizontalInput *= airSpeed / speed; // use airSpeed when not grounded
                airSpeed -= 0.04f;
            }
        }

        if (Input.GetKeyDown(KeyCode.Space) && jump > 0)
        {
            rb.AddForce(Vector2.up * speed, ForceMode2D.Impulse);
            jump--;

            isGrounded = false;

            if (!isGrounded)
            {
                airSpeed += 5f;

                if (airSpeed > 10f)
                {
                    airSpeed = 10f;
                }
            }
        }

        rb.linearVelocity = new Vector2(horizontalInput * speed, rb.linearVelocity.y);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            jump = 2;

            isGrounded = true;

            airSpeed = 10f;
        }
    }
}