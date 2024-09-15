using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class CameraScript : MonoBehaviour
{
    public Rigidbody rb;
    public float playerSpeed;
    public Vector3 cameraFront;
    private Vector3 cameraUp;
    public float tickTimer;
    public float tickSpeed;
    public float secondsLeft;
    public GameObject timer;
    public TextMeshProUGUI prompt, remainingDisplay;
    private List<BoxCollider> colliders;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Camera script");
        Keys.Start();
        playerSpeed = 50.0f;
        cameraFront = new Vector3(0.0f, 0.0f, 1.0f);
        cameraUp = new Vector3(0.0f, 1.0f, 0.0f);
        tickTimer = 0.0f;
        tickSpeed = 0.5f;
        Application.targetFrameRate = 60; // to stop it from running at 400fps
        rb.position = Vector3.zero;
        colliders = new List<BoxCollider>();
        colliders.Add(GameObject.Find("puzzle hb 1").GetComponent<BoxCollider>());
        colliders.Add(GameObject.Find("puzzle hb 2").GetComponent<BoxCollider>());
        colliders.Add(GameObject.Find("puzzle hb 3").GetComponent<BoxCollider>());
        colliders.Add(GameObject.Find("bomb hb").GetComponent<BoxCollider>());

        if (Stats.puzzlesDone == 0) {
            remainingDisplay.text = "Dynamite sticks defused: 0";
        } else if (Stats.puzzlesDone == 1) {
            remainingDisplay.text = "Dynamite sticks defused: 3";
        } else if (Stats.puzzlesDone == 1) {
            remainingDisplay.text = "Dynamite sticks defused: 5";
        } else {
            remainingDisplay.text = "Dynamite sticks defused: 7";
            SceneManager.LoadScene("EndingWinCutScene");
        }
        secondsLeft = Stats.timeRemaining;
    }

    // Update is called once per frame
    void Update()
    {
        Stats.timeRemaining = secondsLeft;
        if (Stats.puzzlesDone == 0) {
            remainingDisplay.text = "Dynamite sticks defused: 0";
        } else if (Stats.puzzlesDone == 1) {
            remainingDisplay.text = "Dynamite sticks defused: 3";
        } else if (Stats.puzzlesDone == 2) {
            remainingDisplay.text = "Dynamite sticks defused: 5";
        } else {
            remainingDisplay.text = "Dynamite sticks defused: 7";
        }
        rb.velocity = new Vector3(0.0f, 0.0f, 0.0f);
        Keys.Update();
        rb.position = PlayerScript.player.rb.position + new Vector3(0.0f, 1.0f, 0.0f);
        transform.eulerAngles = PlayerScript.player.cameraEulerAngles;

        if (tickTimer > tickSpeed) {
            tickTimer = 0;
            Tick();
        }
        secondsLeft -= Time.deltaTime;
        tickTimer += Time.deltaTime;
        timer.GetComponent<TimerScript>().UpdateTimer((int)secondsLeft);

        // do the raycast and similar
        RaycastHit h;
        if (Physics.Raycast(rb.position, -PlayerScript.player.cameraFront, out h, 5.0f) && h.collider.isTrigger) {
            prompt.text = "F to interact";
            if (Input.GetKeyDown(KeyCode.F)) {
                if (h.collider == colliders[3]) {
                    Stats.playerInitialPos = PlayerScript.player.rb.position;
                    Stats.useInitialPos = true;
                    Cursor.lockState = CursorLockMode.None;
                    SceneManager.LoadScene("CodeEnterScene");
                    return;
                } else if (h.collider == colliders[0]) {
                    Stats.playerInitialPos = PlayerScript.player.rb.position;
                    Cursor.lockState = CursorLockMode.None;
                    Stats.useInitialPos = true;
                    SceneManager.LoadScene("PuzzleScene");
                    return;
                } else if (h.collider == colliders[1]) {
                    Stats.playerInitialPos = PlayerScript.player.rb.position;
                    Cursor.lockState = CursorLockMode.None;
                    Stats.useInitialPos = true;
                    SceneManager.LoadScene("Puzzle2");
                    return;
                } else if (h.collider == colliders[2]) {
                    Stats.playerInitialPos = PlayerScript.player.rb.position;
                    Cursor.lockState = CursorLockMode.None;
                    Stats.useInitialPos = true;
                    SceneManager.LoadScene("Puzzle2");
                    return;
                }
            }
        } else {
            prompt.text = "";
        }
    }
    void Tick() {
        //
    }
}
