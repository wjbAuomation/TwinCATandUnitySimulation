using Assets.Classes;
using Assets.Classes.Static;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sim_Tote : MonoBehaviour, iTote
{
    List<GameObject> collidingList = new List<GameObject>();    

    private void OnCollisionEnter(Collision collision)
    {
        collidingList.Add(collision.gameObject);
    }

    private void OnCollisionExit(Collision collision)
    {
        collidingList.Remove(collision.gameObject);
    }

    public void updatePosition(Vector3 position, GameObject controller)
    {
        foreach (GameObject collider in collidingList)
        {
            if (collider.name == Settings.ComponentTypes.Belt.ToString())
            {
                if (collider.transform.parent.name == controller.name)
                {
                    Rigidbody rb = this.gameObject.GetComponent<Rigidbody>();
                    rb.position += position;
                    rb.MovePosition(rb.position + position);
                }
                break;
            }
        }

    }
}
