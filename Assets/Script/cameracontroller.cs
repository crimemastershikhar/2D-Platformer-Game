using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameracontroller : MonoBehaviour
{
    //[SerializeField] 
    private Transform Target;
    private void Start()
    {
        Target = GameObject.Find("Cam").transform;
    }
    private void LateUpdate()
    {
        transform.position = new Vector3(Target.position.x, Target.position.y, transform.position.z);
    }
}
