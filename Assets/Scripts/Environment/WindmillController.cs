using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindmillController : MonoBehaviour
{
    //控制风车旋转的脚本
    [SerializeField]
    private bool IsUpRotate = false;
    [SerializeField]
    private float Speed = 5.0f;

   
    private void FixedUpdate()
    {
        if (IsUpRotate)
        {
            this.transform.Rotate(Vector3.up, Time.deltaTime * Speed);
        }
        else
        {
            this.transform.Rotate(Vector3.down, Time.deltaTime * Speed);
        }
    }
}
