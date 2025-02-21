using UnityEngine;

public class BlackHole : MonoBehaviour
{
    public float radius = 5f;
    public float pullSpeed = 5f;

    private void OnTriggerEnter(Collider other)
    {
        Item item = other.GetComponent<Item>();
        if (item != null)
        {

            GameManager.instance.AddEfficiency(item.itemData.efficiencyValue);
            Destroy(other.gameObject);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
