using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse : MonoBehaviour
{
    public List<GameObject> detectedEnemies = new List<GameObject>();

    public PrefabData status;

    public GameObject mouseWeapon;

    public Sprite[] mouseMotion;

    public bool isAttack = false;

    protected SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (detectedEnemies.Count != 0)
        {
            if (detectedEnemies[0].transform.position.x - transform.position.x > 0)
            {
                spriteRenderer.flipX = true;
            }
            else spriteRenderer.flipX = false;
        }
    }

    public virtual void Attack()
    {
        
    }
}
