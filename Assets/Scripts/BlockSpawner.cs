using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawner : MonoBehaviour {
    private BlockConstructor constructor;

    private void Start() {
        constructor = GetComponentInParent<BlockConstructor>();
    }

    private void OnTriggerExit2D(Collider2D other) {
        constructor.SpawnBlock();
    }
}