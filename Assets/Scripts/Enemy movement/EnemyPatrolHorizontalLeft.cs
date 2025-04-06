using UnityEngine;

public class EnemyPatrolHorizontalLeft : MonoBehaviour
{
    [SerializeField] float moveSpeed = 1f;

    private bool movingLeft = true;

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

    private void Flip()
    {
        Vector3 localScale = transform.localScale;
        localScale.x *= -1; // Flip X
        transform.localScale = localScale;
    }
}