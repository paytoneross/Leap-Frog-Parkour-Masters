using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P2Shoot : MonoBehaviour
{
    [SerializeField] GameObject player2Bullet;
    [SerializeField] private Transform bulletSpawnPoint;
    private float bulletSpeed = 10.0f;

    private void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            GameObject bullet = Instantiate(player2Bullet, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
            bullet.GetComponent<Rigidbody>().AddForce(bulletSpawnPoint.forward * bulletSpeed, ForceMode.Impulse);

            //player2Bullet = Instantiate(player2Bullet) as GameObject;
            //player2Bullet.transform.position = transform.TransformPoint(Vector3.forward * bulletSpeed);
            //player2Bullet.transform.rotation = transform.rotation;
        }
    }
}
