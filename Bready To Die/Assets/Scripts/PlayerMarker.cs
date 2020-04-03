using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlayerMarker : MonoBehaviour
{
    public bool followingMouse;

    private void OnDisable()
    {
        StopMouseFollow();
    }

    public void FollowMouse()
    {
        if (followingMouse != true && PlayerManager.playerManager.markerOnMouse != true)
        {
            followingMouse = true;
            PlayerManager.playerManager.markerOnMouse = true;
            
        }
        else if(followingMouse)
        {
            StopMouseFollow();
        }
    }

    public void StopMouseFollow()
    {
            followingMouse = false;
            PlayerManager.playerManager.markerOnMouse = false;
    }

    private void Update()
    {
        if (followingMouse)
        {
            transform.position = Input.mousePosition;
        }
    }
}
