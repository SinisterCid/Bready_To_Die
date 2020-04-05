using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//modified from source: https://answers.unity.com/questions/851388/how-do-i-add-multiple-points-using-lerp.html
public class WayPointLerp : MonoBehaviour
{
    private Transform startMarker, endMarker;
    public Transform[] waypoints;
    float startTime;
    public float speed;
    int currentStartPoint;
    float journeyLength;

    void Start()
    {
        currentStartPoint = 0;
        SetPoints();
    }
    void SetPoints()
    {
        startMarker = waypoints[currentStartPoint % waypoints.Length];
        endMarker = waypoints[(currentStartPoint + 1) % waypoints.Length];
        startTime = Time.time;
        journeyLength = Vector3.Distance(startMarker.position, endMarker.position);
    }

    void Update()
    {
        float distCovered = (Time.time - startTime) * speed;
        float fracJourney = distCovered / journeyLength;
        transform.position = Vector3.Lerp(startMarker.position, endMarker.position, fracJourney);
        if (fracJourney >= 1f)
        {
            currentStartPoint++;
            SetPoints();
        }
    }

}
