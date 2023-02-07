using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateTrap : MonoBehaviour
{
    [SerializeField]
    private GameObject _effectPrefab;
    [SerializeField]
    private AudioClip _gateAudioClip;

    [SerializeField]
    private Vector3 _startingPosition;
    [SerializeField]
    private float _closedHeightY = -1;
    [SerializeField]
    private float _closedScaleY = 1.5f;
    [SerializeField]
    private bool _trapTriggered = false;

    private AudioSource _audioSource;

    // Start is called before the first frame update
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other) 
    {
         if(_trapTriggered == false)
        {
            if(other.collider.CompareTag("Player"))
            {
                _trapTriggered = true;
                SpringTrap();
            }
        }
    }
    private void OnTriggerEnter(Collider other) 
    {
        if(_trapTriggered == false)
        {
            if(other.CompareTag("Player"))
            {
                _trapTriggered = true;
                SpringTrap();
            }
        }
    }

    private void SpringTrap()
    {
        if(_gateAudioClip != null)
        {
            if(_audioSource != null)
            {
                _audioSource.clip = _gateAudioClip;
                _audioSource.loop = false;
                _audioSource.Play();
            }
        }

        Vector3 pos = transform.position;
        pos.y = _closedHeightY;
        transform.position = pos;

        Vector3 scale = transform.localScale;
        scale.y = _closedScaleY;
        transform.localScale = scale;

        // effect
        GameObject temp = Instantiate(_effectPrefab, transform.position, transform.rotation);
        Destroy(temp, 5.0f);
    }
}
