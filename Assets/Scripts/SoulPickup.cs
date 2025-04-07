using UnityEngine;

public class SoulPickup : MonoBehaviour
{
    [SerializeField] private int soul;
    [SerializeField] private GameObject bossPrefab;
    private GameObject boss;
    private bool bossDead = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (soul >= 10)
        {
            if (boss == null && bossDead)
            {
                boss = Instantiate(bossPrefab);
                boss.transform.position = GameObject.Find("Boss Spawner").transform.position;
                bossDead = false;
            }
        }
    }
    //When the Soul collides with player
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("SoulFragment"))
        {
            soul++;
            Object.Destroy(other.gameObject);
        }
    }
}
