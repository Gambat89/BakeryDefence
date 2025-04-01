using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detector : MonoBehaviour
{
    Mouse parent;
    private void Start()
    {
        parent = transform.parent.GetComponent<Mouse>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ant"))
        {
            parent.detectedEnemies.Add(collision.gameObject);

            if (!parent.isAttack)
            {
                transform.parent.GetComponent<Mouse>().Attack();
                parent.isAttack = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ant"))
        {
            transform.parent.GetComponent<Mouse>().detectedEnemies.Remove(collision.gameObject);
        }
    }
}
