using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    
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
        P1WeightText = GameObject.Find("P1UI").GetComponentInChildren<Text>();
        P2WeightText = GameObject.Find("P2UI").GetComponentInChildren<Text>();
        P3WeightText = GameObject.Find("P3UI").GetComponentInChildren<Text>();
        P4WeightText = GameObject.Find("P4UI").GetComponentInChildren<Text>();
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
        if (P1WeightText != null)
        {
            P1WeightText.text = "Weight (lbs): " + P1Weight;
        }
    }

    void HandlePlayer2()
    {
        if (P2WeightText != null)
        {
            P2WeightText.text = "Weight (lbs): " + P2Weight;
        }
    }

    void HandlePlayer3()
    {
        if (P3WeightText != null)
        {
            P3WeightText.text = "Weight (lbs): " + P3Weight;
        }
    }

    void HandlePlayer4()
    {
        if (P4WeightText != null)
        {
            P4WeightText.text = "Weight (lbs): " + P4Weight;
        }
    }
}
