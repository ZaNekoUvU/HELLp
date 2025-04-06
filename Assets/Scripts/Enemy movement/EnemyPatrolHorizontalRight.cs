using UnityEngine;

public class EnemyPatrolHorizontalReft : MonoBehaviour
{
    [SerializeField] float moveSpeed = 1f;

    private bool movingRight = true;

    void Update()
    {
        if (movingRight)
        {
            transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        movingRight = !movingRight;
        Flip();
    }

    private void Flip()
    {
        Vector3 localScale = transform.localScale;
        localScale.x *= -1; // Flip X
        transform.localScale = localScale;
    }
}