using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//����������Ľű�
public class SetRebornPoint : MonoBehaviour
{
    
    private void OnTriggerEnter(Collider other)
    {
        other.GetComponent<BallTriggerController>().SetRebornPoint(other.transform.position);
    }
}
