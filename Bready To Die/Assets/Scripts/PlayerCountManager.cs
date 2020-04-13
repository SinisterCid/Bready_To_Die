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

    public GameObject P1;
    public GameObject P2;
    public GameObject P3;
    public GameObject P4;

    public Transform P1Spawn;
    public Transform P2Spawn;
    public Transform P3Spawn;
    public Transform P4Spawn;

    PlayerManager PMScript;

    private void Awake()
    {
        PMScript = GameObject.Find("PlayerManager").GetComponent<PlayerManager>();
        foreach (GameObject player in GameObject.FindGameObjectsWithTag("Player"))
        {
            players.Add(player);
        }

        foreach (GameObject player in players)
        {
            IDs.Add(player.GetComponent<Duck>().playerID);
        }

        if (/*IDs.Contains(0)*/ PMScript.P1Exists)
        {
            P1Exists = true;
            Instantiate(P1, P1Spawn.transform.position, Quaternion.identity);
        }

        if (/*IDs.Contains(1)*/ PMScript.P2Exists)
        {
            P2Exists = true;
            Instantiate(P2, P2Spawn.transform.position, Quaternion.identity);
        }

        if (/*IDs.Contains(2)*/ PMScript.P3Exists)
        {
            P3Exists = true;
            Instantiate(P3, P3Spawn.transform.position, Quaternion.identity);
        }

        if (/*IDs.Contains(3)*/ PMScript.P4Exists)
        {
            P4Exists = true;
            Instantiate(P4, P4Spawn.transform.position, Quaternion.identity);
        }
    }
}
