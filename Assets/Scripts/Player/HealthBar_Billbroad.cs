using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class HealthBar_Billbroad : MonoBehaviour
{
    public GameObject cam;

    private void Awake()
    {
        cam = GameObject.FindGameObjectWithTag("MainCamera");
    }

    void LateUpdate()
    {
        transform.LookAt(transform.position + cam.transform.forward);
    }
}
