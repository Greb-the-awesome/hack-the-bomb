using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Fade : MonoBehaviour
{

    public TextMeshProUGUI buttonText;
    public Button startButton;
    public TextMeshProUGUI titleText;
    public AudioSource explosionSound;
    public GameObject backgroundPanel;
    public AudioSource backgroundMusic;
    public string sceneToLoad;
    private CanvasGroup canvasGroup;
    private IEnumerator fadeCoroutine;
    private Color buttonColor;
    public float buttonFadeDuration = 1.0f;
    public float waitDuration = 3.0f;
    public float panelFadeDuration = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        fadeCoroutine = FadeOut();
        StartCoroutine(fadeCoroutine);
        startButton.gameObject.SetActive(false);
    }

    IEnumerator FadeOut()
    {
        yield return new WaitForSeconds(waitDuration);
        float timeElapsed = 0;
        buttonColor = startButton.GetComponent<Image>().color;

        startButton.gameObject.SetActive(true);
        while (timeElapsed < buttonFadeDuration)
        {
            timeElapsed += Time.deltaTime;
            float alpha = Mathf.Lerp(0, 1, timeElapsed / buttonFadeDuration);
            startButton.GetComponent<Image>().color = new Color(buttonColor.r, buttonColor.g, buttonColor.b, alpha);
            buttonText.color = new Color(0, 0, 0, alpha);
            yield return null;
        }
   
    }

    public void onStart()
    {
        startButton.gameObject.SetActive(false);
        titleText.gameObject.SetActive(false);
        GameObject.Find("Logo").SetActive(false);
        backgroundMusic.volume = 1.0f;
        StopCoroutine(fadeCoroutine);
        explosionSound.Play();
        Debug.Log("Played sound");

        StartCoroutine(ExplosionPanel());
       
    }

    IEnumerator ExplosionPanel()
    {

        float originalMusicVolume = backgroundMusic.volume;
        Debug.Log("running the coroutine");
        float timeElapsed = 0;

        while (timeElapsed < panelFadeDuration)
        {
            float red = UnityEngine.Random.Range(buttonColor.r - 0.1f, buttonColor.r + 0.1f);
            float green = UnityEngine.Random.Range(buttonColor.g - 0.1f, buttonColor.g + 0.1f);
            float blue = UnityEngine.Random.Range(buttonColor.b - 0.1f, buttonColor.b + 0.1f);

            timeElapsed += Time.deltaTime;
            float multiplier = 1 - timeElapsed / panelFadeDuration;

            red *= multiplier;
            green *= multiplier;
            blue *= multiplier;

            backgroundPanel.GetComponent<Image>().color = new Color(red, green, blue);
            backgroundMusic.volume = originalMusicVolume * multiplier;
            yield return null;
        }

        SceneManager.LoadScene(sceneToLoad);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
