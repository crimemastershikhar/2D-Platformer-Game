 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    public float speed;
    public float distance;
    public Transform grounddetection;
    private bool movingright = true;

    private void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);

        RaycastHit2D groundInfo = Physics2D.Raycast(grounddetection.position, Vector2.down, distance);
        Debug.DrawRay(grounddetection.position, Vector2.down, Color.red);

        if (groundInfo.collider == false) 
        {
            if (movingright)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                movingright = false;
            }
            else if(!movingright)
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingright = true;
            }
        }
    }
}
