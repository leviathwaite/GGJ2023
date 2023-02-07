using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimitedLifetimeEffect : MonoBehaviour
{
    [SerializeField]
    private float _lifeDuration = 2;
    [SerializeField]
    private float _lifeTimer;


    private void OnEnable() 
    {
        _lifeTimer = _lifeDuration;
    }

    void Update()
    {
        TickTimer();
    }

    private void TickTimer()
    {
        _lifeTimer -= Time.deltaTime;
        if(_lifeTimer < 0)
        {
            _lifeTimer = 0;
            gameObject.SetActive(false);
        }
    }
}
