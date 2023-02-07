using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PlayerCameraController : MonoBehaviour
{
    [SerializeField]
    private float _weight = 1;
    [SerializeField]
    private float _radius = 2;
    private CinemachineTargetGroup _targetGroup;

    // Start is called before the first frame update
    void Start()
    {
        _targetGroup = GameObject.FindGameObjectWithTag("TargetCamera").GetComponent<CinemachineTargetGroup>();
        _targetGroup.AddMember(transform, _weight, _radius);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
