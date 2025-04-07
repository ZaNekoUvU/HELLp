using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    [SerializeField] private float health = 100f;
    private float maxHealth;
    [SerializeField] private float playerHealth = 100f;
    [SerializeField] private Light2D lightIntensity;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        maxHealth = health;

        if (lightIntensity == null)
        {
            lightIntensity = GetComponent<Light2D>();
        }
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

        if (lightIntensity != null)
        {
            lightIntensity.intensity = Mathf.Clamp01(health);
        }
    }

    public void TakeDamage(float damage)
    {
        health = health - damage; 
    }
}
