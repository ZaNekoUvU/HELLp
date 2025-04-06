using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 3f;
    [SerializeField] private float jumpPower = 7f;

    private int jump = 0;
    private bool isGrounded = false;
    [SerializeField] private float airSpeed = 5f;
    private Rigidbody2D rb;

    Animator playerAnimator;

    private bool _isMoving = false;
    private bool _isJumping = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public bool IsMoving
    {
        get { return _isMoving; }
        private set
        {
            _isMoving = value;
            playerAnimator.SetBool("IsMoving", value);
        }
    }

    public bool IsJumping
    {
        get { return _isJumping; }
        private set
        {
            _isJumping = value;
            playerAnimator.SetBool("IsJumping", value);
        }
    }

    private void Awake()
    {
        playerAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        float horizontalInput = 0;

        horizontalInput = 0;
        if (Input.GetKey(KeyCode.A) && airSpeed > 0)
        {
            Vector3 localScale = transform.localScale;
            localScale.x *= -1;
            transform.localScale = localScale;

            horizontalInput = -1;
            IsMoving = true;
        }
        else if (Input.GetKey(KeyCode.D) && airSpeed > 0)
        {
            Vector3 localScale = transform.localScale;
            localScale.x *= -1;
            transform.localScale = localScale;

            horizontalInput = 1;
            IsMoving = true;
        }
        else
        {
            IsMoving = false;
        }

        if (Input.GetKeyDown(KeyCode.Space) && jump > 0)
        {
            rb.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            jump--;

            isGrounded = false;
        }

        if (isGrounded)
        { IsJumping = true; }

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