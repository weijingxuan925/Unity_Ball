using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonController : MonoBehaviour
{
    [SerializeField]
    private float _speed = 3.0f;
    [SerializeField]
    private float _force = 50.0f;
    //������λ��
    [SerializeField]
    private Transform _canonBall;
    //�ڹ�λ��
    [SerializeField]
    private Transform _muzzle;
    //�����
    [SerializeField]
    private Transform _lunchPoint;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player"){
            //�ر���ײ��
            this.GetComponent<BoxCollider>().enabled = false;
            _canonBall = other.transform;
            //�ر���ҵ��ƶ��ű�
            _canonBall.GetComponent<PlayerMoveController>().enabled = false;
            _canonBall.gameObject.SetActive(false);
            //ʹС���ٶ�����
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
