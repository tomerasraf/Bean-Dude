using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PauseMenu : MonoBehaviour
{
    Player _player = null;
    GameObject pauseMenu = null;
    TextMeshProUGUI highestScore = null;
    TextMeshProUGUI score = null;
    private void Awake()
    {
        _player = GameObject.FindWithTag("Player").GetComponent<Player>();
        pauseMenu = GameObject.FindWithTag("PauseMenu");
        highestScore = GameObject.Find("HigestScore").GetComponent<TextMeshProUGUI>();
        score = GameObject.Find("Score").GetComponent<TextMeshProUGUI>();
    }
    private void Start()
    {
        highestScore.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
        pauseMenu.SetActive(false);
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
        pauseMenu.SetActive(true);
        score.text = _player.distanceTravelledInt.ToString();
        if (_player.distanceTravelledInt > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", _player.distanceTravelledInt);
            highestScore.text = _player.distanceTravelledInt.ToString();
        }

    }


}
