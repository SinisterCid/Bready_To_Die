using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Camera))]
public class CameraFollow : MonoBehaviour
{

    private Camera mainCam;
    public List<Transform> targets;
    public float smoothTime = 0.5f;
    public Vector3 offset;

    private Vector3 velocity;
    public float minZoom;
    public float maxZoom;
    public float zoomLimiter = 50;

    Vector3 magnitude = new Vector3(1,1,0);

    // Start is called before the first frame update
    void Start()
    {
        mainCam = GetComponent<Camera>();
        foreach (GameObject player in GameObject.FindGameObjectsWithTag("Player"))
        {
            targets.Add(player.GetComponent<Transform>());
        }
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (targets.Count == 0)
        {
            return;
        }

        Move();
        Zoom();
    }

    private void Move()
    {
        Vector3 centerPoint = GetCenterPoint();
        //Vector3 newPosition = centerPoint + offset;
        transform.LookAt(centerPoint);
        //transform.position = Vector3.SmoothDamp(transform.position, newPosition, ref velocity, smoothTime);
    }

    private void Zoom()
    {
        float newZoom = Mathf.Lerp(maxZoom, minZoom, GetGreatestDistance()/ zoomLimiter);
        mainCam.orthographicSize = Mathf.Lerp(mainCam.orthographicSize, newZoom, Time.deltaTime);
    }

    float GetGreatestDistance()
    {
        var bounds = new Bounds(targets[0].position, Vector3.zero);
        for (int i = 0; i < targets.Count; i++)
        {
            bounds.Encapsulate(targets[i].position);
        }

        return bounds.size.x;
    }

    Vector3 GetCenterPoint()
    {
        if (targets.Count == 1)
        {
            return targets[0].position;
        }

        var bounds = new Bounds(targets[0].position, Vector3.zero);
        for (int i = 0; i < targets.Count; i++)
        {
            bounds.Encapsulate(targets[i].position);
        }

        return bounds.center;
    }

    /*public void ShakeCamera()
    {
        iTween.ShakePosition(this.gameObject, magnitude, 0.5f);
    }*/
}
