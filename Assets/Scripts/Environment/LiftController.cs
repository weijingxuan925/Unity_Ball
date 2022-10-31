using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;

public class LiftController : MonoBehaviour
{
    //��ȡ�������ӵ�λ��
    [SerializeField]
    private Transform Box1;
    [SerializeField]
    private Transform Box2;
    //ƽ̨�ƶ����յ�λ��
    [SerializeField]
    private Transform targetTransform;

    [SerializeField]
    private float Speed = 3.0f;
    //�����Ƿ����
    private bool _box1IsFall = false;
    private bool _box2IsFall = false;
    
    void Update()
    {
        //�ж����������Ƿ����
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
        //����������ˣ�ƽ̨����
        if (_box1IsFall && _box2IsFall) {
            if (transform.position.y > targetTransform.position.y) {
                transform.position -= Vector3.up * Speed * Time.deltaTime;
            }
        }
    }
}
