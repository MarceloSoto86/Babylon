using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BuildingContainer : MonoBehaviour
{
    public GameObject[] buildingPrefabs;
    public GameObject ghostBuildingPrefab;
    private GameObject ghostBuilding;
    private GameObject selectedBuildingPrefab;
    private bool isBuilding = false;

    void Update()
    {
        // Check if the user clicked the mouse button
        if (Input.GetMouseButtonDown(0))
        {
            // Check if there is a ghost building
            if (ghostBuilding != null)
            {
                // Check if the ghost building is colliding with another building
                //if (ghostBuilding.GetComponent<Collider>().bounds.Intersects(GetComponentInChildren<BuildingManager>().GetBuildingBounds()))
                {
                    Debug.Log("Can't build here! Another building is in the way.");
                    return;
                }

                // Place the building in the world and remove the ghost building
                Instantiate(selectedBuildingPrefab, ghostBuilding.transform.position, ghostBuilding.transform.rotation);
                Destroy(ghostBuilding);
                isBuilding = false;
            }
            else
            {
                // Check if the user clicked on a building button
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out hit))
                {
                    for (int i = 0; i < buildingPrefabs.Length; i++)
                    {
                        if (hit.transform.gameObject == buildingPrefabs[i])
                        {
                            // Set the selected building prefab and create a ghost building
                            selectedBuildingPrefab = buildingPrefabs[i];
                            ghostBuilding = Instantiate(ghostBuildingPrefab);
                            isBuilding = true;
                            break;
                        }
                    }
                }
            }
        }

        // Move the ghost building to the mouse position
        if (ghostBuilding != null)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                ghostBuilding.transform.position = hit.point;
            }
        }
    }
}