
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

public class MainCharacterMovement : MonoBehaviour
{
    public InputActionAsset playerControls;
    private CharacterController charController;
    private Camera mainCamera;

    private Vector2 moveInput;
    private Vector2 lookInput;
    private Vector3 movement = Vector3.zero;

    // Movement Constants
    private float speed = 5f;
    private float jumpSpeed = 8f;
    private float gravity = 20f;
    private float speedMultiplier = 2f;
    private float verticalRotation = 0;
    private int jumpCounter = 2;
    private float mouseSensitivity = .5f;

    // Attached Game Objects
    public GameObject bulletPrefab;
    public Transform firePosition;

    // Actions
    private InputAction moveAction;
    private InputAction lookAction;
    private InputAction jumpAction;
    private InputAction sprintAction;
    private InputAction shootAction;


    private void Awake()
    {
        charController = GetComponent<CharacterController>();
        mainCamera = GetComponentInChildren<Camera>();

        moveAction = playerControls.FindActionMap("Player").FindAction("Move");
        jumpAction = playerControls.FindActionMap("Player").FindAction("Jump");
        lookAction = playerControls.FindActionMap("Player").FindAction("Look");
        sprintAction = playerControls.FindActionMap("Player").FindAction("Sprint");
        shootAction = playerControls.FindActionMap("Player").FindAction("Attack");

        moveAction.performed += ctx => moveInput = ctx.ReadValue<Vector2>();
        moveAction.canceled += ctx => moveInput = Vector2.zero;

        lookAction.performed += context => lookInput = context.ReadValue<Vector2>();
        lookAction.canceled += context => lookInput = Vector2.zero;

        Cursor.visible = false;
    }

    void Update()
    {
        HandleLooking();
        HandleMoving();

        if (shootAction.triggered)
        {
            GameObject bullet = Instantiate(bulletPrefab, firePosition.position, Quaternion.identity);
            bullet.GetComponent<Rigidbody>().AddForce(firePosition.forward * 100, ForceMode.Impulse);
        }
    }

    void HandleLooking()
    {
        float mouseXRotation = lookInput.x * mouseSensitivity;
        transform.Rotate(0, mouseXRotation, 0);

        verticalRotation -= lookInput.y * mouseSensitivity;
        verticalRotation = Mathf.Clamp(verticalRotation, -20, 10);
        mainCamera.transform.localRotation = Quaternion.Euler(verticalRotation, 0, 0);
    }

    void HandleMoving()
    {
        float verticalSpeed = moveInput.y * speed;
        float horizontalSpeed = moveInput.x * speed;
        float speedInput = (sprintAction.ReadValue<float>() > 0) ? speedMultiplier : 1f;

        if (charController.isGrounded)
        {
            jumpCounter = 2;
            if (jumpAction.triggered)
            {
                movement.y = jumpSpeed;
                jumpCounter -= 1;
            }
        }
        else if (jumpAction.triggered && jumpCounter > 0)
        {
            movement.y = jumpSpeed;
            jumpCounter -= 1;
        }
        else
        {
            movement.y -= gravity * Time.deltaTime;
        }


        movement.x = horizontalSpeed * speedInput;
        movement.z = verticalSpeed * speedInput;
        Vector3 totalMovement = transform.rotation * movement;

        charController.Move(totalMovement * Time.deltaTime);
    }
}
