﻿using UnityEngine;

public class DuckAnimationHandler : MonoBehaviour
{
    SizeHandler shScript;
    Jab jabScript;
    HandleDamage damageScript;
    BreadCheck bcScript;
    CharacterMovement movementScript;

    public Animator animController;

    // Start is called before the first frame update
    void Start()
    {
        shScript = GetComponent<SizeHandler>();
        jabScript = GetComponentInChildren<Jab>();
        damageScript = GetComponent<HandleDamage>();
        bcScript = GetComponentInChildren<BreadCheck>();
        movementScript = GetComponent<CharacterMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        SetAnimationParameters();
    }

    void SetAnimationParameters()
    {
        animController.SetFloat("Speed", movementScript.walkSpeed);
        animController.SetFloat("Vertical", movementScript.velocity.y);
        animController.SetBool("Grounded", movementScript.isGrounded);
        animController.SetBool("IsJabbing", jabScript.isJabbing);
        animController.SetBool("IsEating", bcScript.isEating);
        animController.SetBool("IsHit", damageScript.isHit);
        //animController.SetBool("IsQuacking", );
        //animController.SetBool("InWater", );
        //animController.SetBool("IsTaunting", );
    }
}
