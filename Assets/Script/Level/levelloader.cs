using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Button))]
public class levelloader : MonoBehaviour
{
    private Button button;
    public string LevelName;
    private void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(onClick);
    }
    private void onClick()
    {
        LevelStatus levelStatus = levelmanager.Instance.GetLevelStatus(LevelName);
        switch(levelStatus)
        {
            case LevelStatus.Locked:
                Debug.Log("Cant Plauy");
                break;
            case LevelStatus.Unlocked:
                SceneManager.LoadScene(LevelName);
                break;
            case LevelStatus.Completed:
                SceneManager.LoadScene(LevelName);
                break;
        }
    }
}