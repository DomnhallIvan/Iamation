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


       
        
           // Debug.Log("Inicio Seleccionado " + "<color=#00ff00ff>" + _location + previousStart + "</color>");

            Collider2D collider = Physics2D.OverlapPoint(mousePos);
            if (collider != null && collider.CompareTag(collisionTag))
            {
                //Debug.Log("Inicio Seleccionado " + "<color=#00ff00ff>" + _location + previousStart + "</color>");
                if (Input.GetMouseButtonDown(0))
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

        if (tM.GetSprite(location) != null && startSet == true)
        {
            if (_end != location && tM.GetSprite(location) != null)
            {
                atM.SetTile(_end, tileFill);
                //atM.ClearAllTiles();
                //fF.SetTile(_end, tileFill);
            }
            Debug.Log(location);
            atM.SetTile(location, tileFill);
            _end = location;

        }



        /*
        //Pongo el inicio cuando ya haya dado click
        if (tM.GetSprite(location) != null && startSet != true)
        {
            if (_start != location && tM.GetSprite(location) != null)
            {
                atM.SetTile(_start, tileFill);
            }

            atM.SetTile(location, tileJimmyM);
            _start = location;


            if (Input.GetMouseButtonDown(1) && tM.GetSprite(location) != null)
            {
                // Debug.Log(location + "Origen");
                // fF.startingPoint = location;
                //Dj.startingPoint = location;
                //He.startingPoint = location;
                DjMz.startingPoint = location;
                // Dj.tileCord = location;

                startSet = true;
            }
        }




        //Pongo el final
        if (tM.GetSprite(location) != null && startSet == true)
        {
            if (_end != location && tM.GetSprite(location) != null)
            {
                atM.SetTile(_end, tileFill);
                atM.ClearAllTiles();
                //fF.SetTile(_end, tileFill);
            }
            Debug.Log(location);
            atM.SetTile(location, tile1);
            _end = location;

        }*/


        //POner otra cosa
        /*if(Input.GetButtonDown("Fire1") && startSet == true)
        {
            startSet = false;
            Debug.Log("Aña");
        }*/

    }
}
