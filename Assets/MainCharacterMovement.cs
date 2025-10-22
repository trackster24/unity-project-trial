using UnityEngine;
using UnityEngine.InputSystem;

public class MainCharacterMovement : MonoBehaviour
{
    public float speed = 5f;

    void Update()
    {
        Vector2 input = Vector2.zero;

        if (Keyboard.current.wKey.isPressed)
            input.y += 1;
        if (Keyboard.current.sKey.isPressed)
            input.y -= 1;
        if (Keyboard.current.aKey.isPressed)
            input.x -= 1;
        if (Keyboard.current.dKey.isPressed)
            input.x += 1;

        Vector3 move = new Vector3(input.x, 0, input.y).normalized;

        transform.Translate(move * speed * Time.deltaTime);
    }
}
