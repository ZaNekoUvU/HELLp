using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    [SerializeField] private float health = 100f;
    [SerializeField] private float playerHealth = GameObject.Find("Player").GetComponent<Health>().health;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playerHealth <= 0)
        {
            SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
        }
    }

    public void TakeDamage(float damage)
    {
        health = health - damage; 
    }
}
