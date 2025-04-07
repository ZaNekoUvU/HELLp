using UnityEngine;

public class HaloDamage : MonoBehaviour
{
    private float playerAttack = 10f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<Health>().TakeDamage(playerAttack);
            Destroy(this.gameObject);
        }
        else if (collision.gameObject.layer != LayerMask.NameToLayer("Player"))
        {
            Destroy(this.gameObject);
        }
    }
}
