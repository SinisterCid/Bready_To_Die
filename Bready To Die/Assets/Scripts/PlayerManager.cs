﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    public List<int> IDs;

    public bool P1Exists = false;
    public bool P2Exists = false;
    public bool P3Exists = false;
    public bool P4Exists = false;

    public static PlayerManager playerManager;

    public bool markerOnMouse;

    private void SetInstance()
    {
        if (playerManager == null)
        {
            playerManager = this;
            if (Application.isPlaying)
            {
                DontDestroyOnLoad(gameObject);
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Awake()
    {
        SetInstance();
    }

    public void AddPlayer(int ID)
    {
        if (!IDs.Contains(ID))
        {
            IDs.Add(ID);
            if(ID == 0)
            {
                P1Exists = true;              
            }
            else if(ID == 1)
            {
                P2Exists = true;
            }
            else if (ID == 2)
            {
                P3Exists = true;
            }
            else if (ID == 3)
            {
                P4Exists = true;
            }
        }
    }

    public void RemovePlayer(int ID)
    {
        if (IDs.Contains(ID))
        {
            IDs.RemoveAll(x => x == ID);
            if (ID == 0)
            {
                P1Exists = false;
            }
            else if (ID == 1)
            {
                P2Exists = false;
            }
            else if (ID == 2)
            {
                P3Exists = false;
            }
            else if (ID == 3)
            {
                P4Exists = false;
            }
        }
    }


    public void StartGameplayScene()
    {
        SceneManager.LoadScene("Nolan", LoadSceneMode.Single);
    }


}
