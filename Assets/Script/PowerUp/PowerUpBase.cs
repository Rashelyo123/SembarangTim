using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PowerUpBase : MonoBehaviour
{
    public float duration = 5f;
    public abstract void Activate(GameObject player);
}
