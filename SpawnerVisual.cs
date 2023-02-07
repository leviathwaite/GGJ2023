using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerVisual : MonoBehaviour
{
    [SerializeField]
    private GameObject _treeToHide;
    [SerializeField]
    private GameObject _halfHealthEffectPrefab;
     [SerializeField]
    private GameObject _dieEffectPrefab;

    private EnemyHealth _enemyHealth;
    private bool _halfHealth = false;
    private bool _died = false;
    private Rigidbody _rigidbody;


    // Start is called before the first frame update
    void Start()
    {
        _enemyHealth = GetComponent<EnemyHealth>();
        _rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        if(_enemyHealth.CurrentHealth < (_enemyHealth.StartingHealth / 2) && _halfHealth == false)
        {
            _halfHealth = true;
            // hide a tree
            _treeToHide.SetActive(false);
            GameObject temp = Instantiate(_halfHealthEffectPrefab, transform.position, transform.rotation);
            Destroy(temp, 20);
        }

        if(_enemyHealth.CurrentHealth < 1 &&_died == false)
        {
            _died = true;
            GameObject temp = Instantiate(_dieEffectPrefab, transform.position, transform.rotation);
            Destroy(temp, 5);
            Destroy(gameObject, 6);
            // TODO lower into ground or scale down or both?
            if(_rigidbody != null)
            {
                _rigidbody.useGravity = true;
            }
        }
    }
}
