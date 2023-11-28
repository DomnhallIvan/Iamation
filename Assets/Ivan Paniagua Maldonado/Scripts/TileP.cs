using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileP : MonoBehaviour
{
    public Tilemap tmBackground;
    public Tilemap tmArea;
    public TileBase Tb1;
    public TileBase Tb2;
    public TileBase Tb3;
    public DijkstraLimit _dL;
    private Vector3Int previousStart;
    public Vector3Int _location;
    public Vector3 offsetGrid = new Vector3(0, -0.11f, 0);
    public string collisionTag = "Nave";

    void Update()
    {
        var cam = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));
        _location = tmBackground.WorldToCell(cam);
        _location.z = 0;

        if (Input.GetMouseButtonDown(0))
        {
           // Debug.Log("Inicio Seleccionado " + "<color=#00ff00ff>" + _location + previousStart + "</color>");

            Collider2D collider = Physics2D.OverlapPoint(cam);
            if (collider != null && collider.CompareTag(collisionTag))
            {
                Debug.Log("Inicio Seleccionado " + "<color=#00ff00ff>" + _location + previousStart + "</color>");

                if (previousStart != _location)
                {
                    Debug.Log("Nueva ubicación");
                    _dL.start = _location;
                    tmArea.ClearAllTiles();
                    tmArea.SetTile(_location, Tb1);
                    Matrix4x4 matrix = Matrix4x4.TRS(offsetGrid, Quaternion.Euler(0f, 0f, 0f), Vector3.one);
                    tmArea.SetTransformMatrix(_location, matrix);
                    _dL.RestartDictionary();
                    Debug.Log(_dL.Movements);
                    StartCoroutine(_dL.ExpandTilemap());

                    previousStart = _location;
                }
            }
        }
    }
}
