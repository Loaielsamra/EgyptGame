using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemy : EnemyController
{
    public float HorizzontalSpeed;
    public float VerticalSpeed;
    public float amplitude;
    private Vector3 temp_position;
    public float moveSpeed;
    private PlayerController player;

    // Start is called before the first frame update
    void Start()
    {
        temp_position = transform.position;
    }


    void FixedUpdate()
    {
        temp_position.x += HorizzontalSpeed;
        temp_position.y = Mathf.Sin(Time.realtimeSinceStartup * VerticalSpeed) * amplitude;
        transform.position = temp_position;
        temp_position.y += VerticalSpeed;
        temp_position.x = Mathf.Sin(Time.realtimeSinceStartup * HorizzontalSpeed) * amplitude;
        transform.position = temp_position;
       

    }



}
