using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EscMenu : MonoBehaviour
{
    // Esc menu
    [SerializeField]
    private GameObject _escMenu;

    public void ReTry(string name) {
        SceneManager.LoadScene(name);
        Time.timeScale = 1.0f;
    }
    public void Continue() {
        // continue run
        Time.timeScale = 1.0f;
        _escMenu.SetActive(false);
    }
    public void Save(string name) {
        PlayerPrefs.SetString("Scenename",name);
    }
    public void EnterScene(string name) {
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
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            Time.timeScale = 0;
            _escMenu.SetActive(true);
        }
    }
}
