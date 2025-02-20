using UnityEngine;

public class SuckedIntoBlackHole : MonoBehaviour
{
    public Transform blackHole;   // Referensi ke black hole
    public float maxSpeed = 10f;  // Kecepatan maksimum
    public float acceleration = 5f; // Seberapa cepat objek tertarik
    public float spiralStrength = 2f; // Kekuatan spiral sebelum masuk
    public float destroyDistance = 0.2f; // Jarak untuk dihancurkan

    private float currentSpeed = 0f;

    void Update()
    {
        if (blackHole == null) return;

        // Hitung arah ke black hole
        Vector3 direction = (blackHole.position - transform.position).normalized;

        // Tambahkan efek spiral dengan gaya cross product
        Vector3 spiralEffect = Vector3.Cross(direction, Vector3.up) * spiralStrength;

        // Percepat objek semakin dekat ke black hole
        currentSpeed = Mathf.MoveTowards(currentSpeed, maxSpeed, acceleration * Time.deltaTime);

        // Gerakkan objek menuju black hole dengan sedikit efek spiral
        transform.position += (direction + spiralEffect) * currentSpeed * Time.deltaTime;

        // Putar objek untuk efek tersedot
        transform.Rotate(Vector3.forward, currentSpeed * 50f * Time.deltaTime);

        // Hancurkan objek jika sudah terlalu dekat
        if (Vector3.Distance(transform.position, blackHole.position) <= destroyDistance)
        {
            Destroy(gameObject);

        }
    }
}
