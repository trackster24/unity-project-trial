
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

public class MainCharacterMovement : MonoBehaviour
{
    public InputActionAsset playerControls;
    private CharacterController charController;

    private Vector2 moveInput;
    private Vector2 lookInput;

    public float speed = 5f;

    private InputAction moveAction;
    private InputAction lookAction;

    private void Awake()
    {
        charController = GetComponent<CharacterController>();

        moveAction = playerControls.FindActionMap("Player").FindAction("Move");
        lookAction = playerControls.FindActionMap("Player").FindAction("Look");

        moveAction.performed += ctx => moveInput = ctx.ReadValue<Vector2>();
        moveAction.canceled += ctx => moveInput = Vector2.zero;

        lookAction.performed += context => lookInput = context.ReadValue<Vector2>();
        lookAction.canceled += context => lookInput = Vector2.zero;
    }

    void Update()
    {
        HandleLooking();
        HandleMoving();
    }

    void HandleLooking()
    {
        float mouseXRotation = lookInput.x;
        transform.Rotate(0, mouseXRotation, 0);
    }

    void HandleMoving()
    {
        float verticalSpeed = moveInput.y * speed;
        float horizontalSpeed = moveInput.x * speed;

        Vector3 movement = new Vector3(horizontalSpeed, 0, verticalSpeed);
        movement = transform.rotation * movement;

        charController.Move(movement * Time.deltaTime);
    }
}
