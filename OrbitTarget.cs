using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ref
// https://gamedev.stackexchange.com/questions/61981/unity3d-orbit-around-orbiting-object-transform-rotatearound
public class OrbitTarget : MonoBehaviour
{
    [SerializeField]
    private float _orbitDegrees = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = 
            RotatePointAroundPivot(transform.position,
            transform.parent.position,
            Quaternion.Euler(0, _orbitDegrees * Time.deltaTime, 0));
    }

    public static Vector3 RotatePointAroundPivot(Vector3 point, Vector3 pivot, Quaternion angle) 
    {
        return angle * ( point - pivot) + pivot;
    }
}
