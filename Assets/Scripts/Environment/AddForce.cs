using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AddForce : MonoBehaviour
{
    [SerializeField]
    private float _addForce = 200;
    [SerializeField]
    private bool IsRightAddSpeed = false;
    [SerializeField]
    private bool IsNegativeDirection = false;
    private Vector3 _direction;
    //碰到加速条加速
    private void OnTriggerEnter(Collider other)
    {
        if (IsRightAddSpeed)
        {
            if (IsNegativeDirection)
            {
                _direction = Vector3.left * _addForce;
            }
            else {
                _direction = Vector3.right * _addForce;
            }
        }
        else {
            if (IsNegativeDirection)
            {
                _direction = Vector3.back * _addForce;
            }
            else {
                _direction = Vector3.forward * _addForce;
            }
        }
        other.GetComponent<Rigidbody>().AddForce(_direction, ForceMode.Impulse);
    }
}
