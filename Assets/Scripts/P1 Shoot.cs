using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P1Shoot : MonoBehaviour
{
    [SerializeField] GameObject player1Bullet;
    [SerializeField] private Transform bulletSpawnPoint;
    private float bulletSpeed = 10.0f;

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            GameObject bullet = Instantiate(player1Bullet, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
            bullet.GetComponent<Rigidbody>().AddForce(bulletSpawnPoint.forward * bulletSpeed, ForceMode.Impulse);

            //player1Bullet = Instantiate(player1Bullet) as GameObject;
            //player1Bullet.transform.position = transform.TransformPoint(Vector3.forward * bulletSpeed);
            //player1Bullet.transform.rotation = transform.rotation;
        }
    }
}
