using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpGun : PowerUpBase
{
    public GameObject bulletprefab;
    public float fireRate = 0.5f;
    private bool IsShooting = false;

    public override void Activate(GameObject player)
    {
        IsShooting = true;
        player.GetComponent<PlayerShooting>().StartShooting(bulletprefab, fireRate);
        player.GetComponent<PlayerController>().SpeedDodge += 2f; // opsional aja
        player.GetComponent<MonoBehaviour>().StartCoroutine(Deactivate(player));
    }

    private System.Collections.IEnumerator Deactivate(GameObject player)
    {
        yield return new WaitForSeconds(duration);
        IsShooting = false;
        player.GetComponent<PlayerShooting>().StopShooting();
        player.GetComponent<PlayerController>().SpeedDodge -= 2f; // opsional aja
    }
}
