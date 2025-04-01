using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragSystem : MonoBehaviour
{
    Vector3 mousePos;           // 마우스 커서 위치

    GameObject dragObject;      // 커서로 잡은 쥐
    Transform nearPos;          // 잡은 쥐의 가장 가까운 위치

    public GameObject mousePositions;       // MousePosSystem
    public GameObject posCircle;            // 쥐 잡았을 때 위치 보여주는 원
    public GameObject posLine;              // 배경 격자

    void Update()
    {
        // 커서로 쥐 잡기
        Drag(); 
    }

    // 마우스 커서 클릭으로 쥐 잡기
    private void Drag()
    {
        // 클릭했을 때
        if (Input.GetMouseButtonDown(0))
        {
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            RaycastHit2D hit = Physics2D.Raycast(mousePos, transform.forward, 15);

            if (hit && hit.transform.gameObject.CompareTag("Mouse"))
            {
                dragObject = hit.transform.gameObject;
                nearPos = dragObject.transform.parent;
            }
        }

        // 쥐 잡았을 때
        if (dragObject)
        {
            // 위치 표시 원과 격자 활성화
            posCircle.SetActive(true);
            posLine.SetActive(true);

            // 잡은 쥐 오브젝트 위치 조정(커서 따라가게, 배경과 z축 맞게)
            dragObject.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + Vector3.forward * 10;

            // 가장 가까운 배정 위치 찾기
            // 모든 MousePos와 거리 비교 후 가장 짧고 쥐가 없는 위치에 배정
            float minDis = 999999;

            foreach (Transform pos in mousePositions.GetComponentInChildren<Transform>())
            {
                float dis = Vector3.Distance(dragObject.transform.position, pos.position);

                if (dis < minDis)
                {
                    minDis = dis;
                    nearPos = pos;
                }
                posCircle.transform.position = nearPos.position + Vector3.down * 0.3f;
            }
        }

        // 마우스 클릭 뗄때
        if (Input.GetMouseButtonUp(0) && dragObject)
        {
            // 가장 가까운 배정 위치 찾기
            // 모든 MousePos와 거리 비교 후 가장 짧고 쥐가 없는 위치에 배정
            float minDis = 999999;

            foreach(Transform pos in mousePositions.GetComponentInChildren<Transform>())
            {
                float dis = Vector3.Distance(dragObject.transform.position, pos.position);

                if (dis < minDis)
                {
                    minDis = dis;
                    nearPos = pos;
                }
            }

            // 위치 표시 원과 격자 비활성화
            posCircle.SetActive(false);
            posLine.SetActive(false);

            // 클릭했던 쥐 위치 정렬 
            if (nearPos.childCount != 0)
            {
                ArrayMouse(nearPos.GetChild(0).gameObject, dragObject.transform.parent);
            }
            ArrayMouse(dragObject, nearPos);

            dragObject = null;
        }
    }

    /// <summary>
    /// 쥐 정렬하는 함수
    /// </summary>
    /// <param name="mouse">커서로 잡은 쥐</param>
    /// <param name="parent">배치할 위치 오브젝트</param>
    void ArrayMouse(GameObject mouse, Transform parent)
    {
        mouse.transform.SetParent(parent);
        mouse.transform.localPosition = Vector3.zero;
    }
}
