using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ProBuilder.Shapes;

//����ƶ��ű�
public class PlayerMoveController : MonoBehaviour
{

    [SerializeField]
    private float _moveForce = 50.0f;
    [SerializeField]
    private float _rotationForce = 10.0f;

    private int spin;

    private Rigidbody _rb;
    //��С�����ķ���
    private Vector3 _direction;
    //�Ƿ���������
    private bool brake = false;
    
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //���ſո񲻼������ƶ���
        brake = Input.GetKey(KeyCode.Space);
        
        _direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

       
        float y = Camera.main.transform.rotation.eulerAngles.y;
        _direction = Quaternion.Euler(0, y, 0) * _direction;

        //�������Ť��
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
        //��������ƶ�����
        if (!brake) {
            _rb.AddForce(_direction * _moveForce, ForceMode.Force);
            _rb.AddTorque(Vector3.up * spin * _rotationForce);
        }
        else {
            _rb.velocity = Vector3.Lerp(_rb.velocity,
                new Vector3(0, _rb.velocity.y, 0), 0.2f);
        }
        //�������Ť��
        _rb.AddForce(Vector3.forward * _moveForce * Time.deltaTime, ForceMode.Force);
    }
}
