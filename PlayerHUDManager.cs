using UnityEngine;
using System;
using UnityEngine.InputSystem;

// ref for using new Input system with UI
// https://youtu.be/TBcfhJoCVQo
public class PlayerHUDManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _joinUIPrefab;
    [SerializeField]
    private GameObject[] _joinUIs;


    [SerializeField]
    private int _currentPlayerCount;


    private PlayerInputManager _playerInputManager;

    
    // Start is called before the first frame update
    void Start()
    {
        _playerInputManager = PlayerInputManager.instance;

        if(_playerInputManager != null)
        {
            int maxPlayerCount = _playerInputManager.maxPlayerCount;
            _joinUIs = new GameObject[maxPlayerCount];
            for(int i = 0; i < maxPlayerCount; i++)
            {
                GameObject temp = Instantiate(_joinUIPrefab, transform.position, transform.rotation); 
                temp.transform.SetParent(transform);
                temp.SetActive(false);
                _joinUIs[i] = temp;

                // start with one
                if(i == 0)
                {
                    temp.SetActive(true);
                }
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayerJoined(PlayerInput player)
    {
        Debug.Log("Player Joined");

        // int index = FindNextEmptySlot();
        int index = IndexOfInactiveGameObjects(_joinUIs);
        Debug.Log("Index :" + index + ", is inactive");

        if(index < 0)
        {
            Debug.Log("no emopty slots");
        }
        else
        {
            _joinUIs[index].SetActive(true);
            _joinUIs[index].GetComponent<PlayerInfo>().PlayerInputRef = player;


            
        }

        UpdateUserCount();
    }

    private int IndexOfInactiveGameObjects(GameObject[] _gameObjects)
{
    return Array.FindIndex(_gameObjects, gameObject => !gameObject.activeInHierarchy);
}

// False "Full" detections
    private int FindNextEmptySlot()
    {
        for(int i = 0; i < _currentPlayerCount + 1; i++)
        {
            if(_joinUIs[i].activeInHierarchy == false)
            {
                return i;
            }
        }

        return -1;
    }

    // TODO need to handle this when player leaves
    public void PlayerLeft(PlayerInput player)
    {
        Debug.Log("Player Left");

        

        for(int i = 0; i < _currentPlayerCount + 1; i++)
        {
            if(_joinUIs == null) return;

            // only check active ones
            if(_joinUIs[i].activeInHierarchy == true)
            {
                if(_joinUIs == null) return;
                 
                if(_joinUIs[i].GetComponent<PlayerInfo>().PlayerInputRef.playerIndex == player.playerIndex)
                {
                    _joinUIs[i].SetActive(false);
                }
            }
        
        }

        UpdateUserCount();
    }


    private void UpdateUserCount()
    {
        
        // Debug.Log("Update called");

        if(_playerInputManager == null) 
        {
            Debug.Log("Player Input Manager is null");
            return;

        }
        

        _currentPlayerCount = _playerInputManager.playerCount;


    }
}
