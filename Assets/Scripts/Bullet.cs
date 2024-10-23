using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Wall"))
        {
            Destroy(this.gameObject);
        }
        //else if (other.CompareTag("Player 1"))
        //{
        //    Destroy(this.gameObject);
        //}
    }
}
