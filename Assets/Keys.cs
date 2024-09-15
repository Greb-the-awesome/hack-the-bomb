using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keys : MonoBehaviour
{
    static public bool lmfao = true;
    static public float mouseSensitivity = 2.0f;
    public static bool[] _downKeys = new bool[1000];
    public static Vector2 mouseDelta;
    public static void Start() {
        for (int i=0; i<1000; i++) {
            _downKeys[i] = false;
        }
    }
    public static bool downKeys(UnityEngine.KeyCode c) {
        return _downKeys[(int)c];
    }
    public static void Update() {
        for (UnityEngine.KeyCode i=KeyCode.Space; i<=KeyCode.Joystick8Button19; i++) {
            if (Input.GetKeyDown(i)) {
                _downKeys[(int)i] = true;
            }
        }
        for (UnityEngine.KeyCode i=KeyCode.Space; i<=KeyCode.Joystick8Button19; i++) {
            if (Input.GetKeyUp(i)) {
                _downKeys[(int)i] = false;
            }
        }
        mouseDelta = new Vector2(Input.GetAxis("Mouse X") * mouseSensitivity, Input.GetAxis("Mouse Y") * mouseSensitivity);
    }
}
