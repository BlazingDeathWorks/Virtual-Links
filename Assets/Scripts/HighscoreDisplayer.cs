using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighscoreDisplayer : MonoBehaviour
{
    private Text highscoreDisplayText;

    private void Awake()
    {
        Cursor.visible = true;
        highscoreDisplayText = GetComponent<Text>();
        if (highscoreDisplayText == null) return;
        highscoreDisplayText.text = $"Highscore: {PlayerPrefs.GetInt("Highscore")}";
    }
}
