using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class PlayerCharacterController : MonoBehaviour
{

    [SerializeField]
    private float playerSpeed = 2.0f;
    [SerializeField]
    private float jumpHeight = 1.0f;
    [SerializeField]
    private float gravityValue = -9.81f;

    [SerializeField]
    private Vector2 _axisInput;
     public Vector2 AxisInput
    {
        get => _axisInput;
    }
    [SerializeField]
    private bool _isAttackPressed = false;
     public bool IsAttackPressed
    {
        get => _isAttackPressed;
    }

    [SerializeField]
    private bool _isJumpPressed = false;
     public bool IsJumpPressed
    {
        get => _isJumpPressed;
    }

    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
   
     // InputActions_Player
     private InputActions_Player _playerInput;

    private void Awake() 
    {
        _playerInput = new InputActions_Player();
    }

    private void OnEnable() 
    {
        _playerInput.Enable();
    }

    private void OnDisable()
    {
        _playerInput.Disable();
    }

    public void MovementOnPreformed(InputAction.CallbackContext context)
    {
        _axisInput = context.ReadValue<Vector2>();
        // Debug.Log("Moving");
    }

    public void AtackOnPreformed(InputAction.CallbackContext context)
    {
        _isAttackPressed = false;
        _isAttackPressed = context.action.triggered;
        // Debug.Log("Attack");
    }

    public void JumpOnPreformed(InputAction.CallbackContext context)
    {
        _isJumpPressed = false;
        _isJumpPressed = context.action.triggered;
        // Debug.Log("Attack");
    }

    public void DeviceLost(PlayerInput playerInput)
    {
        Debug.Log("Device lost. User: " + playerInput.user);
        gameObject.SetActive(false);
    }

    private void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
        
    }

    void Update()
    {
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        Vector3 move = new Vector3(_axisInput.x, 0, _axisInput.y);
        controller.Move(move * Time.deltaTime * playerSpeed);

        if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;
        }

        // Changes the height position of the player..
        if (_isJumpPressed && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }
}