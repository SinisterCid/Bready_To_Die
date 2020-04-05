using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class DuckHidingDetector : MonoBehaviour
{
    float timeInHiding = 0;

    bool playerHiding = false;

    private void Update()
    {
        if (playerHiding)
        {
            timeInHiding += Time.deltaTime;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerHiding = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerHiding = false;
        }
    }

    private void OnDisable()
    {
        Analytics.CustomEvent("PlayerHiding", new Dictionary<string, object>
        {
            { "timeHiding", timeInHiding },
        });
    }
}
