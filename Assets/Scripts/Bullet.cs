using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public BulletPool.BulletType BulletType { get; set; }

    int direction = 0;

    [Range(6, 22)]
    public float bulletSpeed;

    private void Start()
    {

    }

    private void OnEnable()
    {
        if (BulletType == BulletPool.BulletType.EnemyBullet)
        {
            direction = -1;
        }
        else
        {
            direction = 1;
        }
        StartCoroutine(BulletCoroutine());
    }

    private IEnumerator BulletCoroutine()
    {

        Vector3 firstPosition = this.gameObject.transform.position;

        while (Mathf.Abs(firstPosition.y - this.gameObject.transform.position.y) < 20)
        {
            this.transform.position += new Vector3(0, 1, 0) * Time.deltaTime * bulletSpeed * direction;
            yield return new WaitForSeconds(0.0f);
        }
        BulletPool.Instance.AddBulletToPool(this);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        BulletPool.Instance.AddBulletToPool(this);
    }
}
