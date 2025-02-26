using UnityEngine;

public class BlackHole : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // Periksa apakah objek yang masuk memiliki skrip SuckedIntoBlackHole
        SuckedIntoBlackHole suckedScript = other.GetComponent<SuckedIntoBlackHole>();

        if (suckedScript != null)
        {
            suckedScript.enabled = true; // Aktifkan skrip saat memasuki trigger
        }
    }
}
