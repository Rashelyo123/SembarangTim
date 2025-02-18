using UnityEngine;

public class BlackHole : MonoBehaviour
{
    public Transform target;   // Target yang akan diikuti
    public float maxSpeed = 5f; // Kecepatan maksimum
    public float acceleration = 2f; // Laju percepatan
    public float destroyDistance = 0.5f; // Jarak minimal sebelum dihancurkan

    private float currentSpeed = 0f; // Kecepatan awal

    void Update()
    {
        if (target != null)
        {
            // Hitung arah menuju target
            Vector3 direction = (target.position - transform.position).normalized;

            // Tingkatkan kecepatan secara bertahap
            currentSpeed = Mathf.MoveTowards(currentSpeed, maxSpeed, acceleration * Time.deltaTime);

            // Pindahkan GameObject dengan kecepatan yang meningkat
            transform.position += direction * currentSpeed * Time.deltaTime;

            // Cek jika sudah cukup dekat dengan target
            if (Vector3.Distance(transform.position, target.position) <= destroyDistance)
            {
                Destroy(gameObject); // Hancurkan BlackHole
            }
        }
    }
}
