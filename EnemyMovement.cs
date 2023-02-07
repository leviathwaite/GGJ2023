using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

// ref
// https://docs.unity3d.com/ScriptReference/Physics.OverlapSphere.html
// also has example for splashg damage

// ref
// https://forum.unity.com/threads/solved-test-if-the-navmesh-agent-has-arrived-at-the-targeted-location.327753/#:~:text=To%20check%20if%20the%20agent%20has%20reached%20the,%28agent.position%2C%20target.position%29%20%3C%3D%20nav.stoppingDistance%29%20%7B%20%2F%2F%20Target%20reached
public class EnemyMovement : MonoBehaviour
{
    [SerializeField]
    private float _checkTimer;
    [SerializeField]
    private float _checkTimerDuration = 10;
    [SerializeField]
    private float _overlapSphereRadius = 5;
    [SerializeField]
    private bool _playerInRange = false;
    

    // TODO should I use a collider to confirm reach player range? or squared distance...
    private NavMeshAgent _navMeshAgent;

    // make private
    [SerializeField]
    private GameObject _target;
    private PlayerHealth _playerHealth;
    private EnemyAttack _enemyAttack;

    [SerializeField]
    private Vector3 _velocity;

    public Vector3 Velocity
    {
        get => _velocity;
    }

    // Start is called before the first frame update
    void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _enemyAttack = GetComponent<EnemyAttack>();
    }

    // Update is called once per frame
    void Update()
    {
        if(_target == null)
        {
            _playerHealth = null;

            TickCheckTimer();
        }
        else
        {
            MoveTowards();
        }

        if(_enemyAttack != null && _playerInRange)
            {
                _enemyAttack.Attack();
            }
    }

    private void TickCheckTimer()
    {
        _checkTimer -= Time.deltaTime;
        if(_checkTimer < 0)
        {
            _checkTimer = _checkTimerDuration;
            CheckSurroundings();

        }
    }

    // TODO update so if it doesn't need to move it can continue to attack
    private void CheckSurroundings()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, _overlapSphereRadius);
        foreach (var hitCollider in hitColliders)
        {
            // TODO check if player IsDead == false 

            if(hitCollider.GetComponent<PlayerHealth>() != null)
            {
                _target = hitCollider.gameObject;
                break;
            }
        }
    }

    private void MoveTowards()
    {
        if(_target == null) return;

        bool nullTarget = false;

        // agent.destination = goal.position; 
        _navMeshAgent.destination = _target.transform.position;

        if(_playerHealth != null)
        {
            if(_playerHealth.IsDead)
            {
                nullTarget = true;
            }
        }

        // target unreachable
        // TODO return to home?
        if(_navMeshAgent.hasPath == false)
        {
            nullTarget = true;
        }

        // reached target
        if(Vector3.Distance(_navMeshAgent.nextPosition, _target.transform.position) < _navMeshAgent.stoppingDistance)
        {
            _playerInRange = true;

            // nullTarget = true;
        }

        
        if(nullTarget)
        {
            _target = null;
        }
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(_target == null)
        {
            if(other.CompareTag("Player"))
            {
                _target = other.gameObject;
            }
        }
    }

    private void OnDrawGizmos() 
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, _overlapSphereRadius);
    }
}
