using System;
using UnityEngine;

public class BridgeCollisionHandler : MonoBehaviour {
    private GameManager gameManager;
    private int collisionCount;

    private void Start() {
        gameManager = GameManager.Self;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Bridge") || other.CompareTag("Destroyer")) return;

        if (collisionCount == 0) {
            gameManager.PlayerCanCollide = true;
        }

        collisionCount++;

        // Debug.Log("Entered:" + other.gameObject.name + " " + collisionCount + " " + gameObject.transform.parent.name +
                  // " " + gameManager.PlayerCanCollide);
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.CompareTag("Bridge") || other.CompareTag("Destroyer") || other.CompareTag("Block")) return;

        collisionCount--;

        if (collisionCount == 0) {
            gameManager.PlayerCanCollide = false;
        }

        // Debug.Log("Exited: " + other.gameObject.name + " " + collisionCount + " " + gameObject.transform.parent.name +
        //           " " + gameManager.PlayerCanCollide);
    }

    private void OnDestroy() {
        gameManager.PlayerCanCollide = true;
        // Debug.Log("Destroyed " + gameObject.transform.parent.name + " " + gameManager.PlayerCanCollide);
    }
}