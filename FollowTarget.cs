using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    [SerializeField]
    private Transform _targetTransform;
    [SerializeField]
    private Vector3 _followOffset;
    // TODO 
    // look at and look at offset

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = _targetTransform.position + _followOffset;
    }
}
