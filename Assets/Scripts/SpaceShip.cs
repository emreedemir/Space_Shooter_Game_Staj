using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class SpaceShip : MonoBehaviour
{
    public int Health;

    [Range(10, 30)]
    public float bulletSpeed;

    public float shipSpeed;

    public Action OnCollision;

    public Action<SpaceShip> OnDead;

    public abstract void InitiliazeShip();

    public abstract void Shoot();

    public abstract void TakeDamage();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (OnCollision != null)
        {
            OnCollision.Invoke();
        }
    }
}
