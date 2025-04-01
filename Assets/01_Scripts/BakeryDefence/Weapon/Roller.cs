using System.Collections;
using UnityEngine;

public class Roller : MonoBehaviour
{
    public enum RollerVec { side1, side2, side3, side4 }
    public RollerVec rollerVec;

    SpriteRenderer spriteRenderer;

    float fadeOutSpeed = 25f;
    float moveSpeed = 1f;
    float gamma = 1f;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnEnable()
    {
        StartCoroutine(FadeOut());
        StartCoroutine(Move());

    }

    IEnumerator Move()
    {
        while (true)
        {
            switch (rollerVec)
            {
                case RollerVec.side1:
                    transform.position += new Vector3(7, 4, 0) * Time.deltaTime * moveSpeed;
                    break;

                case RollerVec.side2:
                    transform.position += new Vector3(-7, 4, 0) * Time.deltaTime * moveSpeed;
                    break;

                case RollerVec.side3:
                    transform.position += new Vector3(-7, -4, 0) * Time.deltaTime * moveSpeed;
                    break;

                case RollerVec.side4:
                    transform.position += new Vector3(7, -4, 0) * Time.deltaTime * moveSpeed;
                    break;
            }
            
            if (GetComponent<SpriteRenderer>().flipY)
            {
                GetComponent<SpriteRenderer>().flipY = false;
            }
            else
            {
                GetComponent<SpriteRenderer>().flipY = true;
            }
            
            yield return new WaitForSecondsRealtime(0.01f);
        }
    }

    IEnumerator FadeOut()
    {
        yield return new WaitForSecondsRealtime(0.5f);

        while(spriteRenderer.color.a > 0)
        {
            spriteRenderer.color = new Color(255, 255, 255, gamma);
            gamma -= Time.deltaTime * fadeOutSpeed;
            yield return new WaitForSecondsRealtime(0.05f);
        }

        Destroy(gameObject);
    }
}
