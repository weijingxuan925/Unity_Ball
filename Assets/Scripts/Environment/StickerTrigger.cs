using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickerTrigger : MonoBehaviour
{
    [SerializeField]
    private int _index;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") {
            PlayerPrefs.SetInt("Sticker"+_index,6);
            Destroy(this.gameObject);
        }
    }
}
