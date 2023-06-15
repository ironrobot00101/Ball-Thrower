
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMover : MonoBehaviour
{
    private float mouseX;
    public GameObject ballPrefab;
    public Transform ballSpawnPoint;
    public float movementSpeed = 1f;
    public float boundaryMin = -0.4f;
    public float boundaryMax = 0.4f;
    private float clickTime;
    private void Update()
    {
        mouseX = Input.GetAxis("Mouse X");

        // Move the character based on mouse input
        Vector3 movement = new Vector3(-4.38f, 10.54f, mouseX) * movementSpeed * Time.deltaTime;
        transform.position += movement;

        // Clamp the character's position within boundaries
        float clampedZ = Mathf.Clamp(transform.position.z, boundaryMin, boundaryMax);
        transform.position = new Vector3(-4.38f, 10.54f, clampedZ);

        // Spawn a ball when the mouse button is clicked
           if (Input.GetMouseButtonDown(0))
        {
            clickTime = Time.time; // Record the time when the mouse button was clicked
        }

        if (Input.GetMouseButtonUp(0))
        {
            float holdDuration = Time.time - clickTime; // Calculate the duration of mouse button hold
            float forceMagnitude = holdDuration * 10000f; // Adjust the multiplier to control the force applied
            GameObject ball = Instantiate(ballPrefab, ballSpawnPoint.position, Quaternion.identity);
            Rigidbody ballRigidbody = ball.GetComponent<Rigidbody>();
            ballRigidbody.AddForce(Vector3.right * forceMagnitude);
        }
    }
}


