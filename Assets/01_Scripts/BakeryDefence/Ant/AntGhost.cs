using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntGhost : MonoBehaviour
{
    float gamma = 1;
    float fadeOutSpeed = 10f;
    float upSpeed = 4f;

    private void OnEnable()
    {
        StartCoroutine(FadeOut());
    }

    IEnumerator FadeOut()
    {
        while (gamma > 0f)
        {
            gamma -= Time.deltaTime * fadeOutSpeed;
            transform.position += Vector3.up * Time.deltaTime * upSpeed;
            GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, gamma);
            yield return new WaitForSecondsRealtime(0.05f);
        }

        Destroy(gameObject);
    }
}
