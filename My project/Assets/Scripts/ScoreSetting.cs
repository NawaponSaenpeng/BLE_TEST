using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ScoreSetting", menuName = "My project/ScoreSetting", order = 0)]
public class ScoreSetting : ScriptableObject 
{
    public int badScore;
    public int goodScore;
    public int perfectScore;
    public int missScore;
}
