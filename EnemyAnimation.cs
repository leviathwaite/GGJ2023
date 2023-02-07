using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{

    [SerializeField]
    private Animator _animator;
    [SerializeField]
    private EnemyMovement _enemyMovement;

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponentInChildren<Animator>();
        _enemyMovement = GetComponent<EnemyMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateAnimator();
    }

    private void UpdateAnimator()
    {
        if(_animator == null || _enemyMovement == null) return;

        _animator.SetFloat("Move", _enemyMovement.Velocity.magnitude);
    }


}
