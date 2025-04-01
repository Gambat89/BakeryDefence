using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    public Image[] highLights;              // State UI �������� ���̶���Ʈ
    public Image stageGauge;                // �������� �ð� ������

    public TextMeshProUGUI stageText;       // ���� �������� ǥ�� �ؽ�Ʈ
    public TextMeshProUGUI[] mouseNumTexts; // ���� ���� �� ���� ���� �ؽ�Ʈ
    public TextMeshProUGUI gatchaNumText;   // ���� �̱� ���� �ؽ�Ʈ
    public TextMeshProUGUI cleanText;   // ���� �̱� ���� �ؽ�Ʈ

    public Button gachaBtn;                 // �̱� ��ư

    private void Awake()
    {
        instance = this;
    }

    // ��ư ���콺 ������ ���� ũ�� Ŀ�����ϴ� �Լ�
    public void ChangeScale(float size)
    {
        gachaBtn.GetComponent<RectTransform>().localScale = Vector3.one * size;
    }

    // �ش� Wave ���̶���Ʈ
    public void Highlight(int waveNum)
    {
        foreach (Image highlight in highLights)
        {
            highlight.gameObject.SetActive(false);
        }
        highLights[waveNum].gameObject.SetActive(true);
    }
}
