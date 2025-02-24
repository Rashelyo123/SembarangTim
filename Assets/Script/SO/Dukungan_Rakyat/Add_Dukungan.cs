using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Add_Dukungan : MonoBehaviour
{
    public Dukungan_Data dukunganData;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (dukunganData != null)
            {
                GameManager.instance.AddDukunganRakyat(dukunganData.dukunganValue);
                Destroy(gameObject);
            }
            else
            {
                Debug.LogError("Dukungan Data is null");
            }
        }
    }
}
