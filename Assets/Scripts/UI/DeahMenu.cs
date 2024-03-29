using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
//死亡菜单脚本
public class DeahMenu : MonoBehaviour
{

    [SerializeField]
    private GameObject _deahMenu;
    [SerializeField]
    private GameObject _gameOver;
    [SerializeField]
    private AudioClip _deathClip;

    public void ShowDeahMenu() {
        //暂停游戏
        Time.timeScale = 0;
        _deahMenu.SetActive(true);
        AudioManager.instance.AudioPlay(_deathClip);
    }
    public void ShowGameOverMenu() {
        Time.timeScale = 0;
        _gameOver.SetActive(true);
        AudioManager.instance.AudioPlay(_deathClip);
    }
    public void Reborn() {
        //解除暂停
        Time.timeScale = 1.0f;
        GameObject.Find("PokemonBall").GetComponent<BallTriggerController>().RebornBall();
        _deahMenu.SetActive(false);
    }
    public void EnterScene(string name){
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(name);
    }
    public void ExitGame() {
        #if UNITY_EDITOR
                EditorApplication.isPlaying = false;//用于退出运行
        #else
                Application.Quit();
        #endif
    }
}
