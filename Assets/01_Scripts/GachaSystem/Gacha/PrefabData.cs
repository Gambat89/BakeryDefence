using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Mouse", menuName = "Scriptable Object/Mouse", order = int.MaxValue)]

public class PrefabData : ScriptableObject
{
    public float attackPower;
    public float attackSpeed;
    public float attackDistance;
    public float percentage;
    public float targetCount;

    private PrefabData prefabData;

    public PrefabData(PrefabData prefabData)
    {
        this.prefabData = prefabData;
    }
}
