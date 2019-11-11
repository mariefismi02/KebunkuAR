using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtObject : MonoBehaviour
{

    public Transform lookAtObject;

    // Update is called once per frame
    void Update()
    {
        if (lookAtObject) {
            Vector3 directionToTarget = lookAtObject.position - transform.position;
            transform.rotation = Quaternion.LookRotation(-directionToTarget, this.lookAtObject.up);
        }
    }
}
