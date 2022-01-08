using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public Transform player;
    public float minDistance = 1.5f;
    public NavMeshAgent agent;

    // Update is called once per frame
    void Update()
    {
        if ((transform.position - player.position).magnitude <= minDistance)
        {
            agent.SetDestination(player.position);
            Debug.Log("FOUND PLAYER");
        }
        else if (!agent.hasPath)
        {            
            agent.SetDestination(new Vector3(UnityEngine.Random.Range(466, 523), 20, UnityEngine.Random.Range(505, 536)));
        }

    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Door_left")
        {
            onposleft = true;
        }
        else if (other.gameObject.tag == "Door_right")
        {
            onposleft = false;
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if(collision.collider.tag == "Door")
        {
            // Give the object that was hit the name 'Door'
            GameObject Door = collision.gameObject;

            // Get access to the 'Door' script attached to the object that was hit
            DoorRotationLite dooropening = Door.GetComponent<DoorRotationLite>();

            if (dooropening.IsClosed)
            {
                if (onposleft)
                {
                    dooropening.RotationAngle = -90;
                }
                else
                {
                    dooropening.RotationAngle = 90;
                }
            }

            if (dooropening.RotationPending == false) StartCoroutine(collision.collider.GetComponent<DoorRotationLite>().Move());
        }
        if(collision.collider.tag == "Wand")
        {
            agent.SetDestination(new Vector3(UnityEngine.Random.Range(466, 523), 20, UnityEngine.Random.Range(505, 536)));
        }
    }
    bool onposleft = false;
}
