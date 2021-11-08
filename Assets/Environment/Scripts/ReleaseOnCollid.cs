using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReleaseOnCollid : MonoBehaviour
{
    Rigidbody m_Rigidbody;
    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();

    }
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Player")
        {
            m_Rigidbody.constraints = RigidbodyConstraints.None;
        }
    }
}
