using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField]
    private List<Enemy> enemies;

    public void ActivateEnemies()
    {
        enemies.ForEach(enemy =>
        {
            enemy.StartDelay();
        });
    }
}