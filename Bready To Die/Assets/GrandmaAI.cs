using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrandmaAI : MonoBehaviour
{
    public Animator grandmaAnimator;
    public float rotationRate = 50;
    public float breadThrowRate = 2;

    public GameObject breadSpawnPoint;

    public GameObject breadPrefab;
    public float breadThrowForce = 5f;

    float timeSinceLastThrow;




    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!grandmaAnimator.GetCurrentAnimatorStateInfo(0).IsName("toss"))
        {
            timeSinceLastThrow += Time.deltaTime;
            if (timeSinceLastThrow >= breadThrowRate)
            {
                timeSinceLastThrow = 0;
                ThrowBreadAnim();
            }
        }

        
    }

    private void ThrowBreadAnim()
    {
        print("throw");
        grandmaAnimator.SetTrigger("doThrow");

    }

    public void SpawnBread()
    {
        GameObject newBread = Instantiate(breadPrefab, breadSpawnPoint.transform.position, Quaternion.identity);
        newBread.GetComponent<Rigidbody>().AddForce((transform.forward + transform.up).normalized * breadThrowForce, ForceMode.Impulse);
    }

}
