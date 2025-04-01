using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoughMouse : Mouse
{
    public override void Attack()
    {
        StartCoroutine(DoughAttack());
        base.Attack();
    }

    IEnumerator DoughAttack()
    {
        spriteRenderer.sprite = mouseMotion[1];

        yield return new WaitForSecondsRealtime(0.5f);

        // 영역 내 첫번째 적 체력 감소 시키기
        if (detectedEnemies.Count != 0)
        {
            detectedEnemies[0].GetComponent<Ant>().currentHealth -= 10;
            detectedEnemies[0].GetComponent<Ant>().currentHealthImg.fillAmount = detectedEnemies[0].GetComponent<Ant>().currentHealth / detectedEnemies[0].GetComponent<Ant>().maxHealth;

            spriteRenderer.sprite = mouseMotion[2];
        }

        yield return new WaitForSecondsRealtime(0.1f);
        if (detectedEnemies.Count != 0)
        {
            StartCoroutine(DoughAttack());
        }
        else
        {
            spriteRenderer.sprite = mouseMotion[0];
            isAttack = false;
        }
    }
}
