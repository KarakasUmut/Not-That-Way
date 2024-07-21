using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform Target;

    public Vector3 offSet;


    private void Update()
    {
        transform.position = Vector3.Lerp(transform.position, Target.position + offSet, Time.deltaTime * 3);   
    }
}
