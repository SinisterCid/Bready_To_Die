using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleDamage : MonoBehaviour
{
    public bool isHit = false;
    float hitTime = 2.5f;
    float currentTime;
    Duck myDuck;
    public GameObject breadPrefab;
    public MeshRenderer myMesh;

    // Start is called before the first frame update
    void Start()
    {       
        myDuck = GetComponent<Duck>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > currentTime + hitTime && isHit)
        {
            myMesh.enabled = true;
            isHit = false;
        }
    }

    public void LoseBread()
    {
        if (!isHit)
        {
            currentTime = Time.time;
            isHit = true;
            if (myDuck.breadCount > 0)
            {
                myDuck.breadCount -= 1;
                Instantiate(breadPrefab, transform.position + transform.forward, Quaternion.identity);
            }

            StartCoroutine(HitState());
        }
    }

    IEnumerator HitState()
    {
        while (Time.time < currentTime + hitTime)
        {
            if (myMesh.enabled == true)
            {
                myMesh.enabled = false;
            }
            else
            {
                myMesh.enabled = true;
            }

            yield return new WaitForSeconds(0.3f);
        }

        
    }
}
