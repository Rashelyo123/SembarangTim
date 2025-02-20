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
            GameObject bullet = Instantiate(bulletPrefab, transform.position + transform.forward, Quaternion.identity);
            Rigidbody rb = bullet.GetComponent<Rigidbody>();

            if (rb != null)
            {
                rb.velocity = transform.forward * 10f;
            }
            Destroy(bullet, 2f);

            yield return new WaitForSeconds(fireRate);
        }
    }

}
