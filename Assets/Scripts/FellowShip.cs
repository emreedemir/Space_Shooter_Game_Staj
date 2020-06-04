using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FellowShip : SpaceShip, IController
{
    #region MovementClamp
    Vector2 maxClamp;
    Vector2 minClamp;
    #endregion

    public override void InitiliazeShip()
    {
        base.OnDead += GameManager.Instance.KillFellow;
        OnCollision += TakeDamage;
        Camera cam = FindObjectOfType<Camera>();
        float camHeight = 2 * cam.orthographicSize;
        float camWidth = camHeight + cam.aspect;
        maxClamp = new Vector2(camWidth / 4, camHeight / 3f);
        minClamp = new Vector2(-camWidth / 4, -camHeight / 2.5f);
    }

    public void MoveControl()
    {
        if (Input.GetAxis("Horizontal") > 0)
        {
            if (transform.position.x < maxClamp.x)
            {
                transform.position += new Vector3(Input.GetAxis("Horizontal") * shipSpeed / 80, 0, 0);
            }
        }
        else if (Input.GetAxis("Horizontal") < 0)
        {
            if (transform.position.x > minClamp.x)
            {
                transform.position += new Vector3(Input.GetAxis("Horizontal") * shipSpeed / 80, 0, 0);
            }
        }

        if (Input.GetAxis("Vertical") > 0)
        {
            if (transform.position.y < maxClamp.y)
            {
                this.transform.position += new Vector3(0, Input.GetAxis("Vertical") * shipSpeed / 80, 0);
            }
        }
        else if (Input.GetAxis("Vertical") < 0)
        {
            if (transform.position.y > minClamp.y)
            {
                this.transform.position += new Vector3(0, Input.GetAxis("Vertical") * shipSpeed / 80, 0);
            }
        }
    }

    public void ShootControl()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }

    void Update()
    {
        MoveControl();
        ShootControl();
    }

    public override void TakeDamage()
    {
        if (base.Health > 0)
        {
            Health--;
        }
        if (Health < 1)
        {
            if (OnDead != null)
            {
                OnDead.Invoke(this);
            }
        }
    }

    public override void Shoot()
    {
        Bullet bullet = BulletPool.Instance.GetBullet(BulletPool.BulletType.FellowBullet);
        bullet.transform.position = this.transform.position + new Vector3(0, 1, 0);
        bullet.gameObject.SetActive(true);
        bullet.transform.SetParent(null, true);
    }
}
