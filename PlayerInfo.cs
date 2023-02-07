using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;



// This also acts as Player's HUD controller, player select, etc
public class PlayerInfo : MonoBehaviour
{
    [SerializeField]
    private GameObject _joinText;
    [SerializeField]
    private GameObject _playerUI;
    [SerializeField]
    private bool _playerAssigned = false;
    private PlayerInput _playerInput;
    public PlayerInput PlayerInputRef
    {
        get => _playerInput;
        set
        {
             _playerInput = value;
             _playerAssigned = true;
             UpdateUI();
        }
    }

    private void OnEnable() 
    {
        // TODO is there a better way to reset after player leaves? Call from HUDManager???
        _playerAssigned = false;
        _joinText.SetActive(true);
        _playerUI.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void UpdateUI()
    {
        if(_playerAssigned)
        {
            _joinText.SetActive(false);
            _playerUI.SetActive(true);
        }

    }
}
