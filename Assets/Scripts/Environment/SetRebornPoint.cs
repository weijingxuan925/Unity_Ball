using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetRebornPoint : MonoBehaviour
{
    //����������Ľű�
    private void OnTriggerEnter(Collider other)
    {
        other.GetComponent<PlayerMoveController>().SetRebornPoint(other.transform.position);
    }
}
