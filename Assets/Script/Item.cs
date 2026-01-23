using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public ItemData itemData;
    public GameObject destroyEffectPrefab; // Prefab efek hancur

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Shield"))
        {

            Destroy(gameObject);
            Debug.Log("Item destroyed by shield!");
            AudioEventSystem.PlayAudio("DestroyObject"); // ✅ Pastikan AudioEventSystem sudah diatur dengan benar
            GameObject effect = Instantiate(destroyEffectPrefab, transform.position, Quaternion.identity);
            Destroy(effect, 0.5f); // ✅ Hancurkan hasil instansi, bukan prefab-nya

        }

    }
}
