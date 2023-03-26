using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RTSBuildingMgr : MonoBehaviour
{
    [SerializeField] private GameObject _placeHolderBuilding;
    private GameObject _placeholder;

    [SerializeField] private GameObject _building;

    private Vector3 _mousePosition;

    private float _previousX;
    private float _previousZ;

    private RTSPlaceholder _buildingScript;


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

                // Debug.Log(positionX + " / " + positionZ);

                _placeholder.transform.position = new Vector3(positionX, 15f, positionZ);
            }

            if (Input.GetMouseButtonUp(0))
            {
               // _buildingScript.FixedUpdate();

                //Instantiate(_building, _placeholder.transform.position, Quaternion.identity);

                if (_buildingScript.isBuildable)
                {
                    Instantiate(_building, _placeholder.transform.position, Quaternion.identity);
                }

            }
        }
    }
}
