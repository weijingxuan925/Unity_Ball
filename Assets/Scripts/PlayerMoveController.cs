using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ProBuilder.Shapes;

public class PlayerMoveController : MonoBehaviour
{
    [SerializeField]
    private float _moveForce = 50.0f;
    [SerializeField]
    private float _rotationForce = 10.0f;

    private int spin;

    private Rigidbody _rb;

    private Vector3 _direction;
    private float _horizontal;
    private float _vertical;

    private bool brake = false;

    private Animator _anim;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //按着空格不继续给移动力
        brake = Input.GetKey(KeyCode.Space);
        //获取移动向量
        _direction = new Vector3(Input.GetAxis("Horizontal"),0,Input.GetAxis("Vertical"));
        //球的自身扭力
        spin = 0;
        if (Input.GetKey(KeyCode.Q)) {
            spin = 1;
        }
        if (Input.GetKey(KeyCode.E)) {
            spin = -1;
        }
        //给球添加扭力
        _rb.AddForce(Vector3.forward * _moveForce * Time.deltaTime, ForceMode.Force);
    }
    private void FixedUpdate()
    {
        //给球添加移动的力
        if (!brake) {
            _rb.AddForce(_direction * _moveForce, ForceMode.Force);
            _rb.AddTorque(Vector3.up * spin * _rotationForce);
        }
        else {
            _rb.velocity = Vector3.Lerp(_rb.velocity,
                new Vector3(0, _rb.velocity.y, 0), 0.2f);
        }
    }
}
