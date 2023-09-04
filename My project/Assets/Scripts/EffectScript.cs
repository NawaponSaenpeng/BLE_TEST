using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectScript : MonoBehaviour
{
    public float lifetime = 0.25f;

    void Update()
    {
        Destroy(gameObject, lifetime);
    }
}
