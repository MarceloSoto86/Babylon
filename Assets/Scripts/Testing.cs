using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;


public class Testing : MonoBehaviour
{
    private float cellSize = 10;
    private Grid grid;


    //private Grid gridScript;
    private void Start()
    {
       // gridScript= GetComponent<Grid>();
        Grid grid = new Grid(4, 2, 10f); 
    }


    // Get Mouse Position in world with Z = 0f
    public static Vector3 GetMouseWorldPosition()
    {
        Vector3 vec = GetMouseWorldPositionWithZ(Input.mousePosition, Camera.main);
        vec.z = 0f;
        return vec;
    }


    
    public static Vector3 GetMouseWorldPositionWithZ()
    {
        return GetMouseWorldPositionWithZ(Input.mousePosition, Camera.main);
    }

    public static Vector3 GetMouseWorldPositionWithZ(Camera worldCamera)
    {
        return GetMouseWorldPositionWithZ(Input.mousePosition, worldCamera);
    }

    public static Vector3 GetMouseWorldPositionWithZ(Vector3 screenPosition,Camera worldCamera)
    {
        Vector3 worldPosition = worldCamera.ScreenToWorldPoint(screenPosition);
        return worldPosition;   
    }
    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            grid.SetValue(GetMouseWorldPosition(), 56);
        }
    }
}
