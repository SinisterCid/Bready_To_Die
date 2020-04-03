using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartButton : MonoBehaviour
{
    private void Update()
    {
      if (PlayerManager.playerManager.markerOnMouse != true && PlayerManager.playerManager.IDs.Count > 1)
        {
            GetComponent<Button>().interactable = true;
        }
        else
        {
            GetComponent<Button>().interactable = false;
        }
    }
}
