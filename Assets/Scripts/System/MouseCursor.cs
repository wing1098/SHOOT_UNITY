using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseCursor : MonoBehaviour
{
    public Texture2D mouseCursor;

    void Start()
    {
        Cursor.SetCursor(mouseCursor, Vector2.zero, CursorMode.ForceSoftware);    
    }
    // Update is called once per frame
    void Update()
    {
    }
}
