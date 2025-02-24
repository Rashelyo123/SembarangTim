using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destoy_Section : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Destroy Section");
        if (other.gameObject.CompareTag("DestroySection"))
        {
            Destroy(gameObject);
            Debug.Log("Destroy Section");
        }
    }
}
