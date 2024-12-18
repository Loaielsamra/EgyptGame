﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class CameraFollower : MonoBehaviour
{

    public Transform Target;
    public float Cameraspeed;

    public float minX, maxX;
    public float minY, maxY;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void FixedUpdate()
    {
        if (Target != null)
        {
            Vector2 newCamPosition = Vector2.Lerp(transform.position, Target.position, Time.deltaTime * Cameraspeed);
            float ClampX = Mathf.Clamp(newCamPosition.x, minX, maxX);
            float ClampY = Mathf.Clamp(newCamPosition.y, minY, maxY);
            transform.position = new Vector3(ClampX, ClampY, -10f);

        }

    }
}