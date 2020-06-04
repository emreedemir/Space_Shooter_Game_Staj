using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipSpawner : Singleton<ShipSpawner>
{
    #region Spawn Points
    public Transform enemySpawnPoint;
    public Transform fellowSpawnPoint;
    #endregion

    #region Enemy Prefabs
    public SpaceShip[] enemyShipNormal;
    public SpaceShip enemyShipBoss;
    #endregion

    #region Fellow Prefabs
    public SpaceShip heroShip;
    #endregion

    #region Constant
    public const int ENEMY_COUNT = 50;
    #endregion

    [SerializeField]
    public Queue<SpaceShip> enemyQueue { get; set; }

    public enum ShipType
    {
        Fellow,
        Enemy
    }

    protected override void Awake()
    {
        base.Awake();
        enemyQueue = new Queue<SpaceShip>();
    }

    public void CreateEnemyQueue()
    {
        for (int i = 1; i <= ENEMY_COUNT; i++)
        {
            if (i != ENEMY_COUNT)
            {
                int rnd = Random.Range(0, 2);
                SpaceShip enemyShip = Instantiate(enemyShipNormal[rnd]);
                enemyQueue.Enqueue(enemyShip);
            }
            else
            {
                SpaceShip enemyShip = Instantiate(enemyShipBoss);
                enemyQueue.Enqueue(enemyShip);
            }
        }
    }

    public void SpawnShip(ShipType shipType)
    {
        if (enemyQueue.Count > 0)
        {
            if (shipType == ShipType.Enemy)
            {
                SpaceShip enemyShip = enemyQueue.Dequeue();
                enemyShip.transform.position = enemySpawnPoint.position;
                enemyShip.gameObject.SetActive(true);
                enemyShip.InitiliazeShip();
            }
            else if (shipType == ShipType.Fellow)
            {
                SpaceShip fellowShip = Instantiate(heroShip);
                fellowShip.gameObject.transform.position = fellowSpawnPoint.position;
                fellowShip.gameObject.SetActive(true);
                fellowShip.InitiliazeShip();
            }
        }
    }
}
