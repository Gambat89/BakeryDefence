using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BugsSummons : MonoBehaviour
{
    public GameObject bugs;

    public int bugsCounts; // wave마다 생성할 벌레 수

    public float bugsCounttimer; // 벌레 생성 시간

    public float stageTimer; // wave 시간

   

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(BugSum());
    }


    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator BugSum()
    {
        while (true)
        {
            for (int a = 0; a < 5; a++)
            {
                for (int i = 1; i <= bugsCounts; i++)
                {
                    int count = GameObject.FindGameObjectsWithTag("Ant").Length;
                    Debug.Log("count : "+ count + " a : " + a);

                    if ( a >= 1 && count == 0)
                    {
                        a++;
                        i = 1;
                        Debug.Log("a : " + a);
                    }
                    
                    GameObject newBugs = Instantiate(bugs, GameManager.instance.antsObject.transform.position, Quaternion.identity);
                    newBugs.transform.SetParent(GameManager.instance.antsObject.transform);

                    yield return new WaitForSeconds(bugsCounttimer);
                }
                yield return new WaitForSeconds(stageTimer);
            }

            break;
        }
    }
}
