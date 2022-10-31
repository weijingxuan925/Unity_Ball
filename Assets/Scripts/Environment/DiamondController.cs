using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiamondController : MonoBehaviour
{
    //钻石旋转的脚本
    [SerializeField]
    private float _speed = 10.0f;
    //收集音效
    [SerializeField]
    private AudioClip _collectClip;
    //收集特效
    [SerializeField]
    private ParticleSystem _diamondEffect;
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
            //生成特效
            Instantiate(_diamondEffect,transform.position,Quaternion.identity);
            //播放音效
            AudioManager.instance.AudioPlay(_collectClip);
            Destroy(this.gameObject);
        }
    }

}
