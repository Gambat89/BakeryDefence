using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ant : MonoBehaviour
{
    public float currentHealth;     // 현재 체력
    public float maxHealth = 100;   // 최대 체력

    public AntGhost antGhost;       // 죽었을 때 Prefab

    public Image currentHealthImg;  // 체력바 이미지

    float rapTime = 18.5f / 4f;

    float dividNum = 144;

    SpriteRenderer spriteRd;
    Animator animator;

    Vector3 side1Vec = new Vector3(-7, 4, 0);
    Vector3 side2Vec = new Vector3(-7, -4, 0);
    Vector3 side3Vec = new Vector3(7, -4, 0);
    Vector3 side4Vec = new Vector3(7, 4, 0);

    Vector3 moveVec;

    private void Awake()
    {
        spriteRd = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        maxHealth = 50 * GameManager.instance.roundNum - 21;

        currentHealth = maxHealth;
        currentHealthImg.fillAmount = currentHealth / maxHealth;

        StartCoroutine(Side2Move());
        StartCoroutine(Die());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Frame"))
        {
            currentHealth -= 40;
            currentHealthImg.fillAmount = currentHealth / maxHealth;
        }

        if (collision.CompareTag("Roller"))
        {
            currentHealth -= 30;
            currentHealthImg.fillAmount = currentHealth / maxHealth;
        }
    }

    IEnumerator Side1Move()
    {
        AntMove(side1Vec, true, true);

        while (transform.position.y < 4f)
        {
            transform.position += moveVec / dividNum;
            yield return new WaitForSecondsRealtime(rapTime / dividNum);
        }

        StartCoroutine(Side2Move());
        StopCoroutine(Side1Move());
    }
    
    IEnumerator Side2Move()
    {
        AntMove(side2Vec, false, false);

        while (transform.position.x > -7f)
        {
            transform.position += moveVec / dividNum;
            yield return new WaitForSecondsRealtime(rapTime / dividNum);
        }

        StartCoroutine(Side3Move());
        StopCoroutine(Side2Move());
    }
    
    IEnumerator Side3Move()
    {
        AntMove(side3Vec, false, true);

        while (transform.position.y > -4f)
        {
            transform.position += moveVec / dividNum;
            yield return new WaitForSecondsRealtime(rapTime / dividNum);
        }

        StartCoroutine(Side4Move());
        StopCoroutine(Side3Move());
    }
    
    IEnumerator Side4Move()
    {
        AntMove(side4Vec, true, false);

        while (transform.position.x < 7f)
        {
            transform.position += moveVec / dividNum;
            yield return new WaitForSecondsRealtime(rapTime / dividNum);
        }

        StartCoroutine(Side1Move());
        StopCoroutine(Side4Move());
    }

    IEnumerator Die()
    {
        while (true)
        {
            if (currentHealth <= 0)
            {
                GameManager.instance.ants.Remove(gameObject);
                UIManager.instance.cleanText.text = string.Format("{0} / 100", GameManager.instance.ants.Count);

                Instantiate(antGhost, transform.position, transform.rotation);
                Destroy(gameObject);
            }
            yield return null;
        }
    }

    void AntMove(Vector3 sideVec, bool up, bool flip)
    {
        moveVec = sideVec;
        spriteRd.flipX = flip;
    }
}
