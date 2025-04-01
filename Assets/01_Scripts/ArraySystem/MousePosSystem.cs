using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MousePosSystem : MonoBehaviour
{
    void Start()
    {
        InitMousePos();
    }

    void InitMousePos()
    {
        int posNum = 1;
        int mouseLine = 6;

        Vector2 firstPos = new Vector2(0, 3.35f);
        Vector2 modiPos = new Vector2(1, 0.575f);
        Vector2 nextPos = new Vector2(1, -0.575f);

       
        for (int i = 0; i < mouseLine; i++)
        {
            for (int j = 0; j < mouseLine; j++)
            {
                GameObject mousePos = new GameObject(string.Format("MousePos{0}", posNum));
                mousePos.transform.position = firstPos - modiPos * j;
                mousePos.transform.parent = this.transform;
                posNum += 1;
            }
            firstPos += nextPos;
        }

    }
}
