using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    Rigidbody _rb;
    [SerializeField] Collider _playerCollider;
    [SerializeField] TankController _player;
    [SerializeField] float coolDownSecondsPower = 0.1f;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

   
    void Update()
    {
        // calculate rotation
        Quaternion turnOffset = Quaternion.Euler(1, 1, 1);
        _rb.MoveRotation(_rb.rotation * turnOffset);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other == _playerCollider)
        {
            _player.PowerUp(coolDownSecondsPower);
            Destroy(gameObject);
        }
    }

}
