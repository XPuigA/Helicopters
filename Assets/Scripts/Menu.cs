using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour {

    public Button newGame;
    public Button exit;

    private void Start() {
        
        newGame.onClick.AddListener(delegate { LoadScene(); });
        exit.onClick.AddListener(delegate { Exit(); });
    }

    public void LoadScene() {
        Debug.Log("Click");
        SceneManager.LoadScene("Generator", LoadSceneMode.Single);
    }

    public void Exit() {
        Debug.Log("Exit");
        Application.Quit();
    }
}
