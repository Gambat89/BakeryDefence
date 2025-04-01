using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageSystem : MonoBehaviour
{
    Wave[ , ] waves = new Wave[5,6];    // 모든 스테이지 Wave

    public GameObject[] stageObjects;   // 스테이지 게임오브젝트

    float waveGauge;         // Wave에서 흐른 시간

    int stageIndex = 0;      // Stage 순서 인덱스
    int waveIndex = 0;       // Wave 순서 인덱스

    int nomalTime = 72;      // 일반 스테이지 제한시간
    int bossTime = 120;      // 보스 스테이지 제한시간

    private void Start()
    {
        StageInit();
        waves[stageIndex,waveIndex].gameObject.SetActive(true);

        StartCoroutine(CheckWin());
    }

    // Wave 배열에 Stage 오브젝트들 초기화
    void StageInit()
    {
        // Stage 오브젝트들에서 하나씩 가져옴
        foreach (GameObject stage in stageObjects)
        {
            // Stage 오브젝트에서 Wave 가져옴
            foreach (Wave wave in stage.GetComponentsInChildren<Wave>())
            {
                // Wave 배열에 하나씩 초기화
                waves[stageIndex, waveIndex] = wave;
                waveIndex++;
                
            }
            waveIndex = 0;
            stageIndex++;
        }
        waveIndex = 0;
        stageIndex = 0;
        
    }

    // 다음 Wave로 넘어가는 함수
    void NextWave()
    {
        if (GameManager.instance.waveDone) waveGauge = 1;

        // 보스 Wave라면
        if (waveIndex == 5)
        {
            // 마지막 Stage가 아니고 보스 제한시간 지나면 다음 Stage로
            if (waveGauge >= 1 && stageIndex != 4)
            {
                waveGauge = 0;

                waveIndex = 0;
                stageIndex++;

                GameManager.instance.gachaNum++;
                UIManager.instance.gatchaNumText.text = string.Format("뽑기: {0}", GameManager.instance.gachaNum);

                waves[stageIndex, waveIndex].Spawn();

                UIManager.instance.Highlight(waveIndex);
                GameManager.instance.roundNum++;
            }
            // 안지났으면 게이지 증가
            else
            {
                waveGauge += Time.deltaTime / bossTime;
            }
        }
        // 일반 스테이지라면
        else
        {
            // 일반 제한시간 지나면 다음 스테이지로
            if (waveGauge >= 1)
            {
                waveGauge = 0;

                waveIndex++;

                GameManager.instance.gachaNum++;
                UIManager.instance.gatchaNumText.text = string.Format("뽑기: {0}", GameManager.instance.gachaNum);

                waves[stageIndex, waveIndex].Spawn();

                UIManager.instance.Highlight(waveIndex);
                GameManager.instance.roundNum++;
            }
            // 안지났으면 게이지 증가
            else
            {
                waveGauge += Time.deltaTime / nomalTime;
            }
        }

        UIManager.instance.stageGauge.fillAmount = waveGauge;
    }

    IEnumerator CheckWin()
    {
        while (stageIndex != 5)
        {
            NextWave();
            yield return null;
        }

        GameManager.instance.GameWin();
    }
}
