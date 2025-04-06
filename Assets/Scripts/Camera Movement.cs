using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private Transform playerTransform;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerTransform = GameObject.Find("Player").transform; // Find the player and ger its transform
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = new Vector2(this.transform.position.x, playerTransform.position.y);
    }
}
