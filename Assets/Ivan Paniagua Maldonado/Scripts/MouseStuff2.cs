using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using static UnityEditor.FilePathAttribute;

public class MouseStuff2 : MonoBehaviour
{
    public Tilemap tM;
    public Tilemap atM;
    public DjiztrakMezcla DjMz;
    //public FloodFill fF;
    //public Djztrack Dj;
    //public Heurística He;
    //public AShootingStar ST;
    public Tile tile1; //tileStart
    public Tile tileJimmyM; //tileEnd
    public Tile tileFill;
    public Vector3Int _start;
   // private Vector3Int previousStart;
    public Vector3Int _end;
    public bool startSet = false;

    public Vector3 offsetGrid = new Vector3(0, -0.11f, 0);
    public string collisionTag = "Nave";

    private void Update()
    {
        var mousePos = transform.GetComponent<Camera>().ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));
        var location = tM.WorldToCell(mousePos);
        location.z = 0;

           

        if (Input.GetMouseButtonDown(0))
        {
            Collider2D collider = Physics2D.OverlapPoint(mousePos);
            if (collider != null && collider.CompareTag(collisionTag))
            {
                //Debug.Log("Inicio Seleccionado " + "<color=#00ff00ff>" + _location + previousStart + "</color>");

                {
                    if (_start != location && tM.GetSprite(location) != null)
                    {
                        atM.SetTile(_start, tileFill);

                        atM.SetTile(location, tileJimmyM);

                        Debug.Log("Nueva ubicación");
                        DjMz.startingPoint = location;
                        atM.ClearAllTiles();
                        atM.SetTile(location, tile1);
                        Matrix4x4 matrix = Matrix4x4.TRS(offsetGrid, Quaternion.Euler(0f, 0f, 0f), Vector3.one);
                        atM.SetTransformMatrix(location, matrix);
                        DjMz.RestartDictionary();
                        //Debug.Log(_dL.Movements);
                        StartCoroutine(DjMz.DomainExpansion());

                        startSet = true;
                        _start = location;

                    }

                }

            }
        }
            // Debug.Log("Inicio Seleccionado " + "<color=#00ff00ff>" + _location + previousStart + "</color>");            
        if (atM.GetSprite(location) != null && startSet == true)
        {
            if (_end != location && tM.GetSprite(location) != null)
            {
                atM.SetTile(_end, tileFill);
                //atM.ClearAllTiles();
                //fF.SetTile(_end, tileFill);
            }
            //Debug.Log(location);
            atM.SetTile(location, tileFill);
            _end = location;

        }

    }

    private IEnumerator StartDomainExpansion()
    {
        // Ensure DjMz is not null
        if (DjMz == null)
        {
            Debug.LogError("DjMz is not assigned!");
            yield break;
        }

        while (true)
        {
            DjMz.RestartDictionary();
            yield return StartCoroutine(DjMz.DomainExpansion());

            // Optional delay between expansions
            yield return new WaitForSeconds(1f);
        }
    }

    public void StartExpansionLoop()
    {
        StartCoroutine(StartDomainExpansion());
    }
}
