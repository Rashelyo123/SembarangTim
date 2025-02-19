using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    private void OggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PowerUpBase powerUp = other.GetComponent<PowerUpBase>();
            if (powerUp != null)
            {
                powerUp.Activate(other.gameObject);
                Destroy(gameObject); // Destroy
            }
        }
    }
}
