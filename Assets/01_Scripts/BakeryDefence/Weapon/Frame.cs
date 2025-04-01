using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frame : MonoBehaviour
{
    float dropDis = 0.15f;
    float fadeSpeed; // ��ü�� ������� �ӵ�
    float DropPoint = 5f; // �� ���Ϸ� �������� �ް��� ���� ����
    
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

            // ���� ����
            var color = spriteRenderer.color;
            alpha -= fadeSpeed*Time.deltaTime;
            color.a = Mathf.Clamp(alpha, 0, 1); // ���İ� 0 ���Ϸ� �ȶ������� ��.
            spriteRenderer.color = color;

            yield return new WaitForSecondsRealtime(0.005f);
        }

        yield return new WaitForSecondsRealtime(0.1f);
        Destroy(gameObject);
    }

    
}
