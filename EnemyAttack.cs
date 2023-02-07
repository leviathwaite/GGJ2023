using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField]
    private int _damage = 10;

    [SerializeField]
    private float _attackCoolDownTimer;
    [SerializeField]
    private float _attackCoolDownDuration = 1.0f;
    [SerializeField]
    private bool _recentlyAttacked = false;

    [SerializeField]
    private float _kickBackForce = 10;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(_recentlyAttacked)
        {
            TickAttackCoolDownTimer();
        }
    }

    private void TickAttackCoolDownTimer()
    {
        _attackCoolDownTimer -= Time.deltaTime;

        if(_attackCoolDownTimer < 0)
        {
            _recentlyAttacked = false;
        }
    }

    // TODO how to link this with animation?
    public void Attack()
    {
        Debug.Log("Attacking");
        _recentlyAttacked = true;
        _attackCoolDownTimer = _attackCoolDownDuration;
    }

    private void OnTriggerEnter(Collider other) 
    {   
        if(_recentlyAttacked == false)
        {
            IDamagePlayer _player = other.GetComponent<IDamagePlayer>();
            if(_player != null)
            {
                _player.Damage(_damage);
                Debug.Log("Hit player");

                // kick back
                ImpactReceiver playerImpact = other.GetComponent<ImpactReceiver>();
                if(playerImpact != null)
                {
                    Vector3 direction = (transform.position - other.transform.position).normalized;
                    playerImpact.AddImpact(transform.forward, _kickBackForce);
                }
                else
                {
                    Debug.Log("player impactReceiver is null");
                }
                
            }
        }
    }

}
