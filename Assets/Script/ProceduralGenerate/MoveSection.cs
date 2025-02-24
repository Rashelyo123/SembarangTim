using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSection : MonoBehaviour
{

    public float Speed = -7;
    void Update()
    {
        transform.position += new Vector3(0, 0, Speed) * Time.deltaTime;
    }
}
