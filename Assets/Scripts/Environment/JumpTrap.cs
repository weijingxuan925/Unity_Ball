using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpTrap : MonoBehaviour
{
    [SerializeField]
    private float _addForce = 50f;
    //当小球进入跳台时，给小球添加一个向上的力
    private void OnTriggerEnter(Collider other)
    {
        other.GetComponent<Rigidbody>().AddForce(Vector3.up * _addForce,ForceMode.Impulse);
    }
}
