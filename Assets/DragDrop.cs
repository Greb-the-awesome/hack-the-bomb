using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragDrop : MonoBehaviour
{

    public GameObject objectToDrag;
    public GameObject ObjectDragToPos;

    public float DropDistance;

    public bool isLocked;

    Vector2 objectInitPos;
    // Start is called before the first frame update
    void Start()
    {
        objectInitPos = objectToDrag.transform.position;
Cursor.lockState = CursorLockMode.None;

    }

    public void DragObject()
    {
        if (!isLocked)
        {Cursor.lockState = CursorLockMode.None;
            objectToDrag.transform.position = Input.mousePosition;
        }Cursor.lockState = CursorLockMode.None;
    }

    public void DropObject()
    {
        Cursor.lockState = CursorLockMode.None;
        float Distance = Vector3.Distance(objectToDrag.transform.position, ObjectDragToPos.transform.position);
        if (Distance < DropDistance)
        {
            isLocked = true;
            objectToDrag.transform.position = ObjectDragToPos.transform.position;
            FinishChecker a = GameObject.Find("PUZZLEONE").GetComponent<FinishChecker>();
            a.numFinished++;
            a.check();

        }
        else
        {
            objectToDrag.transform.position = objectInitPos;
        }

    }

}
