using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private float playerAttack = 10f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(Input.mousePosition);

        if (Input.GetMouseButtonDown(0))
        {

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (Input.GetMouseButton(1))
        {
            GameObject.FindGameObjectWithTag("Enemy").GetComponent<Health>().TakeDamage(playerAttack);
        }
    }
}
