using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomGacha : MonoBehaviour
{
    List<GameObject> mousePositions = new List<GameObject>();
    Transform[] childMousePosition;

    bool isFirst = true;

    float totals = 0;

    public Transform mousePos;

    public List<GameObject> mouseObject = new List<GameObject>();

    public List<GameObject> mouseResults = new List<GameObject>();

    public Wave firstWave;

    void Start()
    {
        Percentagefunction();
        ArrayPosList();
    }
    
    void Percentagefunction()
    {
        for (int i = 0; i < mouseObject.Count; i++)
        {
            PrefabData status = mouseObject[i].GetComponent<Mouse>().status;

            if (status != null)
            {
                totals += status.percentage;
            }
            else
            {
                return;
            }
        }
    }

    void ArrayPosList()
    {
        childMousePosition = mousePos.GetComponentsInChildren<Transform>();

        foreach (Transform child in childMousePosition)
        {
            if(child != mousePos)
            {
                mousePositions.Add(child.gameObject);
            }
        }

    }
    
    public GameObject RandomMouse()
    {
        float percent = 0;
        int selectNum = Mathf.RoundToInt(totals * Random.Range(0.01f, 1f));

        for (int i = 0; i < mouseObject.Count; i++)
        {
            PrefabData status = mouseObject[i].GetComponent<Mouse>().status;

            if (status != null)
            {
                percent += status.percentage;

                if (selectNum <= percent)
                {
                    return Instantiate(mouseObject[i]);
                }
            }
        }
        return null;
    }

    public void ResultSelect()
    {
        if (GameManager.instance.gachaNum < 1) return;

        GameManager.instance.gachaNum--;
        UIManager.instance.gatchaNumText.text = string.Format("»Ì±â: {0}", GameManager.instance.gachaNum);

        if (isFirst)
        {
            firstWave.Spawn();
            isFirst = false;
        }

        GameObject selectedMouse = RandomMouse();

        if (selectedMouse != null)
        {
            mouseResults.Add(selectedMouse);

            for (int i = 0; i < childMousePosition.Length; i++)
            {
                if (childMousePosition[i].childCount == 0)
                {
                    selectedMouse.transform.SetParent(childMousePosition[i].transform);
                    selectedMouse.transform.localPosition = Vector3.zero;
                    break;
                }

            }
            
            if(mouseResults.Count>=36)
            {
                UIManager.instance.gachaBtn.enabled = false;
            }
        }
        else
        {
            return;
        }
    }
}
