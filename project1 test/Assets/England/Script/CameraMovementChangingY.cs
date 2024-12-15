using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovementChangingY : CameraMovement
{
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
        if (target != null)
        {
            Vector2 newCamPosition = Vector2.Lerp(transform.position, target.transform.position, CameraSpeed * Time.deltaTime);
            float ClampX = Mathf.Clamp(newCamPosition.x, minX, maxX);
            
            // Change minY value at a certain position
            if (ClampX >= 266.9252)
            {
                minY = 2;
            }
            else
            {
                minY = 8.3f;
            }
            float ClampY = Mathf.Clamp(newCamPosition.y, minY, maxY);
            transform.position = new Vector3(ClampX, ClampY, -10f);
        }
    }


}
