using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindmillController : MonoBehaviour
{
    [SerializeField]
    private bool IsUpRotate = false;
    [SerializeField]
    private float Speed = 5.0f;

   

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (IsUpRotate)
        {
            this.transform.Rotate(Vector3.up, Time.deltaTime * Speed);
        }
        else {
            this.transform.Rotate(Vector3.down, Time.deltaTime * Speed);
        }
        
    }
}
