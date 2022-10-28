using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePlayerMaterial : MonoBehaviour
{
    //改变材质的触发器脚本
    [SerializeField]
    private int ChangeType = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") {
            other.GetComponent <BallTriggerController>().SetBallType(ChangeType);
        }
    }
}
