using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//更新重生点的脚本
public class SetRebornPoint : MonoBehaviour
{
    
    private void OnTriggerEnter(Collider other)
    {
        other.GetComponent<BallTriggerController>().SetRebornPoint(other.transform.position);
    }
}
