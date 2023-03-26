using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckBuildPlaceMgr : MonoBehaviour
{
    BuildingManager buildingManager;

    private int _collisionHit = 0;

    void Start()
    {
        buildingManager = GameObject.Find("BuildingManager").GetComponent<BuildingManager>();
    }


    private void FixedUpdate()
    {
        if (_collisionHit > 0)
        {
            buildingManager.canPlace = false;
            buildingManager.pendingObject.GetComponent<MeshRenderer>().material.SetColor("_Color", Color.red);
        }
        else
        {
            buildingManager.canPlace = true;
            buildingManager.pendingObject.GetComponent<MeshRenderer>().material.SetColor("_Color", Color.green);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        //if(other.gameObject.CompareTag("Ground"))
        if(other.gameObject.tag != "Ground") _collisionHit++;
        //{
            //buildingManager.canPlace = false;
        //}
    }

    private void OnTriggerExit(Collider other)
    {
        //if (other.gameObject.CompareTag("Ground"))
        if (other.gameObject.tag != "Ground") _collisionHit--;
        //{
           // buildingManager.canPlace = true;
        //}
    }
}
