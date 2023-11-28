using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MouseStuff : MonoBehaviour
{
    public Tilemap tM;
    public Tilemap atM;
    public FloodFill fF;
   public Djztrack Dj;    
    public Heurística He;
    public AShootingStar ST;
    public Tile tile1; //tileStart
    public Tile tileJimmyM; //tileEnd
    public Tile tileFill;
    public Vector3Int _start;
    public Vector3Int _end;
    public bool startSet=false;
    public Vector3 offsetGrid = new Vector3(0, -0.11f, 0);
    public string collisionTag = "Nave";

    private void Update()
    {
        var mousePos = transform.GetComponent<Camera>().ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));
        var location = tM.WorldToCell(mousePos);
        location.z = 0;
                
        //Pongo el inicio
        if (tM.GetSprite(location)!=null&&startSet!=true)
        {
            if (_start != location && tM.GetSprite(location) != null)
            {
                atM.SetTile(_start, tileFill);
            }

            atM.SetTile(location, tileJimmyM);
            _start = location;

            //Click para dar inicio
            if (Input.GetMouseButtonDown(0) && tM.GetSprite(location) != null)
            {
                Collider2D collider = Physics2D.OverlapPoint(mousePos);
                if (collider != null && collider.CompareTag(collisionTag))
                {
                    if (_start != location)
                    {
                        // Debug.Log(location + "Origen");
                        fF.startingPoint = location;
                        Dj.startingPoint = location;
                        He.startingPoint = location;
                        ST.startingPoint = location;
                        // Dj.tileCord = location;

                        startSet = true;
                    }
                      
                }
                   
            }
          

        }


        //Pongo el final
        if (tM.GetSprite(location) != null&&startSet==true)
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

        }


        //POner otra cosa
        /*if(Input.GetButtonDown("Fire1") && startSet == true)
        {
            startSet = false;
            Debug.Log("Aña");
        }*/

    }
}
