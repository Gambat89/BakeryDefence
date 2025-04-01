using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    public Image[] highLights;              // State UI 스테이지 하이라이트
    public Image stageGauge;                // 스테이지 시간 게이지

    public TextMeshProUGUI stageText;       // 현재 스테이지 표시 텍스트
    public TextMeshProUGUI[] mouseNumTexts; // 현재 보유 쥐 종류 개수 텍스트
    public TextMeshProUGUI gatchaNumText;   // 보유 뽑기 개수 텍스트
    public TextMeshProUGUI cleanText;   // 보유 뽑기 개수 텍스트

    public Button gachaBtn;                 // 뽑기 버튼

    private void Awake()
    {
        instance = this;
    }

    // 버튼 마우스 가까이 가면 크기 커지게하는 함수
    public void ChangeScale(float size)
    {
        gachaBtn.GetComponent<RectTransform>().localScale = Vector3.one * size;
    }

    // 해당 Wave 하이라이트
    public void Highlight(int waveNum)
    {
        foreach (Image highlight in highLights)
        {
            highlight.gameObject.SetActive(false);
        }
        highLights[waveNum].gameObject.SetActive(true);
    }
}
