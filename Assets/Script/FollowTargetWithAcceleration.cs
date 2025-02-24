using UnityEngine;

public class SuckedIntoBlackHole : MonoBehaviour
{
    public Transform blackHole;
    public float maxSpeed = 10f;
    public float acceleration = 5f;
    public float destroyDistance = 2.86f;
    public float activationRadius = 43.4f; // Radius Black Hole

    private float currentSpeed = 0f;

    void Start()
    {
        if (blackHole == null)
        {
            GameObject bh = GameObject.FindWithTag("BlackHole");
            if (bh != null)
            {
                blackHole = bh.transform;
            }
            else
            {
                Debug.LogError("Black Hole tidak ditemukan! Pastikan ada objek dengan tag 'BlackHole'");
            }
        }
    }

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

        currentSpeed = Mathf.MoveTowards(currentSpeed, maxSpeed, acceleration * Time.deltaTime);
        transform.position += direction * currentSpeed * Time.deltaTime;
        transform.Rotate(Vector3.forward, currentSpeed * 50f * Time.deltaTime);
    }

    void OnDrawGizmos()
    {
        if (blackHole != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(blackHole.position, activationRadius);
            Gizmos.color = Color.black;
            Gizmos.DrawWireSphere(blackHole.position, destroyDistance);
        }
    }
}
