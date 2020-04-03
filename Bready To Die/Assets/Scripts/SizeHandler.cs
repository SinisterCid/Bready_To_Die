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

    public float myWeightLevel;
    float oldSize1 = 0;
    float newSize1;
    float oldSize2 = 0;
    float newSize2;
    public bool changeSize;
    public SkinnedMeshRenderer duckMesh;

    public Sprite[] sizeLevelNumber;

    // Start is called before the first frame update
    void Start()
    {
        oldSize1 = 0;
        oldSize2 = 0;
        changeSize = false;
        duckMesh = GetComponentInChildren<SkinnedMeshRenderer>();
        myDuck = GetComponent<Duck>();
        UIManagerScript = GameObject.Find("GameManager").GetComponent<UIManager>();
    }

    // Update is called once per frame
    void Update()
    {
        HandleSize();
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
                changeSize = true;
                UIManagerScript.P1WLevel += 1;
                
            }
            else if (myWeight < (UIManagerScript.P1WLevel * UIManagerScript.levelIncreaseAmount - UIManagerScript.levelIncreaseAmount) && UIManagerScript.P1WLevel != 1)
            {
                changeSize = true;
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
                changeSize = true;
            }
            else if (myWeight < (UIManagerScript.P2WLevel * UIManagerScript.levelIncreaseAmount - UIManagerScript.levelIncreaseAmount) && UIManagerScript.P2WLevel != 1)
            {
                UIManagerScript.P2WLevel -= 1;
                changeSize = true;
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
                changeSize = true;
            }
            else if (myWeight < (UIManagerScript.P3WLevel * UIManagerScript.levelIncreaseAmount - UIManagerScript.levelIncreaseAmount) && UIManagerScript.P3WLevel != 1)
            {
                UIManagerScript.P3WLevel -= 1;
                changeSize = true;
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
                changeSize = true;
            }
            else if (myWeight < (UIManagerScript.P4WLevel * UIManagerScript.levelIncreaseAmount - UIManagerScript.levelIncreaseAmount) && UIManagerScript.P4WLevel != 1)
            {
                UIManagerScript.P4WLevel -= 1;
                changeSize = true;
            }

            UIManagerScript.P4LevelNumber.sprite = sizeLevelNumber[UIManagerScript.P4WLevel - 1];
        }
    }

    void HandleSize()
    {
        if (myWeightLevel == 1)
        {
            newSize1 = 0;
            newSize2 = 0;

            float currentSize1 = Mathf.Lerp(oldSize1, newSize1, 1);
            float currentSize2 = Mathf.Lerp(oldSize2, newSize2, 1);

            duckMesh.SetBlendShapeWeight(0, currentSize1);
            duckMesh.SetBlendShapeWeight(1, currentSize2);

            if (duckMesh.GetBlendShapeWeight(1) == 0 && duckMesh.GetBlendShapeWeight(2) == 0)
            {
                oldSize1 = newSize1;
                oldSize2 = newSize2;
            }
        }
        if (myWeightLevel == 2)
        {
            newSize1 = 100;
            newSize2 = 0;
            
            float currentSize1 = Mathf.Lerp(oldSize1, newSize1, 1);
            float currentSize2 = Mathf.Lerp(oldSize2, newSize2, 1);

            duckMesh.SetBlendShapeWeight(0, currentSize1);
            duckMesh.SetBlendShapeWeight(1, currentSize2);

            if (duckMesh.GetBlendShapeWeight(1) == 100 && duckMesh.GetBlendShapeWeight(2) == 0)
            {
                oldSize1 = newSize1;
                oldSize2 = newSize2;
            }
        }
        if (myWeightLevel == 3)
        {                
            newSize1 = 100;
            newSize2 = 33;

            float currentSize1 = Mathf.Lerp(oldSize1, newSize1, 1);
            float currentSize2 = Mathf.Lerp(oldSize2, newSize2, 1);

            duckMesh.SetBlendShapeWeight(0, currentSize1);
            duckMesh.SetBlendShapeWeight(1, currentSize2);

            if (duckMesh.GetBlendShapeWeight(1) == 100 && duckMesh.GetBlendShapeWeight(2) == 33)
            {
                oldSize1 = newSize1;
                oldSize2 = newSize2;
            }

        }
        if (myWeightLevel == 4)
        {
            newSize1 = 100;
            newSize2 = 66;

            float currentSize1 = Mathf.Lerp(oldSize1, newSize1, 1);
            float currentSize2 = Mathf.Lerp(oldSize2, newSize2, 1);

            duckMesh.SetBlendShapeWeight(0, currentSize1);
            duckMesh.SetBlendShapeWeight(1, currentSize2);

            if (duckMesh.GetBlendShapeWeight(1) == 100 && duckMesh.GetBlendShapeWeight(2) == 66)
            {
                oldSize1 = newSize1;
                oldSize2 = newSize2;
            }
        }
        if (myWeightLevel == 5)
        {
            newSize1 = 100;
            newSize2 = 100;

            float currentSize1 = Mathf.Lerp(oldSize1, newSize1, 1);
            float currentSize2 = Mathf.Lerp(oldSize2, newSize2, 1);

            duckMesh.SetBlendShapeWeight(0, currentSize1);
            duckMesh.SetBlendShapeWeight(1, currentSize2);

            if (duckMesh.GetBlendShapeWeight(1) == 100 && duckMesh.GetBlendShapeWeight(2) == 100)
            {
                oldSize1 = newSize1;
                oldSize2 = newSize2;
            }
        }
    }
}
