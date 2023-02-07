using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// TODO interface naming is confusing

public class PlayerHealth : MonoBehaviour, IDamagePlayer
{
    [SerializeField]
    private RadialHealthBar _radialHealthBar;

    [SerializeField]
    private int _currentHealth;

    public int CurrentHealth
    {
        get => _currentHealth;
    }

    [SerializeField]
    private int _maxHealth = 100;
    public int MaxHealth
    {
        set => _maxHealth = value;
    }

    [SerializeField]
    private int _startingHealth = 100;
    [SerializeField]
    private bool _isDead = false;

    public bool IsDead
    {
        get => _isDead;
    }

    [SerializeField]
    private bool _recentlyHit = false;

    public bool RecentlyHit
    {
        get => _recentlyHit;
    }

    [SerializeField]
    private float _recentlyHitTimer;
    [SerializeField]
    private float _recentlyHitDuration = 1.0f;

    [SerializeField]
    private Color _recentlyHitColor = Color.red;

    [SerializeField]
    private float _yHeightLimit = -4;

    private Renderer[] _renderers;


    public void Damage(int amount)
    {
        if(_recentlyHit) return;
        
        _currentHealth -= amount;
        Debug.Log("Amount: " + amount);
        _recentlyHit = true;
        _recentlyHitTimer = _recentlyHitDuration;
        RecentlyHitRenderToggle();
        // TODO trigger critical hit effect

        UpdateHealth();
    }

    private void Heal(int amount)
    {
        _currentHealth += amount;
        UpdateHealth();
    }

    // Start is called before the first frame update
    void Start()
    {
        _currentHealth = _startingHealth;
        

        _renderers = GetComponentsInChildren<Renderer>();
        _radialHealthBar = GetComponentInChildren<RadialHealthBar>();

        UpdateHealth();
    }

    // Update is called once per frame
    void Update()
    {
        if(_recentlyHit)
        {
            TickRecentlyHitTimer();
        }

        if(_isDead)
        {
            Die();
        }

        if(transform.position.y < _yHeightLimit)
        {
            _isDead = true;
        }
    }

    private void TickRecentlyHitTimer()
    {
        if(_recentlyHitTimer > 0)
        {
            _recentlyHitTimer -= Time.deltaTime;
        }
        else{
            _recentlyHitTimer = 0;
            _recentlyHit = false;
            RecentlyHitRenderToggle();
        }
    }

    private void RecentlyHitRenderToggle()
    {
        if(_renderers.Length < 1) return;

        foreach (Renderer renderer in _renderers)
        {
            if(_recentlyHit)
            {
                renderer.material.color = _recentlyHitColor;
            }
            else
            {
                 renderer.material.color = Color.white;
            }
        }
    }

    private void UpdateHealth()
    {
        _currentHealth = Mathf.Clamp(_currentHealth, 0, _maxHealth);

        if(_currentHealth <= 0)
        {
            _isDead = true;
        }

        if(_radialHealthBar != null)
        {
            _radialHealthBar.UpdateUI( _currentHealth, _maxHealth);
        }
    }

    // TODO add way to increase/decrese max Health

    private void Die() 
    {
        Destroy(gameObject, 0.2f);
        // TODO start effects
    }

}


