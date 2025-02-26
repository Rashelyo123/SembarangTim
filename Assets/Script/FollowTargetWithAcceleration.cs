using UnityEngine;

public class SuckedIntoBlackHole : MonoBehaviour
{
    public Transform blackHole;
    public float maxSpeed = 10f;
    public float acceleration = 5f;
    public float spiralStrength = 2f;
    public float destroyDistance = 0.2f;
    public float activationRadius = 10f; // Radius Black Hole

    private float currentSpeed = 0f;

    void Update()
    {
        if (blackHole == null) return;

        float distance = Vector3.Distance(transform.position, blackHole.position);

        if (distance > activationRadius)
        {
            return;
        }

        if (distance <= destroyDistance)
        {
            // Cek apakah Item ada di objek ini
            Item item = GetComponent<Item>();
            if (item != null && GameManager.instance != null)
            {

                GameManager.instance.AddEfficiency(item.itemData.efficiencyValue);
            }
            else
            {
                Debug.LogWarning("Item atau GameManager.instance tidak ditemukan!");
            }

            Destroy(gameObject);
            return;
        }

        // Pergerakan ke black hole
        Vector3 direction = (blackHole.position - transform.position).normalized;
        Vector3 spiralEffect = Vector3.Cross(direction, Vector3.up) * spiralStrength;

        currentSpeed = Mathf.MoveTowards(currentSpeed, maxSpeed, acceleration * Time.deltaTime);
        transform.position += (direction + spiralEffect) * currentSpeed * Time.deltaTime;
        transform.Rotate(Vector3.forward, currentSpeed * 50f * Time.deltaTime);
    }

    void OnDrawGizmos()
    {
        if (blackHole != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(blackHole.position, activationRadius);
        }
    }
}
