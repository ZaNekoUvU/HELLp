using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private GameObject halo;
    [SerializeField] private float speed = 10f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var go = Instantiate(halo, transform.position, Quaternion.identity);

            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 direction = mousePosition - new Vector2(transform.position.x, transform.position.y);
            direction.Normalize();

            go.GetComponent<Rigidbody2D>().linearVelocity = new Vector2(direction.x, direction.y) * speed;
        }
    }
}
