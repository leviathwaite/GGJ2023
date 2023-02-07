using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWithSin : MonoBehaviour
{
    [SerializeField] private float speed = 1.0f;
    [SerializeField] private float amplitude = 1.0f;

    private float currentTime = 0.0f;

    private void Update()
    {
        currentTime += Time.deltaTime * speed;
        float y = amplitude * Mathf.Sin(currentTime);
        transform.position = new Vector3(transform.position.x, y, transform.position.z);
    }

}
