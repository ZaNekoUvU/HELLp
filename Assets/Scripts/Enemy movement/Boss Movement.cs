using UnityEngine;

public class BossMovement : MonoBehaviour
{
    public DetectionZone attackZone;
    [SerializeField] float moveSpeed = 10f;
    Animator bossAnimator;


    private bool movingLeft = true;
    private bool _hasTarget = false;
    private bool _isHurting = false;

    public AudioSource damageSound;

    private void Awake()
    {
        bossAnimator = GetComponent<Animator>();
        damageSound = GetComponent<AudioSource>();
    }
    public bool HasTarget
    {
        get { return _hasTarget; }
        private set
        {
            _hasTarget = value;
            bossAnimator.SetBool("HasTarget", value);
        }
    }

    public bool IsHurting
    {
        get { return _isHurting; }
        private set
        {
            _isHurting = value;
            bossAnimator.SetBool("IsHurting", value);
        }
    }

    void Update()
    {
        if (!HasTarget)
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


        HasTarget = attackZone.detectedColliders.Count > 0;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            movingLeft = !movingLeft;
            Flip();
        }

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

    private void Stop()
    {
        Vector3 currentPos = transform.position;
        float tempX;
        tempX = currentPos.x;


    }
}