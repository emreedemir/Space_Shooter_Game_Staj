using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyShip : SpaceShip
{
    FellowShip target;
    float deltaTime = 0;
    public override void InitiliazeShip()
    {
        base.OnDead += EnemyController.Instance.DestroyEnemy;
        OnCollision += TakeDamage;
        target = FindObjectOfType<FellowShip>();
    }

    private void Update()
    {
        deltaTime += Time.deltaTime;

        if (target != null)
        {
            transform.position = Vector3.Lerp(transform.position, target.transform.position, 0.5f * Time.deltaTime);

            if (deltaTime > 0.6f)
            {
                deltaTime = 0;
                Shoot();
            }
        }
    }

    public override void Shoot()
    {
        Bullet bullet = BulletPool.Instance.GetBullet(BulletPool.BulletType.EnemyBullet);
        bullet.gameObject.transform.position = this.transform.position + new Vector3(0, -1, 0);
        bullet.gameObject.SetActive(true);
        bullet.transform.SetParent(null, true);
    }

    public override void TakeDamage()
    {
        if (base.Health > 0)
        {
            base.Health--;
        }
        if (Health < 1)
        {
            if (OnDead != null)
            {
                OnDead.Invoke(this);
            }
        }
    }
}
