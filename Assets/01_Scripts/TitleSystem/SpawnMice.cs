using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMice : MonoBehaviour
{
    public GameObject mouseFace;

    public float spawnInterval = 1.0f; // 오브젝트가 떨어지는 간격
    public float maxX = 8.0f; // x축 최대범위
    public float minX = -8.0f; // x축 최소범위

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawnmice());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Spawnmice()
    {
        while (true)
        {
            float spawnPosX = Random.Range(minX, maxX);
            Vector2 spawnPosition = new Vector2(spawnPosX, transform.position.y);

            Instantiate(mouseFace, spawnPosition, Quaternion.identity);


            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
