using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GoToTitle : MonoBehaviour
{
    public Text timerText;
    public float timer = 120;
    UIManager UIScript;

    private void Start()
    {
        UIScript = GameObject.Find("GameManager").GetComponent<UIManager>();
    }

    private void Update()
    {
        timer -= Time.deltaTime;

        timerText.text = Mathf.RoundToInt(timer).ToString();
        if (timer <= 0)
        {
            UIScript.EndGame();
        }
    }
}
