using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    public Transform playerPos;
    public float CameraOffset;


    public void Update()
    {
        Vector3 val = transform.position;
        val.z = playerPos.transform.position.z + CameraOffset;
        transform.position = val;
    }

}
