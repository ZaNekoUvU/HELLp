using UnityEngine;

public class EnemyPatrolVertical : MonoBehaviour
{
    [SerializeField] float moveSpeed = 1f;

    private bool movingUp = true;

    void Update()
    {
        if (movingUp)
        {
            transform.Translate(Vector2.up * moveSpeed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector2.down * moveSpeed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        movingUp = !movingUp;
        Flip();
    }

    private void Flip()
    {
        Vector3 localScale = transform.localScale;
        localScale.y *= -1; // Flip Y
        transform.localScale = localScale;
    }
}