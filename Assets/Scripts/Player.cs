using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody m_Rigidbody;
    float m_Speed;
    
    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
        m_Speed = 10.0f;
    }
    
    public void MoveForward()
    {
        m_Rigidbody.velocity = transform.forward * m_Speed;
    }
    
    public void MoveBack()
    {
        m_Rigidbody.velocity = -transform.forward * m_Speed;
    }
}
