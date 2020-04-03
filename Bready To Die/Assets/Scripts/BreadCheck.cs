using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreadCheck : MonoBehaviour
{
    public Duck myDuck;
    public HandleDamage damageScript;
    public GameObject mouth;
    public bool isEating = false;
    bool canEat = true;
    public float eatingDuration = 0.5f;
    float addedWeight;

    /*private void OnTriggerEnter(Collider other)
    {
        if (!damageScript.isHit && canEat)
        {
            canEat = false;
            isEating = true;
            StartCoroutine(EatBread(other.gameObject));
            Destroy(other.gameObject.GetComponent<Rigidbody>());
            Destroy(other.gameObject.GetComponent<Collider>());
        }
    }*/

    private void OnTriggerStay(Collider other)
    {
        if (!damageScript.isHit && canEat)
        {
            canEat = false;
            isEating = true;
            StartCoroutine(EatBread(other.gameObject));
            Destroy(other.gameObject.GetComponent<Rigidbody>());
            Destroy(other.gameObject.GetComponent<Collider>());
        }
    }

    IEnumerator EatBread(GameObject targetbread)
    {
        float t = targetbread.GetComponent<BreadWeightTracker>().timeToConsume;
        float timeToConsume = targetbread.GetComponent<BreadWeightTracker>().timeToConsume;
        Vector3 startPosition = targetbread.transform.position;
        Vector3 initialScale = targetbread.transform.localScale;
        while (t > 0)
        {
            t -= Time.deltaTime;
            targetbread.transform.position = Vector3.Lerp(mouth.transform.position, startPosition, t / timeToConsume);
            targetbread.transform.localScale = Vector3.Lerp(Vector3.zero, initialScale, t / timeToConsume);
            yield return null;
        }
        //Vector3 distanceToMouth = targetbread.transform.position - mouth.transform.position;
        ////only add bread to the duck who eats
        //if (distanceToMouth.magnitude < 0.5f)
        //{
        addedWeight = targetbread.GetComponent<BreadWeightTracker>().weightValue;
        UpdateWeightUI();
        myDuck.breadCount += 1;
        //}
        canEat = true;
        isEating = false;
        Destroy(targetbread);
        yield break;
    }

    void UpdateWeightUI()
    {
        if (myDuck.playerID == 0)
        {
            GameObject.Find("GameManager").GetComponent<UIManager>().P1Weight += addedWeight;
        }
        else if (myDuck.playerID == 1)
        {
            GameObject.Find("GameManager").GetComponent<UIManager>().P2Weight += addedWeight;
        }
        else if (myDuck.playerID == 2)
        {
            GameObject.Find("GameManager").GetComponent<UIManager>().P3Weight += addedWeight;
        }
        else if (myDuck.playerID == 3)
        {
            GameObject.Find("GameManager").GetComponent<UIManager>().P4Weight += addedWeight;
        }
    }
}
