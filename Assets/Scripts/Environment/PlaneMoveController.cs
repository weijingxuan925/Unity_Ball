using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneMoveController : MonoBehaviour
{
    [SerializeField]
    private Vector3 _direction = new Vector3(0,0,0);
    [SerializeField]
    private float _speed = 3.0f;
    [SerializeField]
    private float _time = 3.0f;

    private float _timer = 0f;

    private float _stayTime = 1f;

    private Vector3 _temp;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_timer < _time)
        {
            _temp = _direction;
            _timer += Time.deltaTime;
        }
        else if (_timer < _time + _stayTime)
        {
            _temp = new Vector3(0,0,0);
            _timer += Time.deltaTime;
        }
        else {
           _direction *= -1;
            _timer = 0;
        }
        
    }
    private void FixedUpdate()
    {
        transform.position += _temp * _speed * Time.deltaTime;
    }
}
