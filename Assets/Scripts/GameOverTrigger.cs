using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverTrigger : MonoBehaviour {
    [SerializeField] private GameManager gameManager;
    private void OnTriggerEnter2D(Collider2D other) {
        if (!other.CompareTag("Player")) return;

        gameManager.GameOver();
    }
}