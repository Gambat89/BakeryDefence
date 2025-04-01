using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Wave : MonoBehaviour
{
    public string waveName;

    public int bugsCounts;          // 생성 벌레 수

    public GameObject bugs;         // 벌레 종류

    Transform bugsParents;          // 생성될 위치 부모 오브젝트

    public float bugsCountTimer;    // 생성 시간 초

    private void Start()
    {
        bugsParents = GameManager.instance.antsObject.transform;
    }

    public void Spawn()
    {
        GameManager.instance.waveDone = false;

        UIManager.instance.stageText.text = waveName;

        StartCoroutine(BugsSummons());
    }

    IEnumerator BugsSummons()
    {
        for (int i = 1; i <= bugsCounts; i++)
        {
            GameObject newBugs = Instantiate(bugs, bugsParents);

            GameManager.instance.ants.Add(newBugs);
            UIManager.instance.cleanText.text = string.Format("{0} / 100", GameManager.instance.ants.Count);

            yield return new WaitForSeconds(bugsCountTimer);
        }

        while (!GameManager.instance.waveDone)
        {
            if (GameManager.instance.ants.Count == 0)
            {
                GameManager.instance.waveDone = true;
            }
            yield return null;
        }
    }
}
