﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    private float speed;
    private Vector2 movementDirection;
    private Vector2 inputVector;

    private void Start() {
        movementDirection = Vector2.zero;
        speed = 1.0f;
    }

    private void Update() {
        move();
    }

    public void SetInputVector(Vector2 direction) {
        inputVector = direction;
    }

    private void move() {
        Vector3 translation = new Vector3(inputVector.x, inputVector.y, 0.0f) * speed * Time.deltaTime * TimeManager.getTimeFlow();
        transform.position += translation;
        return;
    }
}