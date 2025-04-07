using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    [SerializeField] private float health = 100f;
    [SerializeField] private float playerHealth ;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        playerHealth = GameObject.Find("Player").GetComponent<Health>().health;
        if (playerHealth <= 0)
        {
            SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
        }

        if (health <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    public void TakeDamage(float damage)
    {
        health = health - damage; 
    }
}
