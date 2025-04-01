using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrameMouse : Mouse
{
    public override void Attack()
    {
        StartCoroutine(FrameAttack());
        base.Attack();
    }

    IEnumerator FrameAttack()
    {
        spriteRenderer.sprite = mouseMotion[0];

        yield return new WaitForSecondsRealtime(0.8f);

        spriteRenderer.sprite = mouseMotion[1];

        yield return new WaitForSecondsRealtime(1f);

        // 영역 내 첫번째 적 위치에 모양틀 던지기
        if (detectedEnemies.Count != 0)
        {
            GameObject weapon = Instantiate(mouseWeapon);
            weapon.transform.position = detectedEnemies[0].transform.position + Vector3.up * 5f;
            spriteRenderer.sprite = mouseMotion[2];
        }
        
        yield return new WaitForSecondsRealtime(0.3f);

        if (detectedEnemies.Count != 0)
        {
            StartCoroutine(FrameAttack());
        }
        else
        {
            spriteRenderer.sprite = mouseMotion[0];
            isAttack = false;
        }
    }
}
