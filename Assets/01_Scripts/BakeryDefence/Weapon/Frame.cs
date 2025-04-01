using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frame : MonoBehaviour
{
    float dropDis = 0.15f;
    float fadeSpeed; // 물체가 사라지는 속도
    float DropPoint = 5f; // 값 이하로 떨어지면 급격히 투명도 감소
    
    SpriteRenderer spriteRenderer;

    private void OnEnable()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        
        StartCoroutine(Drop());
    }

    IEnumerator Drop()
    {
        float dropSum = 0f;
        float alpha = spriteRenderer.color.a;

        yield return new WaitForSecondsRealtime(0.05f);

        while (dropSum < 5f)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - dropDis, transform.position.z);
            dropSum += dropDis;

            if(dropSum >= DropPoint)
            {
                fadeSpeed = 10f;
            }

            // 투명도 조절
            var color = spriteRenderer.color;
            alpha -= fadeSpeed*Time.deltaTime;
            color.a = Mathf.Clamp(alpha, 0, 1); // 알파값 0 이하로 안떨어지게 함.
            spriteRenderer.color = color;

            yield return new WaitForSecondsRealtime(0.005f);
        }

        yield return new WaitForSecondsRealtime(0.1f);
        Destroy(gameObject);
    }

    
}
