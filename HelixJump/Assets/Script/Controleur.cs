using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Controleur : MonoBehaviour
{
    Vector3 dragStartPos;
    Vector3 dragEndPos;
    bool isDragging;
    public float rotationSpeed = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            dragStartPos = Input.mousePosition;
            isDragging = true;
        }

        if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;
        }

        if (isDragging)
        {
            dragEndPos = Input.mousePosition;

            Vector3 dragDelta = dragEndPos - dragStartPos;

            float rotationAmount = dragDelta.x * rotationSpeed * Time.deltaTime;

            transform.Rotate(Vector3.up, rotationAmount);

            dragStartPos = dragEndPos;
        }
    }
}
