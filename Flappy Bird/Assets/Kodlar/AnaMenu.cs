using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AnaMenu : MonoBehaviour
{
    public Text bestScoreText;

    private void Start()
    {
        bestScoreText.text = "Best: " + PlayerPrefs.GetInt("bestScore").ToString();
    }

    public void oyunaGit()
    {
        SceneManager.LoadScene("level1");
    }

    public void oyundanCik()
    {
        Application.Quit();
    }
}
