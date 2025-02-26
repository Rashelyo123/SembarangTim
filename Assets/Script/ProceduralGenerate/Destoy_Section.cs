using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destoy_Section : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("DestroySection"))
        {
            Destroy(gameObject);

        }
    }
}
