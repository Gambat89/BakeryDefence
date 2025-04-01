using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int gachaNum = 1;    // �̱� Ƚ��
    public int roundNum = 0;

    public List<GameObject> ants = new List<GameObject>();  // ���� ���� Ant List
    public GameObject antsObject;

    public bool waveDone = false;   // Wave�� ������ ��

    public Image fadeOutImage;  // ���� ���� �� � ���ȭ��
    public Image winImage;      // �¸� �� �̹���
    public Image loseImage;     // �й� �� �̹���

    private void Awake()
    {
        instance = this;

        Application.targetFrameRate = 60;
    }

    // �¸� ȭ�� ǥ�� �Լ�
    public IEnumerator GameWin()
    {
        fadeOutImage.gameObject.SetActive(true);

        yield return new WaitForSecondsRealtime(2f);

        winImage.gameObject.SetActive(true);
    }

    // �й� ȭ�� ǥ�� �Լ�
    IEnumerator GameLose()
    {
        fadeOutImage.gameObject.SetActive(true);

        yield return new WaitForSecondsRealtime(2f);

        loseImage.gameObject.SetActive(true);
    }
}
