using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Vector2 moveDirection;

    void Update()
    {
        moveDirection.x = Input.GetAxisRaw("Horizontal");
        moveDirection.y = Input.GetAxisRaw("Vertical");
        moveDirection.Normalize(); // I feel like this feels too slow but will keep it for now

        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
    }
}
