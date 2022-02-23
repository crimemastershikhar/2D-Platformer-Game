using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class scorecontroller : MonoBehaviour
{
    private TextMeshProUGUI scoretext;

    private int score = 0;
    private void Awake()
    {
        scoretext = GetComponent<TextMeshProUGUI>();
    }
    private void Start()
    {
        RefreshUI();
    }
    public void Increasescore(int increment)
    {
        score += increment;
        RefreshUI();
    }
    private void RefreshUI()
    {
        scoretext.text = "Score: " + score;
    }
}
