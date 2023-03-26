using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;



public class BuildingManager : MonoBehaviour
{
    public static BuildingManager current;

    public GameObject[] buildings;
    public GameObject pendingObject;

    private Vector3 posBuilding;
    
    private RaycastHit rcHit;
    [SerializeField] LayerMask layerMask;
    [SerializeField] private Toggle gridToggle;
    //[SerializeField] private Material[] materials;

    private float maxDistanceRay = 10000;
    public float gridSize;
    public float rotateAmount;

    bool gridOn = true;
    public bool canPlace = true;


    void Start()
    {
        
    }

    private void FixedUpdate()
    {

        //This creates a raycast and stores the hit value as the new Building position based on mouse position

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //Ray ray = Camera.main.ScreenPointToRay(mouse.current.position.ReadDefaultValue());
        if (Physics.Raycast(ray, out rcHit, maxDistanceRay,layerMask)) // RaycastHit raycastHit))
        {
            posBuilding = rcHit.point;
        }
    }
    void Update()
    {
       

        if (pendingObject!= null)
        {

            if(gridOn)
            {
                pendingObject.transform.position = new Vector3(
                RoundToNearestGrid(posBuilding.x), RoundToNearestGrid(posBuilding.y + 15.5f),RoundToNearestGrid(posBuilding.z));
                 

            }
            else 
            { 
                pendingObject.transform.position = posBuilding; 
            }

           // updateMaterials();

            if (Input.GetMouseButton(0) && canPlace)
            {
             
                PlaceObject();
            }
           

            if(Input.GetKeyDown(KeyCode.R)) 
            {
                RotateObject();
            }

            


        }
    }


    /*void updateMaterials()
    {

        //When gets the component of the appending object mesh renderer, sets the material to be materials zero index if you can place it
        if (canPlace)
        {
            pendingObject.GetComponent<MeshRenderer>().material = materials[0];
        }

        if (!canPlace)
        {
            pendingObject.GetComponent<MeshRenderer>().material = materials[1];
        }*/

    //}
    void PlaceObject()
    {

        //pendingObject.GetComponent<MeshRenderer>().material = materials[2];
        pendingObject = null;
    }

    

    public void SelectBuilding(int index)
    {
        pendingObject = Instantiate(buildings[index], posBuilding, transform.rotation);
    }

    public void RotateObject()
    {
        pendingObject.transform.Rotate(Vector3.up, rotateAmount);
    }

    public void ToggleGrid()
    {
        if(gridToggle.isOn)
        {
            gridOn = true;
        }
        else
        {
            gridOn = false;
        }
    }

    float RoundToNearestGrid(float pos)
    {
        float xDiff = pos % gridSize;
        pos -= xDiff;

        if(xDiff > (gridSize / 2))
        {
            pos += gridSize;
        }
        return pos;
    }

 
}
