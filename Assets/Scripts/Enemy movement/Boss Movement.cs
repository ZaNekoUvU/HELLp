using UnityEngine;

public class BossMovement : MonoBehaviour
{
    public DetectionZone attackZone;
    [SerializeField] float moveSpeed = 10f;
<<<<<<< Updated upstream
    Animator animator;
=======
    [SerializeField] private float turnDelay = 5f;

    Animator bossAnimator;
>>>>>>> Stashed changes

    private bool movingLeft = true;
    private bool waitingTurn = false;
    private float turnTimer = 0f;

    private bool _hasTarget = false;
    private bool _isHurting = false;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public bool HasTarget
    {
        get { return _hasTarget; }
        private set
        {
            _hasTarget = value;
            animator.SetBool("HasTarget", value);
        }
    }

    /*public bool IsHurting
    {
        get { return _isHurting; }
        private set
        {
            _isHurting = value;
            animator.SetBool("IsHurting", value);
        }
    }*/

    void Update()
    {
        if (waitingTurn)
        {
            turnTimer = Time.deltaTime;

            if (turnTimer >= turnDelay)
            {
                movingLeft = !movingLeft;
                waitingTurn = false;
                turnTimer = 0f;
            }

            return;
        }
        if (turnTimer == 0)
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
        movingLeft = !movingLeft;
        Flip();
    }

    private void Flip()
    {
        Vector3 localScale = transform.localScale;
        localScale.x *= -1; // Flip X
        transform.localScale = localScale;
    }
}