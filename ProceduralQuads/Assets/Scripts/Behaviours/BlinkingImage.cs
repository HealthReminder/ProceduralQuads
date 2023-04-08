using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class BlinkingImage : MonoBehaviour
{
    public Image image;
    public float blinkSpeed = 0.5f;
    public float blinkDuration = 0.2f;

   public void Blink()
    {
        StartCoroutine(BlinkRoutine());
    }

    private IEnumerator BlinkRoutine()
    {
       // while (true)
        //{
            float elapsedTime = 0f;
            //while (elapsedTime < blinkDuration)
            //{
            //    float alpha = Mathf.Lerp(0f, 1f, elapsedTime / blinkDuration);
            //    image.color = new Color(0f, 0f, 0f, alpha);
            //    elapsedTime += Time.deltaTime;
            //    yield return null;
            //}
            image.color = new Color(0f, 0f, 0f, 1f);

            yield return new WaitForSeconds(blinkSpeed - blinkDuration);

            elapsedTime = 0f;
            while (elapsedTime < blinkDuration)
            {
                float alpha = Mathf.Lerp(1f, 0f, elapsedTime / blinkDuration);
                image.color = new Color(0f, 0f, 0f, alpha);
                elapsedTime += Time.deltaTime;
                yield return null;
            }
            image.color = new Color(0f, 0f, 0f, 0f);

            yield return new WaitForSeconds(blinkSpeed - blinkDuration);
       // }
    }
}