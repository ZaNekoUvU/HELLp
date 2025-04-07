using UnityEngine;

public class SoulPickupEffect : MonoBehaviour
{
    public int soulFragmentCount;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("SoulFragment"))
        {
            soulFragmentCount = soulFragmentCount + 1;
           Destroy(other.gameObject);
        }
    }
}
