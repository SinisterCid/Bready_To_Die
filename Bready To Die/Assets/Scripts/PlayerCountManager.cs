using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCountManager : MonoBehaviour
{
    public List<GameObject> players;
    public List<int> IDs;

    public bool P1Exists = false;
    public bool P2Exists = false;
    public bool P3Exists = false;
    public bool P4Exists = false;

    GameObject P1;
    GameObject P2;
    GameObject P3;
    GameObject P4;

    private void Awake()
    {
        foreach (GameObject player in GameObject.FindGameObjectsWithTag("Player"))
        {
            players.Add(player);
        }

        foreach (GameObject player in players)
        {
            IDs.Add(player.GetComponent<Duck>().playerID);
        }

        if (IDs.Contains(0))
        {
            P1Exists = true;
        }

        if (IDs.Contains(1))
        {
            P2Exists = true;
        }

        if (IDs.Contains(2))
        {
            P3Exists = true;
        }

        if (IDs.Contains(3))
        {
            P4Exists = true;
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
