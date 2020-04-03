using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleDamage : MonoBehaviour
{
    public bool isHit = false;
    float hitTime = 2.5f;
    float currentTime;
    Duck myDuck;
    SizeHandler sizeHandlerScript;
    public GameObject breadPrefab;
    public SkinnedMeshRenderer myMesh;

    // Start is called before the first frame update
    void Start()
    {       
        myDuck = GetComponent<Duck>();
        sizeHandlerScript = GetComponent<SizeHandler>();
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
            if (sizeHandlerScript.myWeight > 0.5f)
            {
                UpdateWeightUI();
                //myDuck.breadCount -= 1;
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

            yield return new WaitForSeconds(0.2f);
        }

        
    }

    void UpdateWeightUI()
    {
        if (myDuck.playerID == 0)
        {
            GameObject.Find("GameManager").GetComponent<UIManager>().P1Weight -= 0.5f;
        }
        else if (myDuck.playerID == 1)
        {
            GameObject.Find("GameManager").GetComponent<UIManager>().P2Weight -= 0.5f;
        }
        else if (myDuck.playerID == 2)
        {
            GameObject.Find("GameManager").GetComponent<UIManager>().P3Weight -= 0.5f;
        }
        else if (myDuck.playerID == 3)
        {
            GameObject.Find("GameManager").GetComponent<UIManager>().P4Weight -= 0.5f;
        }
    }
}
