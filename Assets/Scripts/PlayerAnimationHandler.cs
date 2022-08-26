using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationHandler : MonoBehaviour {
    [SerializeField] private GameManager gameManager;
    
    private Animator playerAnimator;
    private static readonly int IsMoving = Animator.StringToHash("isMoving");

    private void Start() {
        playerAnimator = gameObject.GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        switch (other.tag) {
            case "AddScore":
                gameManager.UpdateScore();
                break;
            case "StartBuilding":
                if(!gameManager.PlayerCanCollide) return;
                
                playerAnimator.SetBool(IsMoving, false);
                gameManager.IsBuilding = true;
                break;
        }
    }
}