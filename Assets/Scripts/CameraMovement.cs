using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private Transform playerTransform;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerTransform = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(transform.position.x, playerTransform.position.y);
    }
}
