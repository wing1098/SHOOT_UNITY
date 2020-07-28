using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropLoopFollow : MonoBehaviour
{
    bool _isFollowing = false;
    
    public Transform target;

    public float minModifter = 7f;
    public float maxModifter = 11f;

    Vector3 _velocity = Vector3.zero;

    public void StartFollowing()
    {
        _isFollowing = true; 
    }

    void Update()
    {
        if(_isFollowing)
        {
            transform.position = Vector3.SmoothDamp(transform.position, target.position, ref _velocity, Time.deltaTime * Random.Range(minModifter, maxModifter));
        }
    }
}
