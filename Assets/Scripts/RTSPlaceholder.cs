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

   // public GridManager gridManager;
   /* public float _gridSize = 10f; // Tama�o de cuadr�cula por defecto*/
   // private bool _isGridEnabled = false; // Indicador de si el grid est� habilitado o no


    private void Start()
    {
       // gridManager= GetComponent<GridManager>();
        _placeholderChecker = transform.Find("Placeholder Check").GetComponent<Renderer>();
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

        // Si el grid est� habilitado, redondea la posici�n del placeholder a la cuadr�cula
    /*    if (_isGridEnabled)
        {
            Vector3 position = _placeholderChecker.transform.position;
            float roundedX = Mathf.Round(position.x / _gridSize) * _gridSize;
            float roundedZ = Mathf.Round(position.z / _gridSize) * _gridSize;
            _placeholderChecker.transform.position = new Vector3(roundedX, position.y, roundedZ);
        }*/
    }

    // M�todo para cambiar el tama�o de la cuadr�cula
   /* public void SetGridSize(float size)
    {
        _gridSize = size;
    }*/

    // M�todo para habilitar o deshabilitar el grid
   /* public void ToggleGrid()
    {
        _isGridEnabled = !_isGridEnabled;
    }*/

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag != "Ground") _collisionHit++;
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag !="Ground") _collisionHit--;
        isBuildable = _collisionHit == 0;
    }


}

