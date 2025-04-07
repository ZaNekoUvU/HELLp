using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SoulPickup : MonoBehaviour
{
    [SerializeField] private int soul = 0;
    [SerializeField] private GameObject bossPrefab;
    [SerializeField] private TMP_Text SoulCountText;



    private GameObject boss;
    private bool bossDead = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SoulCountText = GameObject.Find("Soul Counter").GetComponent<TMP_Text>();
        
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
            UpdateSoulCountText();

        }

    }
    private void UpdateSoulCountText()
    {
        SoulCountText.text = "Souls: " + soul.ToString();
    }
}
