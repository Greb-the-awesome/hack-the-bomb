using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody rb;
    public Vector3 cameraEulerAngles;
    public Vector3 cameraFront;
    public Vector3 cameraUp;
    public float playerSpeed;
    public static PlayerScript player;
    void Start()
    {
        cameraEulerAngles = new Vector3(0.0f, 0.0f, 0.0f);
        cameraFront = new Vector3(0.0f, 1.0f, 0.0f); // we would set it to the zero vector but that could cause issues with normalization
        // me eat booger chicken awajiba
        playerSpeed = 60.0f;
        cameraUp = new Vector3(0.0f, 1.0f, 0.0f);
        if (Stats.useInitialPos) {
            rb.position = Stats.playerInitialPos;
        }
        PlayerScript.player = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (Keys.downKeys(KeyCode.W)) {
            // float x = 10.0f;
            // rb.velocity = new Vector3(rb.velocity[0] + cameraFront[0]*x, rb.velocity[1] + cameraFront[1]*x, rb.velocity[2] + cameraFront[2]*x);
            rb.velocity -= cameraFront * playerSpeed * Time.deltaTime;
            // Debug.Log(rb.velocity);
        }
        if (Keys.downKeys(KeyCode.S)) {
            rb.velocity += cameraFront * playerSpeed * Time.deltaTime;
        }
        if (Keys.downKeys(KeyCode.D)) {
            rb.velocity += Vector3.Cross(cameraFront, cameraUp).normalized * playerSpeed * Time.deltaTime;
        }
        if (Keys.downKeys(KeyCode.A)) {
            rb.velocity -= Vector3.Cross(cameraFront, cameraUp).normalized * playerSpeed * Time.deltaTime;
        }
        if (Input.GetKeyDown(KeyCode.Space)) {
            rb.velocity += new Vector3(0.0f, 4.0f, 0.0f);
        }
        // rb.velocity = new Vector3(vels[0], vels[1], vels[2]);
        if (SceneManager.GetActiveScene().name == "proto1") {
            Cursor.lockState = CursorLockMode.Locked;
        } else {
            Cursor.lockState = CursorLockMode.None;
        }
        Vector3 rotateValue = new Vector3(Keys.mouseDelta[1], Keys.mouseDelta[0] * -1, 0);
        cameraEulerAngles = cameraEulerAngles - rotateValue;
        cameraEulerAngles += new Vector3(0.0f, 90.0f, 0.0f);
        cameraFront = new Vector3(Mathf.Cos(-cameraEulerAngles[1] * Mathf.PI / 180.0f) * Mathf.Cos(cameraEulerAngles[0] * Mathf.PI / 180.0f),
            Mathf.Sin(cameraEulerAngles[0] * Mathf.PI / 180.0f)*0,
            Mathf.Sin(-cameraEulerAngles[1] * Mathf.PI / 180.0f) * Mathf.Cos(cameraEulerAngles[0] * Mathf.PI / 180.0f));
        cameraEulerAngles -= new Vector3(0.0f, 90.0f, 0.0f);
        // Debug.Log(cameraFront);
        rb.angularVelocity = Vector3.zero;
        rb.freezeRotation = true;
    }
}
