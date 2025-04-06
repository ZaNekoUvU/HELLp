using UnityEngine;

public class SoulPickup : MonoBehaviour
{
    //When the Soul collides with player
    private void OnCollisionEnter2D(Collision2D other)
    {
        Object.Destroy(this.gameObject);
    }
}
