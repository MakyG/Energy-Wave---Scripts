using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapeHP : MonoBehaviour
{
    public float size;

    // Update is called once per frame
    void Update()
    {
        size = HealthBar.currentHealth2 / 100;
        transform.localScale = new Vector3(size, size, size);
    }
}
