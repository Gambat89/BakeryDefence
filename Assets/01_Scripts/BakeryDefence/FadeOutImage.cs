using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeOutImage : MonoBehaviour
{
    float gamma;
    float fadeOutSpeed = 15f;

    private void OnEnable()
    {
        StartCoroutine(FadeOut());
    }

    IEnumerator FadeOut()
    {
        while(gamma < 0.93)
        {
            gamma += Time.deltaTime * fadeOutSpeed;
            GetComponent<Image>().color = new Color(0, 0, 0, gamma);
            yield return new WaitForSecondsRealtime(0.05f);
        }
    }
}
