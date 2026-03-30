using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance { get; private set; }
    public GameScene gameScene { get; private set; }

    // Fungsi yang dijalankan saat GameManager diinisialisasi 
    private void Awake()
    {
        // Validasi bahwa hanya ada satu otak atau GameManager dan mengeliminiasi GameManager duplikat
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject); // Hapus GameObject duplikat
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject); // Pertahankan GameManager saat pergantian scene
        }
    }

    // Fungsi yang dijalankan saat GameManager diaktifkan
    private void OnEnable()
    {
        // Fungsi yang menerima kabar/aba-aba saat scene dimuat, serta menjalankan fungsi OnSceneLoaded secara otomatis
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    // Fungsi yang dijalankan saat GameManager dinonaktifkan
    private void OnDisable()
    {
        // Fungsi yang mematikan kabar/aba-aba saat scene dimuat, serta menjalankan fungsi OnSceneLoaded secara otomatis
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    // Fungsi yang dijalankan saat scene dimuat
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        var nowScene = SceneManager.GetActiveScene().name;
        switch (nowScene)
        {
            case "MainMenu":
                UpdateGameScene(GameScene.MAINMENU);
                break;
            case "Gameplay":
                UpdateGameScene(GameScene.GAME);
                break;
        }
    }

    void UpdateGameScene(GameScene scene)
    {
        gameScene = scene;
        switch (gameScene)
        {
            case GameScene.MAINMENU:
                //Debug.Log("Main Menu");
                break;
            case GameScene.GAME:
                //Debug.Log("Gameplay");
                break;
        }
    }
}
