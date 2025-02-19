using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    private GameObject bulletPrefab;
    private float fireRate;
    private bool IsShooting = false;

    public void StartShooting(GameObject bullet, float rate)
    {
        bulletPrefab = bullet;
        fireRate = rate;
        IsShooting = true;
        StartCoroutine(Shoot());


    }

    public void StopShooting()
    {
        IsShooting = false;
    }
    private IEnumerator Shoot()
    {
        while (IsShooting)
        {
            Instantiate(bulletPrefab, transform.position + Vector3.forward, Quaternion.identity);
            yield return new WaitForSeconds(fireRate);
        }
    }
}
