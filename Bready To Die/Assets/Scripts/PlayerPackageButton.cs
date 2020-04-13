using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerPackageButton : MonoBehaviour
{
    private Button btn;
    public bool addPlayerButton;
    public int myPlayerID;

    private void Awake()
    {
        btn = GetComponent<Button>();

        if (addPlayerButton)
        {
            btn.onClick.AddListener(AddPlayer);
        }
        else
        {
            btn.onClick.AddListener(RemovePlayer);
        }
    }

    void AddPlayer()
    {
        if (btn.enabled && PlayerManager.playerManager)
        {
            PlayerManager.playerManager.AddPlayer(myPlayerID);
        }
    }

    void RemovePlayer()
    {
        if (btn.enabled && PlayerManager.playerManager)
        {
            PlayerManager.playerManager.RemovePlayer(myPlayerID);
        }
    }

}
