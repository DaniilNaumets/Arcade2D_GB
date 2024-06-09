using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Stage", menuName = "Stage/StageConfig")]
public class StageConfig : ScriptableObject
{
    [SerializeField] private int[] _enemyTypes;

    public int[] GetEnemiesTypes() => _enemyTypes;
}
