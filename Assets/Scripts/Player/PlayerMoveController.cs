using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ProBuilder.Shapes;

//玩家移动脚本
public class PlayerMoveController : MonoBehaviour
{

    [SerializeField]
    private float _moveForce = 50.0f;
    [SerializeField]
    private float _rotationForce = 10.0f;

    private int spin;

    private Rigidbody _rb;
    //给小球力的方向
    private Vector3 _direction;
    //是否给球添加力
    private bool brake = false;
    
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
        
        _direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

       
        float y = Camera.main.transform.rotation.eulerAngles.y;
        _direction = Quaternion.Euler(0, y, 0) * _direction;

        //球的自身扭力
        spin = 0;
        if (Input.GetKey(KeyCode.Q)) {
            spin = 1;
        }
        if (Input.GetKey(KeyCode.E)) {
            spin = -1;
        }
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
        //给球添加扭力
        _rb.AddForce(Vector3.forward * _moveForce * Time.deltaTime, ForceMode.Force);
    }
}
