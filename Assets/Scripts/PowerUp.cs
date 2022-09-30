using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    Rigidbody _rb;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // calculate rotation
        Quaternion turnOffset = Quaternion.Euler(1, 1, 1);
        _rb.MoveRotation(_rb.rotation * turnOffset);
    }
}
