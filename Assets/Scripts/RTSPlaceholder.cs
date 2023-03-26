using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(BoxCollider))]
[RequireComponent(typeof(Rigidbody))]
public class RTSPlaceholder : MonoBehaviour
{
    public bool isBuildable = true;

    private int _collisionHit = 0;

    private Renderer _placeholderChecker;

    public enum BuildingType
    {
        BuildingA,
        BuildingB,
        BuildingC
    }

    public BuildingType buildingType;

    public Material buildingAMaterial;
    public Material buildingBMaterial;
    public Material buildingCMaterial;

    private void Start()
    {
     
        _placeholderChecker = transform.Find("Placeholder Check").GetComponent<Renderer>();
       
        switch (buildingType)
        {
            case BuildingType.BuildingA:
                _placeholderChecker.material = buildingAMaterial;
                break;
            case BuildingType.BuildingB:
                _placeholderChecker.material = buildingBMaterial;
                break;
            case BuildingType.BuildingC:
                _placeholderChecker.material = buildingCMaterial;
                break;
        }
    }

    public void FixedUpdate()
    {
        if (_collisionHit > 0)
        {
            isBuildable = false;
            _placeholderChecker.material.SetColor("_Color", Color.red);
        }
        else
        {
            isBuildable = true;
            _placeholderChecker.material.SetColor("_Color", Color.green);
        }
    
    }



    private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag != "Ground") _collisionHit++;
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.tag != "Ground") _collisionHit--;
            isBuildable = _collisionHit == 0;
        }
    }





