using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class gameovercontroller : MonoBehaviour
{
    public Button quit;
    private void Awake()
    {
        buttonRestart.onClick.AddListener(ReloadLevel);
        quit.onClick.AddListener(Lobby);
        
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
        Invoke(nameof(ReloadLevel), 1.5f);
        SceneManager.LoadScene(1    );
    }
}
