using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ScreenFade : MonoBehaviour
{
    public float fadeDuration = 2f; // The duration of the fade in seconds

    private Image fadeImage; // The UI image used for fading

    private void Start()
    { 
        // Get the UI image component from the canvas
        fadeImage = GetComponentInChildren<Image>();

        // Set the image color to white
        fadeImage.color = Color.black;

        // Start fading the image in
        FadeIn();
    }

    public void FadeIn()
    {
        // Enable the image and set its alpha to 1
        fadeImage.enabled = true;
        Color newColor = fadeImage.color;
        newColor.a = 1f;
        fadeImage.color = newColor; 

        // Start fading the image by reducing the alpha value over time
        StartCoroutine(FadeImage(0f));
    }

    public void FadeOut()
    {
        // Enable the image and set its alpha to 0
        fadeImage.enabled = true;
        Color newColor = fadeImage.color;
        newColor.a = 0f;
        fadeImage.color = newColor;

        // Start fading the image by increasing the alpha value over time
        StartCoroutine(FadeImage(1f));
    }

    private IEnumerator FadeImage(float targetAlpha)
    {
        // Calculate the amount to fade per frame based on the fade duration
        float fadeAmountPerFrame = Mathf.Abs(fadeImage.color.a - targetAlpha) / fadeDuration;

        // Fade the image by adjusting the alpha value over time
        while (Mathf.Abs(fadeImage.color.a - targetAlpha) > 0.01f)
        {
            Color newColor = fadeImage.color;
            newColor.a = Mathf.MoveTowards(newColor.a, targetAlpha, fadeAmountPerFrame * Time.deltaTime);
            fadeImage.color = newColor;
            yield return null;
        }

        // Disable the image once it has faded completely
        if (targetAlpha == 0f)
        {
            fadeImage.enabled = false;
        }
    }
}