using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control : MonoBehaviour
{

    void OnMouseDrag()
    {
        Vector3 mousePosition = new Vector3(Input.mousePosition.x, 0);
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        transform.localPosition = new Vector3(mousePosition.x, 0);
    }
}
