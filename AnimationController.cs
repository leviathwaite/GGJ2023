using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{

    [SerializeField]
    private Animator _animator;
    private PlayerCharacterController _playerInput;

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponentInChildren<Animator>();
        _playerInput = GetComponent<PlayerCharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateAnimator();
    }

    private void UpdateAnimator()
    {
        if(_animator == null)
        {
            Debug.Log("Animator not found");
            return;
        }

        

        // _animator.SetFloat("MoveX", _playerInput.AxisInput.x);
        // _animator.SetFloat("MoveY", _playerInput.AxisInput.y);


        _animator.SetFloat("Move", _playerInput.AxisInput.magnitude);
        // Debug.Log("Move: " + _playerInput.AxisInput.magnitude);

        _animator.SetBool("Attack", _playerInput.IsAttackPressed);

        if(_playerInput.IsJumpPressed)
        {
            _animator.SetTrigger("Jump");
            // Debug.Log("Jump pressed");
        }
        
    }
}
