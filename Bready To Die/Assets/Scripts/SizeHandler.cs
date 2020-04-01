using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SizeHandler : MonoBehaviour
{
    Vector3 startSize;

    float sizeMultiplier;
    float sizeDivider;
    Duck myDuck;
    UIManager UIManagerScript;
    float myWeight;

    float weightLevel; 

    // Start is called before the first frame update
    void Start()
    {
        myDuck = GetComponent<Duck>();
        UIManagerScript = GameObject.Find("GameManager").GetComponent<UIManager>();
    }

    // Update is called once per frame
    void Update()
    {
        SetCorrectWeight();
    }

    void SetCorrectWeight()
    {
        if (myDuck.playerID == 0)
        {
            UIManagerScript.P1Weight = myWeight;
        }

        if (myDuck.playerID == 1)
        {
            UIManagerScript.P2Weight = myWeight;
        }

        if (myDuck.playerID == 2)
        {
            UIManagerScript.P3Weight = myWeight;
        }

        if (myDuck.playerID == 3)
        {
            UIManagerScript.P4Weight = myWeight;
        }
    }

    void IncreaseSize()
    {

    }

    void DecreaseSize()
    {

    }
}
