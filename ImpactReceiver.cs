using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ref
// https://answers.unity.com/questions/242648/force-on-character-controller-knockback.html#:~:text=Force%20on%20Character%20Controller%20%28Knockback%29%20-%20Unity%20Answers,call%20t%24%24anonymous%24%24s%20function%20to%20add%20an%20impact%20force%3A


public class ImpactReceiver : MonoBehaviour 
{
    float mass = 3.0F; // defines the character mass
    Vector3 impact = Vector3.zero;
    private CharacterController character;
    // Use t$$anonymous$$s for initialization
    void Start () 
    {
        character = GetComponent<CharacterController>();
    }
    
    // Update is called once per frame
    void Update () 
    {
        // apply the impact force:
        if (impact.magnitude > 0.2F) character.Move(impact * Time.deltaTime);
            // consumes the impact energy each cycle:
            impact = Vector3.Lerp(impact, Vector3.zero, 5*Time.deltaTime);
    }

    // call t$$anonymous$$s function to add an impact force:
    public void AddImpact(Vector3 dir, float force)
    {
        dir.Normalize();
        if (dir.y < 0) dir.y = -dir.y; // reflect down force on the ground
        impact += dir.normalized * force / mass;
    }
}