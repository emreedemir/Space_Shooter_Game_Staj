using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletPool : Singleton<BulletPool>
{
    public const int BulletCount = 40;
    public Bullet EnemyBullet;
    public Bullet FellowBullet;

    List<Bullet> FellowBullets = new List<Bullet>();
    List<Bullet> EnemyBullets = new List<Bullet>();

    public enum BulletType
    {
        FellowBullet,
        EnemyBullet
    }

    protected override void Awake()
    {
        base.Awake();
    }

    public void CreatePool()
    {
        for (int i = 0; i < BulletCount; i++)
        {
            Bullet fellowBullet = Instantiate(FellowBullet);
            fellowBullet.BulletType = BulletType.FellowBullet;
            fellowBullet.gameObject.transform.SetParent(this.transform, true);
            FellowBullets.Add(fellowBullet);
        }

        for (int j = 0; j < BulletCount; j++)
        {
            Bullet enemyBullet = Instantiate(EnemyBullet);
            enemyBullet.BulletType = BulletType.EnemyBullet;
            enemyBullet.gameObject.transform.SetParent(this.transform, true);
            EnemyBullets.Add(enemyBullet);
        }
    }

    public Bullet GetBullet(BulletType type)
    {
        if (type == BulletType.FellowBullet)
        {
            if (FellowBullets.Count > 0)
            {
                Bullet bullet = FellowBullets[0];
                FellowBullets.RemoveAt(0);
                return bullet;
            }
        }
        else if (type == BulletType.EnemyBullet)
        {
            if (EnemyBullets.Count > 0)
            {
                Bullet bullet = EnemyBullets[0];
                EnemyBullets.RemoveAt(0);
                return bullet;
            }
        }
        return null;
    }

    public void AddBulletToPool(Bullet bullet)
    {
        if (bullet.BulletType == BulletType.FellowBullet)
        {
            bullet.gameObject.SetActive(false);
            bullet.gameObject.transform.position = this.transform.position;
            bullet.transform.SetParent(this.transform, true);
            FellowBullets.Add(bullet);
        }
        else if (bullet.BulletType == BulletType.EnemyBullet)
        {
            bullet.gameObject.SetActive(false);
            bullet.gameObject.transform.position = this.transform.position;
            bullet.transform.SetParent(this.transform, true);
            EnemyBullets.Add(bullet);
        }
    }
}
