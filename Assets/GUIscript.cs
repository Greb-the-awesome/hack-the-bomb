using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUIscript : MonoBehaviour
{
    public CameraScript cam;
    public Text healthCounter;
    // Start is called before the first frame update
    void Start()
    {
        GameObject c = GameObject.Find("Main Camera");
        cam = c.GetComponent<CameraScript>();
    }

    // Update is called once per frame
    void Update()
    {
        // healthCounter.text = "Health: " + PlayerData.playerHealth.ToString();
    }
}
