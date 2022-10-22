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
    //��С�����ķ���
    private Vector3 _direction;
    //�Ƿ���������
    private bool brake = false;
    //������
    private Vector3 _rebornPoint;
    //�Ƿ�����
    private bool _isDeath = false;
    //С������ͣ�0��������-�������� | 1���߼���-������ | 2����ʦ��-�����أ�
    private int _ballType = 0;
    //��������
    [SerializeField]
    private Material[] _ballMaterials;

    private Animator _anim;
    //��С���������
    public void SetBallType(int type) {
        this.GetComponent<Renderer>().material = _ballMaterials[type];

        if (_ballType != type) {
            if (type == 0) {
                _rb.mass = 4.0f;
                _rb.drag = 1.0f;
                _rb.angularDrag = 0.05f;
            }
            if (type == 1) {
                _rb.mass = 2.0f;
                _rb.drag = 0.1f;
                _rb.angularDrag = 0.05f;
            }
            if (type == 2) {
                _rb.mass = 8.0f;
                _rb.drag = 1.5f;
                _rb.drag = 0.1f;
            }
        }
    }

    //�Զ���һ������������ĺ���
    public void SetRebornPoint(Vector3 res) {
        _rebornPoint = res;
    }
    //С�������ķ���
    public void RebornBall() {
        this.transform.position = _rebornPoint;
        _rb.velocity = Vector3.zero;
        _rb.constraints = RigidbodyConstraints.FreezeAll;
        _rb.constraints = RigidbodyConstraints.None;
    }
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        //��ʼ��������
        _rebornPoint = _rb.position;
    }

    // Update is called once per frame
    void Update()
    {
        //���ſո񲻼������ƶ���
        brake = Input.GetKey(KeyCode.Space);
        //��ȡ�ƶ�����
        _direction = new Vector3(Input.GetAxis("Horizontal"),0,Input.GetAxis("Vertical"));
        //�������Ť��
        spin = 0;
        if (Input.GetKey(KeyCode.Q)) {
            spin = 1;
        }
        if (Input.GetKey(KeyCode.E)) {
            spin = -1;
        }

        //С����������
        if (_rb.position.y < 5.0f && !_isDeath)
        {
            //����ʾ
            GameObject.Find("Util").GetComponent<DeahMenu>().ShowDeahMenu();
            _isDeath = true;
        }
        else if(_rb.position.y >=5.0f){
            _isDeath = false;
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
