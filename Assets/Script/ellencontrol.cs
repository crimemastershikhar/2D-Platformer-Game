using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ellencontrol : MonoBehaviour
{
    public Animator animator;

    private void Update()
    {
        float speed = Input.GetAxisRaw("Horizontal");
        animator.SetFloat("speed", Mathf.Abs(speed));
        Vector3 scale = transform.localScale;

        if(speed<0)
        {
            scale.x = -1 * Mathf.Abs(speed);
        }
        else if (speed>0)
        {
            scale.x = Mathf.Abs(speed);
        }
        transform.localScale = scale;
    }
    
}

