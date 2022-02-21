using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    PlayerControls controls;
    public Player player;
    private int score;
    public Text scoreText;
    public GameObject playBtn;
    public GameObject gameOver;

    private void Awake() {
        controls = new PlayerControls();
        controls.Gameplay.Play.performed += ctx => Play();
        Application.targetFrameRate = 60;
        Pause();
    }

    private void OnEnable() {
        controls.Gameplay.Enable();
    }
    void OnDisable()
     {
       controls.Gameplay.Disable();
     }

    public void Play() {
        score = 0;
        scoreText.text = score.ToString();

        playBtn.SetActive(false);
        gameOver.SetActive(false);

        Time.timeScale = 1f;
        player.enabled = true;
        player.MovePlayer();

        Pipe[] pipes = FindObjectsOfType<Pipe>();

        for(int i = 0; i < pipes.Length; i++) {
            Destroy(pipes[i].gameObject);
        }
        controls.Gameplay.Play.Disable();
    }

    public void Pause() {
        Time.timeScale = 0f;
        player.enabled = false;
        controls.Gameplay.Play.Enable();
    }
    
    public void GameOver() {
        gameOver.SetActive(true);
        playBtn.SetActive(true);

        Pause();
    }
    public void IncreaseScore() {
        score++;
        scoreText.text = score.ToString();
    }
}
