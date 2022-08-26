using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
using Random = UnityEngine.Random;

public class BlockConstructor : MonoBehaviour {
    [SerializeField] private GameObject block;

    [SerializeField] private float triggerWidth;

    [SerializeField] private float emptyWidthMin;
    [SerializeField] private float emptyWidthMax;

    [SerializeField] private float blockWidthMin;
    [SerializeField] private float blockWidthMax;

    private void Start() {
        SpawnBlock();
    }

    public void SpawnBlock() {
        transform.localScale = new Vector3(Random.Range(emptyWidthMin, emptyWidthMax), 1, 1);

        var newBlock = Instantiate(block);
        ConstructBlock(newBlock);

        var blockTransform = newBlock.transform;

        var endTrigger = blockTransform.GetChild(0);
        var beginningTrigger = blockTransform.GetChild(1);
        ConstructBlockTriggers(blockTransform, beginningTrigger, endTrigger);
    }

    private void ConstructBlockTriggers(Transform newBlock, params Transform[] triggerTransforms) {
        foreach (var triggerTransform in triggerTransforms) {
            triggerTransform.localScale = new Vector3(triggerWidth * (7 / newBlock.localScale.x), 0.1f, 1);
        }
    }

    private void ConstructBlock(GameObject newBlock) {
        
        newBlock.transform.localScale = new Vector3(Random.Range(blockWidthMin, blockWidthMax), 6, 1);

        var transform1 = transform;
        var position = transform1.position;

        newBlock.transform.position =
            new Vector3(position.x + transform1.localScale.x + newBlock.transform.localScale.x / 2, position.y, 0);
    }

    private void OnTriggerExit2D(Collider2D other) {
        SpawnBlock();
    }
}