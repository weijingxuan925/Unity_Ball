using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonController : MonoBehaviour
{
    [SerializeField]
    private float _speed = 3.0f;
    [SerializeField]
    private float _force = 50.0f;
    
    //�ڹ�λ��
    [SerializeField]
    private Transform _muzzle;
    //�����
    [SerializeField]
    private Transform _lunchPoint;
    //�����
    [SerializeField]
    private GameObject _mainCamera;
    //������Ч
    [SerializeField]
    private AudioClip _audioClip;

    //���
    private Transform _canonBall;
    //��¼���ڳ�ʼλ��
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
                //�ָ��������
                _mainCamera.GetComponent<CameraController>().Target = _canonBall;
                _mainCamera.GetComponent<CameraController>().enabled = false;
                _mainCamera.GetComponent<Camera2>().enabled = true;
                //�ָ�����
                _canonBall = null;
                _muzzle = _muzzlePoint;
                this.GetComponent<BoxCollider>().enabled = true;
                //���ſ�����Ч
                AudioManager.instance.AudioPlay(_audioClip);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            //�ر���ײ��
            this.GetComponent<BoxCollider>().enabled = false;
            _canonBall = other.transform;
            //�ر���ҵ��ƶ��ű�
            _canonBall.GetComponent<PlayerMoveController>().enabled = false;
            _canonBall.gameObject.SetActive(false);
            //ʹС���ٶ�����
            _canonBall.GetComponent<Rigidbody>().velocity = Vector3.zero;
            _canonBall.position = other.transform.position;
            //�ı��������
            _mainCamera.GetComponent<CameraController>().enabled = true;
            _mainCamera.GetComponent<Camera2>().enabled = false;
            _mainCamera.GetComponent<CameraController>().Target = _muzzle;
            
        }
    }
}
