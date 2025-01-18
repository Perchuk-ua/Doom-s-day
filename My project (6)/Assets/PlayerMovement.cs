using UnityEngine;

public class PlayerMovementSimple : MonoBehaviour
{
    public float speed = 5f;

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {
            Vector3 moveDirection = transform.forward * vertical + transform.right * horizontal;
            moveDirection.y = 0f; // Вимкнення руху по вертикалі

            transform.Translate(moveDirection * speed * Time.deltaTime, Space.World);
        }
    }
}