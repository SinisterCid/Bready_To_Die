﻿using UnityEngine;

public class Jab : MonoBehaviour
{
    CapsuleCollider jabCollider;
    Duck myDuck;
    CharacterMovement movementScript;

    float jabTime = 0.6f;
    float jabDetectTime = 0.3f;
    float currentTime;
    bool canJab = true;
    public bool isJabbing = false;

    // Start is called before the first frame update
    void Start()
    {
        movementScript = GetComponentInParent<CharacterMovement>();
        myDuck = GetComponentInParent<Duck>();
        jabCollider = GetComponent<CapsuleCollider>();
        jabCollider.enabled = false;    
    }

    // Update is called once per frame
    void Update()
    {
        JabTimer();
    }

    public void DoJab()
    {
        if (canJab && movementScript.isGrounded)
        {
            currentTime = Time.time;
            jabCollider.enabled = true;
            isJabbing = true;
            canJab = false;
        }
    }

    void JabTimer()
    {
        if (Time.time > currentTime + jabDetectTime)
        {
            isJabbing = false;
            jabCollider.enabled = false;
        }

        if (Time.time > currentTime + jabTime)
        {
            canJab = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Duck>().playerID != myDuck.playerID && !other.gameObject.GetComponent<HandleDamage>().isHit && isJabbing)
        {
            other.gameObject.GetComponent<HandleDamage>().LoseBread();
        }
    }
}
