using UnityEngine;

public class FlyingHorizontalMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 1f;

    private bool movingLeft = true;

    public AudioSource damageSound;

    private void Start()
    {
        damageSound = GetComponent<AudioSource>();

    }

    void Update()
    {
        if (movingLeft)
        {
            transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        movingLeft = !movingLeft;
        Flip();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            damageSound.Play();

            Health playerHealth = collision.gameObject.GetComponent<Health>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(20f);
            }
        }
    }

    private void Flip()
    {
        Vector3 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }
}