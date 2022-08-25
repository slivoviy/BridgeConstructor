using System;
using System.Collections;
using UnityEngine;

public class BridgeBuilding : MonoBehaviour {
    [SerializeField] private float movementSpeed;
    [SerializeField] private float buildingSpeed;
    [SerializeField] private float rotationSpeed;
    
    private GameManager gameManager;
    private bool buildingStarted;
    private bool buildingFinished;

    private void Start() {
        gameManager = GameManager.Self;
    }

    private void FixedUpdate() {
        if (Input.GetMouseButton(0) && transform.localScale.x <= 4 && !buildingFinished) {
            if(!buildingStarted) buildingStarted = true;
            
            Scale();

        } else if (buildingStarted) {
            Rotate();
            if (transform.rotation.z > 0) return;
            transform.rotation = Quaternion.Euler(0, 0, 0);
            
            buildingStarted = false;
            buildingFinished = true;
            gameManager.IsBuilding = false;
        }
        else if(!gameManager.IsBuilding) {
            Move();
        }
    }

    private void Move() {
        transform.Translate(Vector3.left * (movementSpeed * Time.deltaTime));
    }
    
    private void Rotate() {
        transform.Rotate(new Vector3(0, 0, -rotationSpeed) * Time.deltaTime);
    }

    private void Scale() {
        transform.localScale += new Vector3(1, 0, 0) * (Time.deltaTime * buildingSpeed);
    }
}