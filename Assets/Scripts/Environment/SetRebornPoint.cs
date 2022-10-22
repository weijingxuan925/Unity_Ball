using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetRebornPoint : MonoBehaviour
{
    //更新重生点的脚本
    private void OnTriggerEnter(Collider other)
    {
        other.GetComponent<PlayerMoveController>().SetRebornPoint(other.transform.position);
    }
}
