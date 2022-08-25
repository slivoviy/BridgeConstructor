using System;
using UnityEngine;

public class BlockMovement : MonoBehaviour {
    [SerializeField] private float speed;
    
    private GameManager gameManager;

    private void Start() {
        gameManager = GameManager.Self;
    }

    private void FixedUpdate() {
        if (!gameManager.IsBuilding) {
            transform.Translate(Vector3.left * (speed * Time.deltaTime));
        }
    }
}