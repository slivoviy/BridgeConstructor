using System;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public static GameManager Self;
    
    [SerializeField] private GameObject bridge;
    [SerializeField] private Animator playerAnimator;
    [SerializeField] private TextMeshProUGUI scoreText;

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

    private int score;
    private static readonly int IsMoving = Animator.StringToHash("isMoving");

    private void Awake() {
        Self = this;
    }

    public void UpdateScore() {
        score += 1;
        scoreText.text = score.ToString();
    }
}