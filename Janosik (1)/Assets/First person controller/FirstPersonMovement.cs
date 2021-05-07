using UnityEngine;

public class FirstPersonMovement : MonoBehaviour
{
    public float speed = 5;
    Vector2 velocity;


    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            velocity.y = Input.GetAxis("Vertical") * speed * 2 * Time.deltaTime;
            velocity.x = Input.GetAxis("Horizontal") * speed * 2 * Time.deltaTime;
            transform.Translate(velocity.x, 0, velocity.y);
        }
        else
        {
            velocity.y = Input.GetAxis("Vertical") * speed * Time.deltaTime;
            velocity.x = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
            transform.Translate(velocity.x, 0, velocity.y);
        }
    }
}
