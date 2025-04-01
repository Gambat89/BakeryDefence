using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.UI;

public class DropMice : MonoBehaviour
{
    public GameObject mouseFace;

    public float roatationSpeed;
    public float fallSpeed; // 떨어지는 속도
    public float destotime;
    
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = mouseFace.GetComponent<Rigidbody2D>();

        if (rb == null)
        {
            rb = gameObject.AddComponent<Rigidbody2D>();
        }

        rb.gravityScale = 0;

        StartCoroutine(DestorMice());
    }
    // Update is called once per frame
    void Update()
    {
        DroppingMice();
    }

    void DroppingMice()
    {
        Transform newMouse = mouseFace.GetComponent<Transform>();

        newMouse.Rotate(new Vector3(0, 0, roatationSpeed * Time.deltaTime));

        rb.velocity = new Vector2(0, -fallSpeed);
    }

    IEnumerator DestorMice()
    {
        yield return new WaitForSeconds(destotime);
        Destroy(mouseFace);
    }

}
