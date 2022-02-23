using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

    public class levelmanager : MonoBehaviour
    {
    private static levelmanager instance;
    public static levelmanager Instance { get { return instance; } }
    public string[] Levels;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        } else
        {
            Destroy(gameObject);
        }
    }
/*        internal void MarkCurrentLevelComplete()
    {
        throw new NotImplementedException();
    }*/

    private void Start()
    {
        if(GetLevelStatus(Levels[0]) == LevelStatus.Locked)
        {
            SetLevelStatus(Levels[0], LevelStatus.Unlocked);
        }
    }
    public void MarkCurrentLevelComplete()
    {
        Scene currentscene = SceneManager.GetActiveScene();
        /*        SetLevelStatus(currentscene.name, LevelStatus.Completed);
                int nextSceneIndex = currentscene.buildIndex + 1;
                Scene nextScene = SceneManager.GetSceneByBuildIndex(nextSceneIndex);
                SceneManager.
                SetLevelStatus(nextScene.name, LevelStatus.Unlocked);*/
        int CurrentSceneIndex = Array.FindIndex(Levels, level => level == currentscene.name);
        int NextSceneIndex = CurrentSceneIndex + 1;
        if(NextSceneIndex < Levels.Length)
        {
            SetLevelStatus(Levels[NextSceneIndex], LevelStatus.Unlocked);
        }
    }
    public LevelStatus GetLevelStatus(string level)
    {
       LevelStatus levelStatus = (LevelStatus)PlayerPrefs.GetInt(level, 0);
        return levelStatus;
    }
    public void SetLevelStatus(string level, LevelStatus levelStatus)
    {
        PlayerPrefs.SetInt(level, (int)levelStatus);
        Debug.Log("Setting Level" + level + "Status:" + levelStatus);
    }
}