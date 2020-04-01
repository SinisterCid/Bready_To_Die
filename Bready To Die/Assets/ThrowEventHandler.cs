using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowEventHandler : MonoBehaviour
{
    public GrandmaAI grandmaAIScript;

    public void breadTossEvent()
    {
        grandmaAIScript.SpawnBread();
        print("event");
    }
}
