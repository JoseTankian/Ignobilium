using UnityEngine;
using System.Collections;

public class DragAndDrop : MonoBehaviour {

    private Vector3 offset;

    void OnMouseDown()
    {
        Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
        offset = transform.position - Camera.main.ScreenToWorldPoint(mousePos);
        Debug.Log("Down");
    }

    void OnMouseDrag()
    {
        Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
        transform.position = Camera.main.ScreenToWorldPoint(mousePos) + offset;
        Debug.Log("Drag");
    }
}
