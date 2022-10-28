using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiamondController : MonoBehaviour
{
    //��ʯ��ת�Ľű�
    [SerializeField]
    private float _speed = 10.0f;
    //�ռ���Ч
    [SerializeField]
    private AudioClip _collectClip;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up * _speed * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") {
            GameObject.Find("PokemonBall").GetComponent<PlayerAttributeManager>().SetScore(100);
            AudioManager.instance.AudioPlay(_collectClip);
            Destroy(this.gameObject);
        }
    }

}
