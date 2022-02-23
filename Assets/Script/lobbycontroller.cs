using UnityEngine;
using UnityEngine.UI;

public class lobbycontroller : MonoBehaviour
{
    public Button buttonplay;
    public GameObject LevelSelection;
    private void Awake()
    {
        buttonplay.onClick.AddListener(playgame);
    }
    private void playgame()
    {
        LevelSelection.SetActive(true);
    }
}
