using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateGameObject : MonoBehaviour
{
    [SerializeField]
    private Vector3 _axisRotation = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(_axisRotation * Time.deltaTime);
    }
}
