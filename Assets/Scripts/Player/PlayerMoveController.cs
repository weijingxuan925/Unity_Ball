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
    //给小球力的方向
    private Vector3 _direction;
    //是否给球添加力
    private bool brake = false;
    //重生点
    private Vector3 _rebornPoint;
    //是否死了
    private bool _isDeath = false;
    //小球的类型（0、精灵球-质量正常 | 1、高级球-质量轻 | 2、大师球-质量重）
    private int _ballType = 0;
    //材质数组
    [SerializeField]
    private Material[] _ballMaterials;

    private Animator _anim;
    //给小球更换材质
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

    //自定义一个设置重生点的函数
    public void SetRebornPoint(Vector3 res) {
        _rebornPoint = res;
    }
    //小球重生的方法
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
        //初始化重生点
        _rebornPoint = _rb.position;
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

        //小球重生设置
        if (_rb.position.y < 5.0f && !_isDeath)
        {
            //打开提示
            GameObject.Find("Util").GetComponent<DeahMenu>().ShowDeahMenu();
            _isDeath = true;
        }
        else if(_rb.position.y >=5.0f){
            _isDeath = false;
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
