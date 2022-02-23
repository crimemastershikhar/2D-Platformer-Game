using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class gameovercontroller : MonoBehaviour
{
    private void Awake()
    {
        buttonRestart.onClick.AddListener(ReloadLevel);
    }
    public void Lobby()
    {
        SceneManager.LoadScene(0);
    }
    public Button buttonRestart;
    public void PlayerDied()
    {
        gameObject.SetActive(true);
    }
    public void ReloadLevel()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.buildIndex);
        Time.timeScale = 1f;
    }
}
