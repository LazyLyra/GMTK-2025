using UnityEngine;

public class PlayerMovement2D : MonoBehaviour
{
    public float moveSpeed = 5f;

    void Update()
    {
        // Get 2D input
        float moveX = Input.GetAxis("Horizontal");  
        float moveY = Input.GetAxis("Vertical");

        // Movement vector
        Vector3 move = new Vector3(moveX, moveY, 0);

        // Apply movement
        transform.position += move * moveSpeed * Time.deltaTime;
    }
}
