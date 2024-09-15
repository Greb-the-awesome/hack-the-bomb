using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CodeEnterScript : MonoBehaviour
{
    public int code;
    public bool correctCodeEntered = false;
    public TextMeshProUGUI incorrectText;
    public TextMeshProUGUI correctText;
    public AudioSource correctSound;
    public GameObject codeInputField;
    public string sceneToReturnTo;
    // Start is called before the first frame update
    void Start()
    {
      Cursor.lockState = CursorLockMode.None;
    }

    public void CheckCode()
    {
        Cursor.lockState = CursorLockMode.None;
        string inputtedText = codeInputField.GetComponent<TMP_InputField>().text;
        int inputtedNumber = int.Parse(inputtedText);
        correctCodeEntered = code == inputtedNumber;

        if (correctCodeEntered )
        {
            correctText.gameObject.SetActive(true);

            SceneManager.LoadScene( sceneToReturnTo );
            Stats.puzzlesDone++;
        } else
        {
            incorrectText.gameObject.SetActive(true);
        }
        Cursor.lockState = CursorLockMode.None;
    }

    public void Exit()
    {
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene(sceneToReturnTo);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
