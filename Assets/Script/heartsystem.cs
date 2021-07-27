using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class heartsystem : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        gamecontrol.health += 1;
    }

}
