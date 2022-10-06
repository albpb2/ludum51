using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseCursorController : MonoBehaviour
{
    public Camera gameCamera;
    private void Start()
    {
        //Cursor.visible = false;
    }
    void Update()
    {
        Vector2 cursorPos = gameCamera.ScreenToViewportPoint(Input.mousePosition);
        gameObject.transform.position = cursorPos;

        Debug.Log("" + cursorPos);
    }
}
