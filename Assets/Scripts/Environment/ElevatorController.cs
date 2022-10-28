using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorController : MonoBehaviour
{
    [SerializeField]
    private float _speed = 3.0f;
    [SerializeField]
    private float _time01 = 2.0f;
    [SerializeField]
    private float _time02 = 5.0f;
    private float _timer = 0;

    private bool _isEnter = false;
    private bool _isCloseDoor = false;
    private bool _isMoved = false;
    private bool _isOpenDoor = false;
    //电梯开门、关门动画
    [SerializeField]
    private Animator _animCloseDoor;
    [SerializeField]
    private Animator _animOpenDoor;

    Transform _transform;
    
    // Start is called before the first frame update
    void Start()
    {
        _transform = GetComponent<Transform>();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        if (_isEnter)
        {
            _timer += Time.deltaTime;
            if (_timer >= _time01 && !_isCloseDoor)
            {
                _animCloseDoor.SetTrigger("Close");
                _isCloseDoor = true;
            }
            if (_timer > _time01 && _timer <= _time02 && _isCloseDoor && !_isMoved)
            {
                _transform.position += Vector3.up * _speed * Time.deltaTime;
            }
            if (_timer >= _time02 && !_isOpenDoor)
            {
                _animOpenDoor.SetTrigger("Open");
                _isOpenDoor = true;
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        _isEnter = true;
    }
    private void OnTriggerExit(Collider other)
    {
        /*if (_timer >= _time02 && _isOpenDoor) {
            _animOpenDoor.SetTrigger("");
        }*/
        //_isEnter = false;
    }
}
