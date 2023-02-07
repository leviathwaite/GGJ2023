using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackController : MonoBehaviour
{
    // TODO change for different weapons and Buffs
    [SerializeField]
    private int _attackStrength = 34;

    [SerializeField]
    private Collider _collider;
    [SerializeField]
    private GameObject _punchEffectPrefab;
    [SerializeField]
    private float _delay = 0.4f;
    [SerializeField]
    private bool _delayTimerActive = false;
    [SerializeField]
    private float _duration = 0.2f;
    [SerializeField]
    private bool _durationTimerActive = false;

    // Serialized for debuging
    [SerializeField]
    private float _durationTimer;
     // Serialized for debuging
    [SerializeField]
    private float _delayTimer;

    private PlayerCharacterController _playerInput;

    // Start is called before the first frame update
    void Start()
    {
        _playerInput = GetComponentInParent<PlayerCharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(_playerInput.IsAttackPressed)
        {
            _delayTimerActive = true;
            _delayTimer = _delay;
        }

        if(_delayTimerActive)
        {
            TickDelayTimer();
        }

        if(_durationTimerActive)
        {
            TickDurationTimer();
        }

    }

    private void TickDelayTimer()
    {
        if(_delayTimer > 0)
        {
            _delayTimer -= Time.deltaTime;
        }
        else
        {
            _delayTimerActive = false;
            _delayTimer = 0;

            _durationTimerActive = true;
            _durationTimer = _duration;
            ToggleOnAttack(true);
        }
    }

    private void TickDurationTimer()
    {
        if(_durationTimer > 0)
        {
            _durationTimer -= Time.deltaTime;
        }
        else
        {
            _durationTimerActive = false;
            _durationTimer = 0;
            ToggleOnAttack(false);
        }
    }

    private void ToggleOnAttack(bool newState)
    {
        if(_collider != null)
            _collider.enabled = newState;

         if(_punchEffectPrefab != null && newState)
            _punchEffectPrefab.SetActive(newState);
    }

    private void OnTriggerEnter(Collider other) 
    {
        IDamageableByPlayer damageAbleByPlayer = other.GetComponent<IDamageableByPlayer>();
        
        if(damageAbleByPlayer != null)
        {
            damageAbleByPlayer.Damage(_attackStrength);
            SpawnHitEffect(other.transform.position);
        }
    }

    // TODO update this with pooling or animation to toggle effect on/off
    private void SpawnHitEffect(Vector3 pos)
    {
        GameObject temp = Instantiate(_punchEffectPrefab, pos, Quaternion.identity);
    }
}
