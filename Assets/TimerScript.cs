using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimerScript : MonoBehaviour
{
    // Start is called before the first frame update
    public string defaultText = "0:00";
    // private int timeElapsed = 0;
    public TextMeshProUGUI tmText;
    void Start()
    {
        try
        {
            tmText.text = defaultText;
        }
        catch { }
    }

    public void UpdateTimer(int secondsLeft)
    {
        int minutes = secondsLeft / 60;
        int seconds = secondsLeft % 60;
        string timerText = $"{minutes}:{seconds:00}";

        try {
            if (minutes == 0)
            {
                tmText.color = Color.red;
            }
            else
            {
                tmText.color = Color.white;
            }
            tmText.text = timerText;

            if(secondsLeft <= 0)
            {
                SceneManager.LoadScene("EndingFailCutScene");

            }
        }
        catch  {
            //
        }
    }

    // Update is called once per frame
    void Update()
    {
        UpdateTimer(500);

    }
}
