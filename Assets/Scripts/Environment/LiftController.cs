using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;

public class LiftController : MonoBehaviour
{
    //获取两个箱子的位置
    [SerializeField]
    private Transform Box1;
    [SerializeField]
    private Transform Box2;
    //平台移动的终点位置
    [SerializeField]
    private Transform targetTransform;

    [SerializeField]
    private float Speed = 3.0f;
    //箱子是否掉下
    private bool _box1IsFall = false;
    private bool _box2IsFall = false;
    
    void Update()
    {
        //判断两个对象是否掉下
        if (Box1 != null) {
            if (Box1.transform.position.y < 45f) {
                _box1IsFall = true;
                Destroy(Box1.gameObject);
            }
        }
        if (Box2 != null) {
            if (Box2.transform.position.y < 45f) {
                _box2IsFall = true;
                Destroy(Box2.gameObject);
            }
        }
        //如果都掉下了，平台上升
        if (_box1IsFall && _box2IsFall) {
            if (transform.position.y > targetTransform.position.y) {
                transform.position -= Vector3.up * Speed * Time.deltaTime;
            }
        }
    }
}
