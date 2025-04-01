using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollerMouse : Mouse
{
    public override void Attack()
    {
        StartCoroutine(RollerAttack());
        base.Attack();
    }

    IEnumerator RollerAttack()
    {
        spriteRenderer.sprite = mouseMotion[0];

        yield return new WaitForSecondsRealtime(0.8f);

        // 쥐 앞에 밀대 던지기
        if (detectedEnemies.Count != 0)
        {
            if ((detectedEnemies[0].transform.position.x > 0 && detectedEnemies[0].transform.position.y > 0) || (detectedEnemies[0].transform.position.x < 0 && detectedEnemies[0].transform.position.y < 0))
            {
                GameObject weapon = Instantiate(mouseWeapon);
                weapon.transform.position = transform.position;
                weapon.transform.rotation = Quaternion.Euler(0, 0, -30);

                if (detectedEnemies[0].transform.position.y > 0)
                {
                    weapon.GetComponent<Roller>().rollerVec = Roller.RollerVec.side1;
                }
                else
                {
                    weapon.GetComponent<Roller>().rollerVec = Roller.RollerVec.side3;
                }
            }
            else
            {
                GameObject weapon = Instantiate(mouseWeapon);
                weapon.transform.position = transform.position;

                if (detectedEnemies[0].transform.position.y > 0)
                {
                    weapon.GetComponent<Roller>().rollerVec = Roller.RollerVec.side2;
                }
                else
                {
                    weapon.GetComponent<Roller>().rollerVec = Roller.RollerVec.side4;
                }
            }
            spriteRenderer.sprite = mouseMotion[1];
        }
        
        yield return new WaitForSecondsRealtime(0.3f);

        if (detectedEnemies.Count != 0)
        {
            StartCoroutine(RollerAttack());
        }
        else
        {
            spriteRenderer.sprite = mouseMotion[0];
            isAttack = false;
        }
    }
}
