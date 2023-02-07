using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

// New Input Ref
// https://towardsdev.com/using-2d-vector-composite-for-movement-in-the-new-input-system-with-unity-2021-7c2f0976be98

// Local multiplayer ref
// https://youtu.be/g_s0y5yFxYg

public class PlayerMovement : MonoBehaviour
{

    [SerializeField]
    private float _moveSpeed = 1;


    [SerializeField]
    private Vector2 _inputAxis;
    private PlayerControls _playerControls;

    private void Awake() 
    {
        _playerControls = new PlayerControls();
    }

    private void OnEnable() 
    {
        _playerControls.Enable();
    }

    private void OnDisable() 
    {
        _playerControls.Disable();
    }

    private void MovementOnPreformed(InputAction.CallbackContext context)
    {
        _inputAxis = context.ReadValue<Vector2>();
        MovePlayer();
        Debug.Log("Moving");
    }
   
    void Start()
    {
        
    }

    void Update()
    {
         _inputAxis = _playerControls.Player.Movement.ReadValue<Vector2>();
        MovePlayer();
        Debug.Log("Moving");
    }

    private void MovePlayer()
    {
        transform.Translate(_inputAxis.x * _moveSpeed * Time.deltaTime, 0, _inputAxis.y * _moveSpeed * Time.deltaTime);
    }
}
