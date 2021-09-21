using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    PlayerMovment _playerMovement;
    Player _player;
    private void Awake()
    {
        _playerMovement = GameObject.FindWithTag("Player").GetComponent<PlayerMovment>();
        _player = GameObject.FindWithTag("Player").GetComponent<Player>();
    }
    public void RestartLevel()
    {
        SceneManager.LoadScene("Game0.1");
        Time.timeScale = 1f;
        _playerMovement.playerSpeed = _playerMovement.startPlayerSpeed;
        _player.mileStone = 500f;
        _player.curMileStone = _player.mileStone;
    }

    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
