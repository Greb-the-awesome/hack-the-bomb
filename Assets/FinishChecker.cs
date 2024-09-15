using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishChecker : MonoBehaviour
{
    public int numFinished = 0;
    public int numNeeded;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void check() {
        if (numFinished == numNeeded) {
            SceneManager.LoadScene("proto1");
        }
    }
}
