using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonController : MonoBehaviour
{
    [SerializeField]
    private float _speed = 3.0f;
    [SerializeField]
    private float _force = 50.0f;
    //存放玩家位置
    [SerializeField]
    private Transform _canonBall;
    //炮管位置
    [SerializeField]
    private Transform _muzzle;
    //发射点
    [SerializeField]
    private Transform _lunchPoint;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player"){
            //关闭碰撞盒
            this.GetComponent<BoxCollider>().enabled = false;
            _canonBall = other.transform;
            //关闭玩家的移动脚本
            _canonBall.GetComponent<PlayerMoveController>().enabled = false;
            _canonBall.gameObject.SetActive(false);
            //使小球速度置零
            _canonBall.GetComponent<Rigidbody>().velocity = Vector3.zero;
            _canonBall.position = other.transform.position;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_canonBall != null) {
            _muzzle.Rotate(Vector3.left * _speed * Input.GetAxis("Vertical"));
            if (Input.GetKeyDown(KeyCode.F)) {
                _canonBall.position = _lunchPoint.position;
                _canonBall.gameObject.SetActive(true);
                _canonBall.GetComponent<Rigidbody>().AddForce(_force * Vector3.forward,ForceMode.Impulse);
                _canonBall.GetComponent<PlayerMoveController>().enabled = true;
            }
        }
    }
}
