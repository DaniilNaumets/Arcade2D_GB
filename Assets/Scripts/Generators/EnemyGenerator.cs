using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    [SerializeField] private StageConfig[] _stages;

    [SerializeField] private GameObject[] _enemiesPrefabs;

    private int _activeEnemies;
    private int _currentStage;

    private Vector2 _min;
    private Vector2 _max;

    public enum Enemies
    {
        A, B, C, Boss
    }

    private void Awake()
    {
        _min = Camera.main.ViewportToWorldPoint(Vector2.zero);
        _max = Camera.main.ViewportToWorldPoint(Vector2.one);
    }

    private void OnEnable()
    {
        Enemy.OnEnemyDestroyed += EnemyDestroying;
    }

    private void OnDisable()
    {
        Enemy.OnEnemyDestroyed -= EnemyDestroying;
    }

    private void Start()
    {
        StartCoroutine(StartStage(_currentStage));
    }

    private void EnemyDestroying()
    {
        _activeEnemies--;
        if(_activeEnemies <= 0)
        {
            _currentStage++;
            if(_currentStage < _stages.Length)
            {
                StartCoroutine(StartStage(_currentStage));
            }
        }
    }

    private IEnumerator StartStage(int curStage)
    {
        StageConfig stage = _stages[curStage];
        foreach(int enemyType in stage.GetEnemiesTypes())
        {
            Spawn(enemyType);
            yield return new WaitForSeconds(Random.Range(0.3f,1.2f));
        }
    }

    [ContextMenu("spawnEnemy")]
    private void Spawn(int num)
    {
        GameObject newEnemy = Instantiate(ConvertEnemyToGameObject(num));
        if (num != 3)
            newEnemy.transform.position = new Vector2(_max.x, Random.Range(-6, 6));
        else
            newEnemy.transform.position = new Vector2(_max.x + 3, 0.5f);
        _activeEnemies++;
    }

    private GameObject ConvertEnemyToGameObject(int num)
    {
        for (int i = 0; i < _enemiesPrefabs.Length; i++)
        {
            if (i == num - 1)
                return _enemiesPrefabs[i];
        }
        return null;
    }
}
