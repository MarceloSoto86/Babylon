using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RTSBuildingMgr : MonoBehaviour
{
    [SerializeField] private GameObject _placeHolderBuilding;
    private GameObject _placeholder;

    [SerializeField] private GameObject _building;
    [SerializeField] private float _snapSize = 1f;
    [SerializeField] private Toggle _gridToggle;

    

    private Vector3 _mousePosition;

    private float _previousX;
    private float _previousZ;
    public float _gridSize = 100f;

    private RTSPlaceholder _buildingScript;

    

    public float rotateAmount;

    bool gridOn = true;
    


    private void Start()
    {
        _placeholder = Instantiate(_placeHolderBuilding);
        _buildingScript = _placeholder.GetComponent<RTSPlaceholder>();

        // Se agrega un listener al evento onValueChanged del botón de Toggle
        _gridToggle.onValueChanged.AddListener(OnGridToggle);
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

            if (gridOn) // Si el Grid snap está activado
            {
                // Se redondea la posición a múltiplos del _snapSize
                positionX = Mathf.Round(positionX / _snapSize) * _snapSize;
                positionZ = Mathf.Round(positionZ / _snapSize) * _snapSize;

                _placeholder.transform.position = new Vector3(positionX, 15f, positionZ);
            }

/*
            if (_previousX != positionX || _previousZ != positionZ)
            {
                _previousX = positionX;
                _previousZ = positionZ;

              

                _placeholder.transform.position = new Vector3(positionX, 15f, positionZ);
            }*/

            if (Input.GetMouseButtonUp(0))
            {
               
                if (_buildingScript.isBuildable)
                {
                    Instantiate(_building, _placeholder.transform.position, Quaternion.identity);
                }

            }
        }

    }


    public void OnGridToggle(bool value)
    {
        if(_gridToggle.isOn)
        {

        gridOn = true;

        }
        else
        {
            gridOn= false;
        }
    }

    float RoundToNearestGrid(float pos)
    {
        float xDiff = pos % _gridSize;
        pos -= xDiff;
        if(xDiff >(_gridSize /2))
        {
            pos += _gridSize;
        }
        return pos;
    }


}
