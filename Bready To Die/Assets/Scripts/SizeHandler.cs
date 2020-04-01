using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SizeHandler : MonoBehaviour
{
    Vector3 startSize;

    float sizeMultiplier;
    float sizeDivider;
    Duck myDuck;
    UIManager UIManagerScript;
    public float myWeight;
    float myTempWeight;

    float myWeightLevel;

    public Sprite[] sizeLevelNumber;

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
        //if player 1
        if (myDuck.playerID == 0)
        {
            myWeight = UIManagerScript.P1Weight;
            myWeightLevel = UIManagerScript.P1WLevel;
            myTempWeight = (myWeight - (UIManagerScript.P1WLevel * UIManagerScript.levelIncreaseAmount - UIManagerScript.levelIncreaseAmount));
            if (myWeight > UIManagerScript.levelIncreaseAmount * UIManagerScript.P1WLevel)
            {
                UIManagerScript.P1WLevel += 1;
            }
            else if (myWeight < (UIManagerScript.P1WLevel * UIManagerScript.levelIncreaseAmount - UIManagerScript.levelIncreaseAmount) && UIManagerScript.P1WLevel != 1)
            {
                UIManagerScript.P1WLevel -= 1;
            }
            
            UIManagerScript.P1LevelNumber.sprite = sizeLevelNumber[UIManagerScript.P1WLevel - 1];
        }
        //if player 2
        if (myDuck.playerID == 1)
        {
            myWeight = UIManagerScript.P2Weight;
            myWeightLevel = UIManagerScript.P2WLevel;
            myTempWeight = (myWeight - (UIManagerScript.P2WLevel * UIManagerScript.levelIncreaseAmount - UIManagerScript.levelIncreaseAmount));
            if (myWeight > UIManagerScript.levelIncreaseAmount * UIManagerScript.P2WLevel)
            {
                UIManagerScript.P2WLevel += 1;
            }
            else if (myWeight < (UIManagerScript.P2WLevel * UIManagerScript.levelIncreaseAmount - UIManagerScript.levelIncreaseAmount) && UIManagerScript.P2WLevel != 1)
            {
                UIManagerScript.P2WLevel -= 1;
            }

            UIManagerScript.P2LevelNumber.sprite = sizeLevelNumber[UIManagerScript.P2WLevel - 1];
        }
        //if player 3
        if (myDuck.playerID == 2)
        {
            myWeight = UIManagerScript.P3Weight;
            myWeightLevel = UIManagerScript.P3WLevel;
            myTempWeight = (myWeight - (UIManagerScript.P3WLevel * UIManagerScript.levelIncreaseAmount - UIManagerScript.levelIncreaseAmount));
            if (myWeight > UIManagerScript.levelIncreaseAmount * UIManagerScript.P3WLevel)
            {
                UIManagerScript.P3WLevel += 1;
            }
            else if (myWeight < (UIManagerScript.P3WLevel * UIManagerScript.levelIncreaseAmount - UIManagerScript.levelIncreaseAmount) && UIManagerScript.P3WLevel != 1)
            {
                UIManagerScript.P3WLevel -= 1;
            }

            UIManagerScript.P3LevelNumber.sprite = sizeLevelNumber[UIManagerScript.P3WLevel - 1];
        }
        //if player 4
        if (myDuck.playerID == 3)
        {
            myWeight = UIManagerScript.P4Weight;
            myWeightLevel = UIManagerScript.P4WLevel;
            myTempWeight = (myWeight - (UIManagerScript.P4WLevel * UIManagerScript.levelIncreaseAmount - UIManagerScript.levelIncreaseAmount));
            if (myWeight > UIManagerScript.levelIncreaseAmount * UIManagerScript.P4WLevel)
            {
                UIManagerScript.P4WLevel += 1;
            }
            else if (myWeight < (UIManagerScript.P4WLevel * UIManagerScript.levelIncreaseAmount - UIManagerScript.levelIncreaseAmount) && UIManagerScript.P4WLevel != 1)
            {
                UIManagerScript.P4WLevel -= 1;
            }

            UIManagerScript.P4LevelNumber.sprite = sizeLevelNumber[UIManagerScript.P4WLevel - 1];
        }
    }

    void IncreaseSize()
    {

    }

    void DecreaseSize()
    {

    }
}
