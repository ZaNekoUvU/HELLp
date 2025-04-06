using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHeatlh : MonoBehaviour
{
    float maxHealth = 100f;
    [SerializeField] private float health;

    void Start()
    {
        health = maxHealth;
    }

    void Update()
    {

    }

    public void TakeDamage(float damage)
    {
        health = health - damage;
        if (health <= 0)
        {
            //Destroy(gameObject);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}