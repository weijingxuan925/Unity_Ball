using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonController : MonoBehaviour
{
    [SerializeField]
    private float _speed = 3.0f;
    [SerializeField]
    private float _force = 50.0f;
    
    //炮管位置
    [SerializeField]
    private Transform _muzzle;
    //发射点
    [SerializeField]
    private Transform _lunchPoint;
    //摄像机
    [SerializeField]
    private GameObject _mainCamera;
    //开炮音效
    [SerializeField]
    private AudioClip _audioClip;

    //玩家
    private Transform _canonBall;
    //记录大炮初始位置
    private Transform _muzzlePoint;

    // Start is called before the first frame update
    void Start()
    {
        _muzzlePoint = _muzzle;
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
                //恢复相机跟随
                _mainCamera.GetComponent<CameraController>().Target = _canonBall;
                _mainCamera.GetComponent<CameraController>().enabled = false;
                _mainCamera.GetComponent<Camera2>().enabled = true;
                //恢复大炮
                _canonBall = null;
                _muzzle = _muzzlePoint;
                this.GetComponent<BoxCollider>().enabled = true;
                //播放开炮音效
                AudioManager.instance.AudioPlay(_audioClip);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            //关闭碰撞盒
            this.GetComponent<BoxCollider>().enabled = false;
            _canonBall = other.transform;
            //关闭玩家的移动脚本
            _canonBall.GetComponent<PlayerMoveController>().enabled = false;
            _canonBall.gameObject.SetActive(false);
            //使小球速度置零
            _canonBall.GetComponent<Rigidbody>().velocity = Vector3.zero;
            _canonBall.position = other.transform.position;
            //改变相机跟随
            _mainCamera.GetComponent<CameraController>().enabled = true;
            _mainCamera.GetComponent<Camera2>().enabled = false;
            _mainCamera.GetComponent<CameraController>().Target = _muzzle;
            
        }
    }
}
