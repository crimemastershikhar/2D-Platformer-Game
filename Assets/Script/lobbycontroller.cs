using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class lobbycontroller : MonoBehaviour
{
    public Button buttonplay;
    private void Awake()
    {
        buttonplay.onClick.AddListener(playgame);
    }
    private void playgame()
    {
        SceneManager.LoadScene(1);
    }
}
