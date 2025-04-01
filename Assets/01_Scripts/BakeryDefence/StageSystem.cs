using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageSystem : MonoBehaviour
{
    Wave[ , ] waves = new Wave[5,6];    // ��� �������� Wave

    public GameObject[] stageObjects;   // �������� ���ӿ�����Ʈ

    float waveGauge;         // Wave���� �帥 �ð�

    int stageIndex = 0;      // Stage ���� �ε���
    int waveIndex = 0;       // Wave ���� �ε���

    int nomalTime = 72;      // �Ϲ� �������� ���ѽð�
    int bossTime = 120;      // ���� �������� ���ѽð�

    private void Start()
    {
        StageInit();
        waves[stageIndex,waveIndex].gameObject.SetActive(true);

        StartCoroutine(CheckWin());
    }

    // Wave �迭�� Stage ������Ʈ�� �ʱ�ȭ
    void StageInit()
    {
        // Stage ������Ʈ�鿡�� �ϳ��� ������
        foreach (GameObject stage in stageObjects)
        {
            // Stage ������Ʈ���� Wave ������
            foreach (Wave wave in stage.GetComponentsInChildren<Wave>())
            {
                // Wave �迭�� �ϳ��� �ʱ�ȭ
                waves[stageIndex, waveIndex] = wave;
                waveIndex++;
                
            }
            waveIndex = 0;
            stageIndex++;
        }
        waveIndex = 0;
        stageIndex = 0;
        
    }

    // ���� Wave�� �Ѿ�� �Լ�
    void NextWave()
    {
        if (GameManager.instance.waveDone) waveGauge = 1;

        // ���� Wave���
        if (waveIndex == 5)
        {
            // ������ Stage�� �ƴϰ� ���� ���ѽð� ������ ���� Stage��
            if (waveGauge >= 1 && stageIndex != 4)
            {
                waveGauge = 0;

                waveIndex = 0;
                stageIndex++;

                GameManager.instance.gachaNum++;
                UIManager.instance.gatchaNumText.text = string.Format("�̱�: {0}", GameManager.instance.gachaNum);

                waves[stageIndex, waveIndex].Spawn();

                UIManager.instance.Highlight(waveIndex);
                GameManager.instance.roundNum++;
            }
            // ���������� ������ ����
            else
            {
                waveGauge += Time.deltaTime / bossTime;
            }
        }
        // �Ϲ� �����������
        else
        {
            // �Ϲ� ���ѽð� ������ ���� ����������
            if (waveGauge >= 1)
            {
                waveGauge = 0;

                waveIndex++;

                GameManager.instance.gachaNum++;
                UIManager.instance.gatchaNumText.text = string.Format("�̱�: {0}", GameManager.instance.gachaNum);

                waves[stageIndex, waveIndex].Spawn();

                UIManager.instance.Highlight(waveIndex);
                GameManager.instance.roundNum++;
            }
            // ���������� ������ ����
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
