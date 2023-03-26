using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RTSBuildingMgr : MonoBehaviour
{
    [SerializeField] private GameObject _placeHolderBuilding;
    private GameObject _placeholder;

    [SerializeField] private GameObject _building;
    [SerializeField] private Toggle gridToggle;

    private Vector3 _mousePosition;

    private float _previousX;
    private float _previousZ;

    private RTSPlaceholder _buildingScript;

    
    public float gridSize;
    public float rotateAmount;

    bool gridOn = true;


    private void Start()
    {
        _placeholder = Instantiate(_placeHolderBuilding);
        _buildingScript = _placeholder.GetComponent<RTSPlaceholder>();
    }

    private void Update()
    {
        _mousePosition = Input.mousePosition;

        Ray ray = Camera.main.ScreenPointToRay(_mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            float positionX = hit.point.x;
            float positionZ = hit.point.z;

            if (_previousX != positionX || _previousZ != positionZ)
            {
                _previousX = positionX;
                _previousZ = positionZ;

              

                _placeholder.transform.position = new Vector3(positionX, 15f, positionZ);
            }

            if (Input.GetMouseButtonUp(0))
            {
               
                if (_buildingScript.isBuildable)
                {
                    Instantiate(_building, _placeholder.transform.position, Quaternion.identity);
                }

            }
        }
    }

    public void ToggleGrid()
    {
        if (gridToggle.isOn)
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

        if (xDiff > (gridSize / 2))
        {
            pos += gridSize;
        }
        return pos;
    }
}
