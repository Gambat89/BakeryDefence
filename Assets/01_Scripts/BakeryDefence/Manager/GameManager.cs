using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int gachaNum = 1;    // 뽑기 횟수
    public int roundNum = 0;

    public List<GameObject> ants = new List<GameObject>();  // 현재 존재 Ant List
    public GameObject antsObject;

    public bool waveDone = false;   // Wave가 끝났는 지

    public Image fadeOutImage;  // 게임 오버 시 까만 배경화면
    public Image winImage;      // 승리 시 이미지
    public Image loseImage;     // 패배 시 이미지

    private void Awake()
    {
        instance = this;

        Application.targetFrameRate = 60;
    }

    // 승리 화면 표시 함수
    public IEnumerator GameWin()
    {
        fadeOutImage.gameObject.SetActive(true);

        yield return new WaitForSecondsRealtime(2f);

        winImage.gameObject.SetActive(true);
    }

    // 패배 화면 표시 함수
    IEnumerator GameLose()
    {
        fadeOutImage.gameObject.SetActive(true);

        yield return new WaitForSecondsRealtime(2f);

        loseImage.gameObject.SetActive(true);
    }
}
