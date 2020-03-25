using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreadCheck : MonoBehaviour
{
    public Duck myDuck;
    public HandleDamage damageScript;
    public GameObject mouth;
    public float eatingDuration = 0.5f;

    private void OnTriggerEnter(Collider other)
    {
        if (!damageScript.isHit)
        {
            StartCoroutine(EatBread(other.gameObject));
            Destroy(other.gameObject.GetComponent<Rigidbody>());
        }
    }

    IEnumerator EatBread(GameObject targetbread)
    {
        float t = eatingDuration;
        Vector3 startPosition = targetbread.transform.position;
        while (t > 0)
        {
            targetbread.transform.position = Vector3.Lerp(mouth.transform.position, startPosition, t / eatingDuration);
            targetbread.transform.localScale = Vector3.one * Mathf.Lerp(0, 1, t / eatingDuration);
            t -= Time.deltaTime;
            yield return null;
        }
        myDuck.breadCount += 1;
        Destroy(targetbread);
        yield break;
    }
}
