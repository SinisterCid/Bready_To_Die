using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jab : MonoBehaviour
{
    CapsuleCollider jabCollider;
    Duck myDuck;

    float jabTime = 0.6f;
    float jabDetectTime = 0.3f;
    float currentTime;
    bool canJab = true;
    bool isJabbing = false;

    string jabButtonName;

    // Start is called before the first frame update
    void Start()
    {
        myDuck = GetComponentInParent<Duck>();
        jabCollider = GetComponent<CapsuleCollider>();
        jabCollider.enabled = false;
        jabButtonName = myDuck.playerID + "_Jab";
    }

    // Update is called once per frame
    void Update()
    {
        JabTimer();
        DoJab();
    }

    public void DoJab()
    {
        if (Input.GetButtonDown(jabButtonName) && canJab)
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
