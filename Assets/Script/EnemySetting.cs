using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class EnemyData
{
    public string ID;
    public int HP;
    public int Attack;
}

[CreateAssetMenu(menuName = "Scriptable Objects/Enemy Setting", fileName = "EnemySetting")]
public class EnemySetting : ScriptableObject
{
    public List<EnemyData> DataList;

    public EnemyData GetEnemy(string EnemyID)
    {
        return DataList.Find(enemy => enemy.ID == EnemyID);
    }
}