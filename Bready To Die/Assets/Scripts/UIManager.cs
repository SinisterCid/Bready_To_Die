using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    PlayerCountManager PCScript;
    PlayerManager PMScript;

    public Text P1WeightText;
    public Text P2WeightText;
    public Text P3WeightText;
    public Text P4WeightText;

    public Image P1WeightLevel;
    public Image P2WeightLevel;
    Image P3WeightLevel;
    Image P4WeightLevel;

    public Image P1LevelNumber;
    public Image P2LevelNumber;
    public Image P3LevelNumber;
    public Image P4LevelNumber;

    public float P1Weight = 0;
    public float P2Weight = 0;
    public float P3Weight = 0;
    public float P4Weight = 0;

    float P1tempWeight;
    float P2tempWeight;
    float P3tempWeight;
    float P4tempWeight;

    public int P1WLevel = 1;
    public int P2WLevel = 1;
    public int P3WLevel = 1;
    public int P4WLevel = 1;

    public float levelIncreaseAmount = 10;

    // Start is called before the first frame update
    void Start()
    {
        PCScript = GetComponent<PlayerCountManager>();
        PMScript = GameObject.Find("PlayerManager").GetComponent<PlayerManager>();
        if (PCScript.P1Exists)
        {
            P1WLevel = 1;
            P1WeightText = GameObject.Find("P1UI").GetComponentInChildren<Text>();
            P1WeightLevel = GameObject.Find("BackFill1").GetComponent<Image>();
            P1LevelNumber = GameObject.Find("WeightLevel1").GetComponent<Image>();
        }
        else
        {
            GameObject.Find("P1UI").SetActive(false);
        }
        if (PCScript.P2Exists)
        {
            P2WLevel = 1;
            P2WeightText = GameObject.Find("P2UI").GetComponentInChildren<Text>();
            P2WeightLevel = GameObject.Find("BackFill2").GetComponent<Image>();
            P2LevelNumber = GameObject.Find("WeightLevel2").GetComponent<Image>();
        }
        else
        {
            GameObject.Find("P2UI").SetActive(false);
        }
        if (PCScript.P3Exists)
        {
            P3WLevel = 1;
            P3WeightText = GameObject.Find("P3UI").GetComponentInChildren<Text>();
            P3WeightLevel = GameObject.Find("BackFill3").GetComponent<Image>();
            P3LevelNumber = GameObject.Find("WeightLevel3").GetComponent<Image>();
        }
        else
        {
            GameObject.Find("P3UI").SetActive(false);
        }
        if (PCScript.P4Exists)
        {
            P4WLevel = 1;
            P4WeightText = GameObject.Find("P4UI").GetComponentInChildren<Text>();
            P4WeightLevel = GameObject.Find("BackFill4").GetComponent<Image>();
            P4LevelNumber = GameObject.Find("WeightLevel4").GetComponent<Image>();
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

        if (P1Weight >= 50 || P2Weight >= 50 || P3Weight >= 50 || P4Weight >= 50)
        {
            EndGame();
        }
    }

    void HandlePlayer1()
    {
        if (P1WeightText != null && PCScript.P1Exists)
        {
            P1tempWeight = (P1Weight - (P1WLevel * levelIncreaseAmount - levelIncreaseAmount));
            P1WeightText.text = "Weight (lbs): " + P1Weight;
            P1WeightLevel.fillAmount = P1tempWeight / levelIncreaseAmount;
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
            P2tempWeight = (P2Weight - (P2WLevel * levelIncreaseAmount - levelIncreaseAmount));
            P2WeightText.text = "Weight (lbs): " + P2Weight;
            P2WeightLevel.fillAmount = P2tempWeight / levelIncreaseAmount;
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
            P3tempWeight = (P3Weight - (P3WLevel * levelIncreaseAmount - levelIncreaseAmount));
            P3WeightText.text = "Weight (lbs): " + P3Weight;
            P3WeightLevel.fillAmount = P3tempWeight / levelIncreaseAmount;
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
            P4tempWeight = (P4Weight - (P4WLevel * levelIncreaseAmount - levelIncreaseAmount));
            P4WeightText.text = "Weight (lbs): " + P4Weight;
            P4WeightLevel.fillAmount = P4tempWeight / levelIncreaseAmount;
        }

        if (P4Weight < 0)
        {
            P4Weight = 0;
        }
    }

    public void EndGame()
    {
        PMScript.P1EndWeight = P1Weight;
        PMScript.P2EndWeight = P2Weight;
        PMScript.P3EndWeight = P3Weight;
        PMScript.P4EndWeight = P4Weight;
        SceneManager.LoadScene("WinnerScene");
    }
}
