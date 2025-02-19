using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp_Shield : PowerUpBase
{
    public GameObject shieldPrefab;
    public override void Activate(GameObject player)
    {
        GameObject shield = Instantiate(shieldPrefab, player.transform);
        Destroy(shield, duration);
    }
}
