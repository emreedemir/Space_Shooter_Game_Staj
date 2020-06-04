using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    protected override void Awake()
    {
        base.Awake();
    }

    private void Start()
    {
        BulletPool.Instance.CreatePool();
        Menu.Instance.InitiliazaMenu();
        Menu.Instance.MainMenuActivate(true);
    }

    public void SetGame()
    {
        ShipSpawner.Instance.CreateEnemyQueue();
        ShipSpawner.Instance.SpawnShip(ShipSpawner.ShipType.Fellow);
        ShipSpawner.Instance.SpawnShip(ShipSpawner.ShipType.Enemy);
        Menu.Instance.MainMenuActivate(false);
        Menu.Instance.GameUIActivate(true);
    }

    public void FinishGame()
    {
        EnemyShip[] enemyShips = FindObjectsOfType<EnemyShip>();

        ShipSpawner.Instance.enemyQueue.Clear();

        if (enemyShips.Length > 0)
        {
            for (int i = 0; i < enemyShips.Length; i++)
            {
                Destroy(enemyShips[i]);
            }
        }
        FellowShip ship = FindObjectOfType<FellowShip>();
        if (ship != null)
        {
            Destroy(ship.gameObject, 0);
        }
        Menu.Instance.GameUIActivate(false);
        Menu.Instance.MainMenuActivate(true);
    }

    public void KillFellow(SpaceShip fellowShip)
    {
        FinishGame();
        Destroy(fellowShip.gameObject, 0);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
