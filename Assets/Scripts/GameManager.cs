using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    public static GameManager Self;

    [SerializeField] private GameObject bridge;
    [SerializeField] private Animator playerAnimator;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private GameObject gameOverSound;

    private bool isBuilding;
    public bool IsBuilding {
        get => isBuilding;
        set {
            isBuilding = value;
            if (isBuilding) {
                Instantiate(bridge);
            }
            else {
                playerAnimator.SetBool(IsMoving, true);
            }
        }
    }
    public bool PlayerCanCollide { get; set; }

    private int score;
    private static readonly int IsMoving = Animator.StringToHash("isMoving");
    private Vector3 playerPosition;
    private Rigidbody2D playerRigidbody;

    private void Awake() {
        Self = this;
        PlayerCanCollide = true;

        playerPosition = playerAnimator.transform.position;
        playerRigidbody = playerAnimator.gameObject.GetComponent<Rigidbody2D>();
    }

    public void UpdateScore() {
        score += 1;
        scoreText.text = score.ToString();
    }

    public void GameOver() {
        Time.timeScale = 0;

        gameOverSound.SetActive(true);
        
        gameOverPanel.transform.GetChild(0).GetChild(1).gameObject.GetComponent<TextMeshProUGUI>().text =
            score.ToString();
        if (PlayerPrefs.HasKey("highscore")) {
            var highscoreText = gameOverPanel.transform.GetChild(0).GetChild(2).gameObject;
            highscoreText.SetActive(true);
            highscoreText.GetComponent<TextMeshProUGUI>().text =
                PlayerPrefs.GetInt("highscore").ToString();
        }

        gameOverPanel.SetActive(true);
    }

    public void RestartGame() {
        if (score > PlayerPrefs.GetInt("highscore", 0)) PlayerPrefs.SetInt("highscore", score);

        Time.timeScale = 1;
        SceneManager.LoadScene("GameScene");
    }

    public void RevivePlayer() {
        StartCoroutine(DropPlayer());
    }

    private IEnumerator DropPlayer() {
        playerRigidbody.gravityScale = 0;
        playerAnimator.transform.position = playerPosition;

        gameOverPanel.SetActive(false);
        gameOverSound.SetActive(false);
        Time.timeScale = 1f;
        PlayerCanCollide = true;
        
        yield return new WaitForSeconds(0.2f);

        playerRigidbody.gravityScale = 15;

    }
}