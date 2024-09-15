using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TextFadeout : MonoBehaviour
{
    public TextMeshProUGUI textMeshProText; // The text to fade in and out
    public float fadeDuration = 2.0f; // Duration of the fade in/out
    public float[] displayDuration; // How long the text stays visible before fading out

    // Array of text strings to show in sequence
    public string[] textSequence = {
                                     "It's that time of the year again, where you and a few hopeful hackers dream big and let your imaginations create the craziest of products despite your limited time.",
                                     "After hacking away for a few hours, you notice that the group beside you had cooked up something diabolical. It appears to be a fully functional bomb, with a timer. Before you can say anything, however, they leave to get funnel cakes.",
                                     "Wanting to continue the hackathon the next day, you rush to find any documentation the group may have left to defuse the bomb. You find the group's rough notes on how the bomb may be defused.",
                                     "\"ideas: use scav. hunt w/ puzzles. 36 hrs of fun>?// jigsaw! haha bomb go boom boom,. i yearn for the couhces. 43 sponsors!!? Get BEHIND this absurdity..\""
                                   };
    public string returnTo;

    void Start()
    {
        StartCoroutine(TextSequence());
        displayDuration = new float[4];
        displayDuration[0] = 2f;
        displayDuration[1] = 2.5f;
        displayDuration[2] = 2.5f;
        displayDuration[3] = 5f;
        // displayDuration[0] = 0.1f;
        // displayDuration[1] = 0.1f;
        // displayDuration[2] = 0.1f;
        // displayDuration[3] = 0.1f;
        Cursor.lockState = CursorLockMode.None;
    }

    IEnumerator TextSequence()
    {
        // Loop through each text in the sequence
        int i=0;
        Cursor.lockState = CursorLockMode.None;
        foreach (string text in textSequence)
        {
            textMeshProText.text = text; // Set the new text
            yield return StartCoroutine(FadeInText()); // Fade in the text
            yield return new WaitForSeconds(displayDuration[i]); // Keep the text visible for a certain time
            yield return StartCoroutine(FadeOutText()); // Fade out the text
            i++;
        }
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene(returnTo);
    }

    IEnumerator FadeInText()
    {Cursor.lockState = CursorLockMode.None;
        float elapsedTime = 0;
        Color originalColor = textMeshProText.color;
        originalColor.a = 0; // Set initial alpha to 0 (completely transparent)
        textMeshProText.color = originalColor;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            originalColor.a = Mathf.Lerp(0, 1, elapsedTime / fadeDuration); // Fade in (alpha from 0 to 1)
            textMeshProText.color = originalColor;
            yield return null;
        }
    }

    IEnumerator FadeOutText()
    {Cursor.lockState = CursorLockMode.None;
        float elapsedTime = 0;
        Color originalColor = textMeshProText.color;
        originalColor.a = 1; // Set initial alpha to 1 (completely opaque)
        textMeshProText.color = originalColor;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            originalColor.a = Mathf.Lerp(1, 0, elapsedTime / fadeDuration); // Fade out (alpha from 1 to 0)
            textMeshProText.color = originalColor;
            yield return null;
        }
    }
}
