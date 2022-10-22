using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class DeahMenu : MonoBehaviour
{
    //�����˵��ű�
    [SerializeField]
    private GameObject _deahMenu;
    [SerializeField]
    private AudioClip _deathClip;

    public void ShowDeahMenu() {
        //��ͣ��Ϸ
        Time.timeScale = 0;
        _deahMenu.SetActive(true);
        AudioManager.instance.AudioPlay(_deathClip);
    }
    public void Reborn() {
        //�����ͣ
        Time.timeScale = 1.0f;
        GameObject.Find("PokemonBall").GetComponent<PlayerMoveController>().RebornBall();
        _deahMenu.SetActive(false);
    }
    public void ExitGame() {
        #if UNITY_EDITOR
                EditorApplication.isPlaying = false;//�����˳�����
        #else
                Application.Quit();
        #endif
    }
}
