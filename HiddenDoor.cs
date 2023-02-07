using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiddenDoor : MonoBehaviour
{
    [SerializeField]
    private GameObject _brokenWall;
    [SerializeField]
    private GameObject _weakWall;
    [SerializeField]
    private bool _isBroken = false;

    // Start is called before the first frame update
    void Start()
    {
        _weakWall.SetActive(true);
        _brokenWall.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(_isBroken == false){
            // TODO may need updates
            if(other.CompareTag("PlayerAttack"))
            {
                _weakWall.SetActive(false);
                _brokenWall.SetActive(true);
            }
        }
    }
}
