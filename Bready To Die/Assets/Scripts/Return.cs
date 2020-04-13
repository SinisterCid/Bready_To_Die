using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Return : MonoBehaviour
{
    PlayerManager PMScript;

    float P1Weight;
    float P2Weight;
    float P3Weight;
    float P4Weight;

    public GameObject P1;
    public GameObject P2;
    public GameObject P3;
    public GameObject P4;

    public Transform firstPlace;
    public Transform secondPlace;
    public Transform thirdPlace;


    public List<float> playerWeights = new List<float>();

    bool doOnce = false;
    // Start is called before the first frame update
    void Start()
    {
        PMScript = GameObject.Find("PlayerManager").GetComponent<PlayerManager>();
        P1Weight = PMScript.P1EndWeight;
        P2Weight = PMScript.P2EndWeight;
        P3Weight = PMScript.P3EndWeight;
        P4Weight = PMScript.P4EndWeight;

        playerWeights.Add(P1Weight);
        playerWeights.Add(P2Weight);
        playerWeights.Add(P3Weight);
        playerWeights.Add(P4Weight);

        playerWeights = playerWeights.OrderByDescending(x => x).ToList();

        /*foreach(var weight in playerWeights)
        {
            Debug.Log(weight);
        }*/

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("0_Cancel"))
        {
            SceneManager.LoadScene(0);
        }

        SetPlayersOnPodium();
    }

    void SetPlayersOnPodium()
    {
        if (!doOnce)
        {
            //place player on first podium
            if (P1Weight == playerWeights[0])
            {
                GameObject winner = Instantiate(P1 as GameObject, firstPlace.position, Quaternion.identity);
                winner.GetComponent<CharacterMovement>().enabled = false;
                winner.GetComponent<SizeHandler>().enabled = false;
                winner.transform.Rotate(new Vector3(0, 180, 0));
              
            }
            else if (P2Weight == playerWeights[0])
            {
                GameObject winner = Instantiate(P2 as GameObject, firstPlace.position, Quaternion.identity);
                winner.GetComponent<CharacterMovement>().enabled = false;
                winner.GetComponent<SizeHandler>().enabled = false;
                winner.transform.Rotate(new Vector3(0, 180, 0));
            }
            else if (P3Weight == playerWeights[0])
            {
                GameObject winner = Instantiate(P3 as GameObject, firstPlace.position, Quaternion.identity);
                winner.GetComponent<CharacterMovement>().enabled = false;
                winner.GetComponent<SizeHandler>().enabled = false;
                winner.transform.Rotate(new Vector3(0, 180, 0));
            }
            else if (P4Weight == playerWeights[0])
            {
                GameObject winner = Instantiate(P4 as GameObject, firstPlace.position, Quaternion.identity);
                winner.GetComponent<CharacterMovement>().enabled = false;
                winner.GetComponent<SizeHandler>().enabled = false;
                winner.transform.Rotate(new Vector3(0, 180, 0));
            }

            //place player on second podium
            if (P1Weight == playerWeights[1])
            {
                GameObject runnerUp = Instantiate(P1 as GameObject, secondPlace.position, Quaternion.identity);
                runnerUp.GetComponent<CharacterMovement>().enabled = false;
                runnerUp.GetComponent<SizeHandler>().enabled = false;
                runnerUp.transform.Rotate(new Vector3(0, 180, 0));
            }
            else if (P2Weight == playerWeights[1])
            {
                GameObject runnerUp = Instantiate(P2 as GameObject, secondPlace.position, Quaternion.identity);
                runnerUp.GetComponent<CharacterMovement>().enabled = false;
                runnerUp.GetComponent<SizeHandler>().enabled = false;
                runnerUp.transform.Rotate(new Vector3(0, 180, 0));
            }
            else if (P3Weight == playerWeights[1])
            {
                GameObject runnerUp = Instantiate(P3 as GameObject, secondPlace.position, Quaternion.identity);
                runnerUp.GetComponent<CharacterMovement>().enabled = false;
                runnerUp.GetComponent<SizeHandler>().enabled = false;
                runnerUp.transform.Rotate(new Vector3(0, 180, 0));
            }
            else if (P4Weight == playerWeights[1])
            {
                GameObject runnerUp = Instantiate(P4 as GameObject, secondPlace.position, Quaternion.identity);
                runnerUp.GetComponent<CharacterMovement>().enabled = false;
                runnerUp.GetComponent<SizeHandler>().enabled = false;
                runnerUp.transform.Rotate(new Vector3(0, 180, 0));
            }

            if (playerWeights[2] > 0)
            {
                //place player on last podium
                if (P1Weight == playerWeights[2])
                {
                    GameObject last = Instantiate(P1 as GameObject, thirdPlace.position, Quaternion.identity);
                    last.GetComponent<CharacterMovement>().enabled = false;
                    last.GetComponent<SizeHandler>().enabled = false;
                    last.transform.Rotate(new Vector3(0, 180, 0));
                }
                else if (P2Weight == playerWeights[2])
                {
                    GameObject last = Instantiate(P2 as GameObject, thirdPlace.position, Quaternion.identity);
                    last.GetComponent<CharacterMovement>().enabled = false;
                    last.GetComponent<SizeHandler>().enabled = false;
                    last.transform.Rotate(new Vector3(0, 180, 0));
                }
                else if (P3Weight == playerWeights[2])
                {
                    GameObject last = Instantiate(P3 as GameObject, thirdPlace.position, Quaternion.identity);
                    last.GetComponent<CharacterMovement>().enabled = false;
                    last.GetComponent<SizeHandler>().enabled = false;
                    last.transform.Rotate(new Vector3(0, 180, 0));
                }
                else if (P4Weight == playerWeights[2])
                {
                    GameObject last = Instantiate(P4 as GameObject, thirdPlace.position, Quaternion.identity);
                    last.GetComponent<CharacterMovement>().enabled = false;
                    last.GetComponent<SizeHandler>().enabled = false;
                    last.transform.Rotate(new Vector3(0, 180, 0));
                }
            }
            doOnce = true;
        }
    }
}
