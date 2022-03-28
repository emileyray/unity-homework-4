using System;
using System.Collections;
using System.Collections.Generic;
using Factory;
using UnityEngine;

public class MovementController : MonoBehaviour
{ 
    void OnEnable()
    {
        MovementFactory.InitializeFactory();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            MovementFactory.GetMovement("forward").Process();
        }
        
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            MovementFactory.GetMovement("back").Process();
        }
    }
}
