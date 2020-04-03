using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//source: https://answers.unity.com/questions/851388/how-do-i-add-multiple-points-using-lerp.html
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
        startMarker = waypoints[currentStartPoint];
        endMarker = waypoints[currentStartPoint + 1];
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
            if(currentStartPoint + 1 < waypoints.Length)
            {
                currentStartPoint++;
                SetPoints();
            }
            if (currentStartPoint + 1 == waypoints.Length)
            {
                currentStartPoint = waypoints.Length;
                startMarker = waypoints[currentStartPoint - 1];
                endMarker = waypoints[0];
                startTime = Time.time;
                journeyLength = Vector3.Distance(startMarker.position, endMarker.position);
            }
            else
            {
                currentStartPoint = 0;
                SetPoints();
            }
        }
    }

}
