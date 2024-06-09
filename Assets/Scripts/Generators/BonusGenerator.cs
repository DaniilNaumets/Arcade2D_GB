using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusGenerator : MonoBehaviour
{
    [SerializeField] private GameObject[] _bonuses;
    
    private int _quoreCount;

    public void SpawnBonus()
    {
        for (int i = 0; i < _bonuses.Length; i++)
        {
            if(_quoreCount == i)
            {
                Instantiate(_bonuses[i], new Vector3(Random.Range(-10,6), Random.Range(-6,6), 0), transform.rotation);
                _quoreCount++;
                return;
            }
        }
        _quoreCount = 0;
        Instantiate(_bonuses[_quoreCount], new Vector3(Random.Range(-10, 6), Random.Range(-6, 6), 0), transform.rotation);
        _quoreCount++;
    }
}
