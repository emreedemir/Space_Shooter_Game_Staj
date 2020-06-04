using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : Singleton<EnemyController>
{
    protected override void Awake()
    {
        base.Awake();
    }

    public void DestroyEnemy(SpaceShip enemyship)
    {
        //Add there dead partical
        Destroy(enemyship.gameObject);
        StartCoroutine(EnemySpawnCoroutine());
    }

    IEnumerator EnemySpawnCoroutine()
    {
        ShipSpawner.Instance.SpawnShip(ShipSpawner.ShipType.Enemy);
        yield return new WaitForSeconds(0.2f);
    }
}
