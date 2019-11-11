using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour
{

    [SerializeField] float rotationSpeed;
 
    // Update is called once per frame
    void Update()
    {
        //Rotate Around
        transform.Rotate(Vector3.up * rotationSpeed);
    }
}
