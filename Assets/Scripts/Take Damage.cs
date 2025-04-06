using UnityEngine;

public class TakeDamage : MonoBehaviour
{
    public int damage;
    //public PlayerHeatlh playerHeatlh;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //playerHeatlh.TakeDamage(damage);
        }
    }
}