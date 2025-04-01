using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragSystem : MonoBehaviour
{
    Vector3 mousePos;           // ���콺 Ŀ�� ��ġ

    GameObject dragObject;      // Ŀ���� ���� ��
    Transform nearPos;          // ���� ���� ���� ����� ��ġ

    public GameObject mousePositions;       // MousePosSystem
    public GameObject posCircle;            // �� ����� �� ��ġ �����ִ� ��
    public GameObject posLine;              // ��� ����

    void Update()
    {
        // Ŀ���� �� ���
        Drag(); 
    }

    // ���콺 Ŀ�� Ŭ������ �� ���
    private void Drag()
    {
        // Ŭ������ ��
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

        // �� ����� ��
        if (dragObject)
        {
            // ��ġ ǥ�� ���� ���� Ȱ��ȭ
            posCircle.SetActive(true);
            posLine.SetActive(true);

            // ���� �� ������Ʈ ��ġ ����(Ŀ�� ���󰡰�, ���� z�� �°�)
            dragObject.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + Vector3.forward * 10;

            // ���� ����� ���� ��ġ ã��
            // ��� MousePos�� �Ÿ� �� �� ���� ª�� �㰡 ���� ��ġ�� ����
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

        // ���콺 Ŭ�� ����
        if (Input.GetMouseButtonUp(0) && dragObject)
        {
            // ���� ����� ���� ��ġ ã��
            // ��� MousePos�� �Ÿ� �� �� ���� ª�� �㰡 ���� ��ġ�� ����
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

            // ��ġ ǥ�� ���� ���� ��Ȱ��ȭ
            posCircle.SetActive(false);
            posLine.SetActive(false);

            // Ŭ���ߴ� �� ��ġ ���� 
            if (nearPos.childCount != 0)
            {
                ArrayMouse(nearPos.GetChild(0).gameObject, dragObject.transform.parent);
            }
            ArrayMouse(dragObject, nearPos);

            dragObject = null;
        }
    }

    /// <summary>
    /// �� �����ϴ� �Լ�
    /// </summary>
    /// <param name="mouse">Ŀ���� ���� ��</param>
    /// <param name="parent">��ġ�� ��ġ ������Ʈ</param>
    void ArrayMouse(GameObject mouse, Transform parent)
    {
        mouse.transform.SetParent(parent);
        mouse.transform.localPosition = Vector3.zero;
    }
}
