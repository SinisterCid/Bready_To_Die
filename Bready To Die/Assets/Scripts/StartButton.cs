using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartButton : MonoBehaviour
{
    private Button btn;
    private void Awake()
    {
        btn = GetComponent<Button>();
        btn.onClick.AddListener(StartGame);
    }

    private void Update()
    {
      if (PlayerManager.playerManager.markerOnMouse != true && PlayerManager.playerManager.IDs.Count > 1)
        {
            btn.interactable = true;
        }   
        else
        {
            btn.interactable = false;
        }
    }

    void StartGame()
    {
        if(btn.interactable && PlayerManager.playerManager)
        {
            PlayerManager.playerManager.StartGameplayScene();
        }
    }

}
