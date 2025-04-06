using UnityEngine;

public class PlayerHeatlh : MonoBehaviour
{
    [SerializeField] private float health = 100f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(float damage)
    {
        health = health - damage; 
    }
}
