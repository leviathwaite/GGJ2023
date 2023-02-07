using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bobbing : MonoBehaviour
{
    [SerializeField]
    private Vector3 _bobDirection = new Vector3(0, 1, 0);
    [SerializeField]
    private bool _isBobbing = false;
    public bool IsBobbing
    {
        get => _isBobbing;
        set => _isBobbing = value;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(_isBobbing)
        {
            Bob();
        }
    }

    private void Bob()
    {
        // Vector3 pos = transform.position;
        transform.Translate(_bobDirection * Time.deltaTime);
    }
}
