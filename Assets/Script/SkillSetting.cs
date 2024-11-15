using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class SkillData
{
    public string ID;
    public string Name;
    public int Attack;
    public int MaxNum;
}

[CreateAssetMenu(fileName = "SkillSetting", menuName = "Scriptable Objects/SkillSetting")]
public class SkillSetting : ScriptableObject
{
    public List<SkillData> DataList;
}
