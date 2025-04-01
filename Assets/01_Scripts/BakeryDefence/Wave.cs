using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Wave : MonoBehaviour
{
    public string waveName;

    public int bugsCounts;          // ���� ���� ��

    public GameObject bugs;         // ���� ����

    Transform bugsParents;          // ������ ��ġ �θ� ������Ʈ

    public float bugsCountTimer;    // ���� �ð� ��

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
