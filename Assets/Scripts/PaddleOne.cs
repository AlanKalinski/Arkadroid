using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleOne : MonoBehaviour {

    public float paddleSpeed = 1f;
    private Vector3 paddlePosition = new Vector3(0, -14.5f, 0);

    void Start() {

    }

    void Update()
    {
        float xPos = transform.position.x + (Input.GetAxis("Horizontal_One") * paddleSpeed);
        paddlePosition = new Vector3(Mathf.Clamp(xPos, -8f, 8f), -14.5f, 0f);
        transform.position = paddlePosition;
    }

}
