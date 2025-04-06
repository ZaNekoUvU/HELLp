using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float speed = 3f;
    [SerializeField] private float jumpPower = 7f;

    private int jump = 0;
    private bool isGrounded = false;
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
        }
        else if (Input.GetKey(KeyCode.D) && airSpeed > 0)
        {
            horizontalInput = 1;
        }

        if (Input.GetKeyDown(KeyCode.Space) && jump > 0)
        {
            rb.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            jump--;

            isGrounded = false;
        }

        rb.linearVelocity = new Vector2(horizontalInput * speed, rb.linearVelocity.y);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            jump = 2;

            isGrounded = true;
        }
    }
}