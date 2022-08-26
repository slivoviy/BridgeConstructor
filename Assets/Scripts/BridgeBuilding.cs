using System;
using System.Collections;
using UnityEngine;

public class BridgeBuilding : MonoBehaviour {
    [SerializeField] private float movementSpeed;
    [SerializeField] private float buildingSpeed;
    [SerializeField] private float rotationSpeed;

    private GameObject buildingSound;
    private GameManager gameManager;
    private bool buildingStarted;
    private bool buildingFinished;

    private void Start() {
        buildingSound = Resources.FindObjectsOfTypeAll<AudioSource>()[0].gameObject;
        gameManager = GameManager.Self;
    }

    private void FixedUpdate() {
        if (Input.GetMouseButton(0) && transform.localScale.x <= 4 && !buildingFinished) {
            if (!buildingStarted) {
                buildingStarted = true;
                buildingSound.SetActive(true);
            }
            
            Scale();

        } else if (buildingStarted) {
            buildingFinished = true;
            buildingSound.SetActive(false);
            
            Rotate();
            if (transform.rotation.z > 0) return;
            transform.rotation = Quaternion.Euler(0, 0, 0);
            
            buildingStarted = false;
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