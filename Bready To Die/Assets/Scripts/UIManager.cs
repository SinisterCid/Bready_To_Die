using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    PlayerCountManager PCScript;

    public Text P1WeightText;
    public Text P2WeightText;
    public Text P3WeightText;
    public Text P4WeightText;

    Image P1WeightLevel;
    Image P2WeightLevel;
    Image P3WeightLevel;
    Image P4WeightLevel;

    public float P1Weight = 0;
    public float P2Weight = 0;
    public float P3Weight = 0;
    public float P4Weight = 0;

    public int P1WLevel;
    public int P2WLevel;
    public int P3WLevel;
    public int P4WLevel;

    // Start is called before the first frame update
    void Start()
    {
        PCScript = GetComponent<PlayerCountManager>();
        if (PCScript.P1Exists)
        {
            P1WeightText = GameObject.Find("P1UI").GetComponentInChildren<Text>();
        }
        else
        {
            GameObject.Find("P1UI").SetActive(false);
        }
        if (PCScript.P2Exists)
        {
            P2WeightText = GameObject.Find("P2UI").GetComponentInChildren<Text>();
        }
        else
        {
            GameObject.Find("P2UI").SetActive(false);
        }
        if (PCScript.P3Exists)
        { 
            P3WeightText = GameObject.Find("P3UI").GetComponentInChildren<Text>();
        }
        else
        {
            GameObject.Find("P3UI").SetActive(false);
        }
        if (PCScript.P4Exists)
        {
            P4WeightText = GameObject.Find("P4UI").GetComponentInChildren<Text>();
        }
        else
        {
            GameObject.Find("P4UI").SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        HandlePlayer1();
        HandlePlayer2();
        HandlePlayer3();
        HandlePlayer4();
    }

    void HandlePlayer1()
    {
        if (P1WeightText != null && PCScript.P1Exists)
        {
            P1WeightText.text = "Weight (lbs): " + P1Weight;
        }

        if (P1Weight < 0)
        {
            P1Weight = 0;
        }
    }

    void HandlePlayer2()
    {
        if (P2WeightText != null && PCScript.P2Exists)
        {
            P2WeightText.text = "Weight (lbs): " + P2Weight;
        }

        if (P2Weight < 0)
        {
            P2Weight = 0;
        }
    }

    void HandlePlayer3()
    {
        if (P3WeightText != null && PCScript.P3Exists)
        {
            P3WeightText.text = "Weight (lbs): " + P3Weight;
        }

        if (P3Weight < 0)
        {
            P3Weight = 0;
        }
    }

    void HandlePlayer4()
    {
        if (P4WeightText != null && PCScript.P4Exists)
        {
            P4WeightText.text = "Weight (lbs): " + P4Weight;
        }

        if (P4Weight < 0)
        {
            P4Weight = 0;
        }
    }
}
