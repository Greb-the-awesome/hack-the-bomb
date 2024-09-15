using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    public static int puzzlesDone = 0; // keep in mind that this is not actually the amount of puzzles done, it is the amount of codes entered into the bomb
    public static Vector3 playerInitialPos;
    public static bool useInitialPos = false;
    public static float timeRemaining = 600.0f;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        DontDestroyOnLoad(gameObject);
    }
}
