using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class EarthquakeCoroutine : MonoBehaviour
{
    public Tilemap tm;
    public Tilemap sobreponer;
    public Tile tierra;
    public Vector3Int target;

    // Update is called once per frame
    void Update()
    {
        var algo = transform.GetComponent<Camera>().ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z));
        Vector3Int location = tm.WorldToCell(algo);
        target = location;

        if (tm.GetSprite(location) != null && Input.GetKeyDown(KeyCode.Z))
        {
            StartCoroutine(Terremoto());
            StartCoroutine(Terremoto2());            
        }

    }


    IEnumerator Terremoto()
    {

        for(int i = 1; i < 5; i++)
        {
            Matrix4x4 estado = Matrix4x4.TRS(new Vector3(0, .05f*i, 0), Quaternion.Euler(0, 0, 0), Vector3.one);
            sobreponer.SetTransformMatrix(target, estado);
            sobreponer.SetTile(target, tierra);
            sobreponer.SetTransformMatrix(target + new Vector3Int(2, -2, 0), estado);
            sobreponer.SetTile(target + new Vector3Int(2, -2, 0), tierra);
            sobreponer.SetTransformMatrix(target + new Vector3Int(-2, -2, 0), estado);
            sobreponer.SetTile(target + new Vector3Int(-2, -2, 0), tierra);
            sobreponer.SetTransformMatrix(target + new Vector3Int(-2, 2, 0), estado);
            sobreponer.SetTile(target + new Vector3Int(-2, 2, 0), tierra);
            sobreponer.SetTransformMatrix(target + new Vector3Int(2, 2, 0), estado);
            sobreponer.SetTile(target + new Vector3Int(2, 2, 0), tierra);
            sobreponer.SetTransformMatrix(target + new Vector3Int(0, 2, 0), estado);
            sobreponer.SetTile(target + new Vector3Int(0, 2, 0), tierra);
            sobreponer.SetTransformMatrix(target + new Vector3Int(0, -2, 0), estado);
            sobreponer.SetTile(target + new Vector3Int(0, -2, 0), tierra);
            sobreponer.SetTransformMatrix(target + new Vector3Int(-2, 0, 0), estado);
            sobreponer.SetTile(target + new Vector3Int(-2, 0, 0), tierra);
            sobreponer.SetTransformMatrix(target + new Vector3Int(2, 0, 0), estado);
            sobreponer.SetTile(target + new Vector3Int(2, 0, 0), tierra);
            sobreponer.SetTransformMatrix(target + new Vector3Int(-3, 3, 0), estado);
            yield return new WaitForSeconds(.1f);
        }

        StartCoroutine(TerremotoNegativo());
    }
    IEnumerator Terremoto2()
    {

        for (int i = 1; i < 5; i++)
        {
            Matrix4x4 estado = Matrix4x4.TRS(new Vector3(0, -.05f * i, 0), Quaternion.Euler(0, 0, 0), Vector3.one);
            sobreponer.SetTransformMatrix(target + new Vector3Int(-1, 1, 0), estado);
            sobreponer.SetTile(target + new Vector3Int(-1, 1, 0), tierra);
            sobreponer.SetTransformMatrix(target + new Vector3Int(-1, -1, 0), estado);
            sobreponer.SetTile(target + new Vector3Int(-1, -1, 0), tierra);
            sobreponer.SetTransformMatrix(target + new Vector3Int(1, -1, 0), estado);
            sobreponer.SetTile(target + new Vector3Int(1, -1, 0), tierra);
            sobreponer.SetTransformMatrix(target + new Vector3Int(1, 1, 0), estado);
            sobreponer.SetTile(target + new Vector3Int(1, 1, 0), tierra);
            sobreponer.SetTransformMatrix(target + new Vector3Int(-3, 3, 0), estado);
            sobreponer.SetTile(target + new Vector3Int(-3, 3, 0), tierra);
            sobreponer.SetTransformMatrix(target + new Vector3Int(-3, -3, 0), estado);
            sobreponer.SetTile(target + new Vector3Int(-3, -3, 0), tierra);
            sobreponer.SetTransformMatrix(target + new Vector3Int(3, -3, 0), estado);
            sobreponer.SetTile(target + new Vector3Int(3, -3, 0), tierra);
            sobreponer.SetTransformMatrix(target + new Vector3Int(3, 3, 0), estado);
            sobreponer.SetTile(target + new Vector3Int(3, 3, 0), tierra);
            yield return new WaitForSeconds(.1f);
        }

        StartCoroutine(TerremotoNegativo2());
    }
    IEnumerator TerremotoNegativo()
    {

        for (int i = 1; i < 5; i++)
        {
            Matrix4x4 estado = Matrix4x4.TRS(new Vector3(0, .25f - .05f * i, 0), Quaternion.Euler(0, 0, 0), Vector3.one);
            sobreponer.SetTransformMatrix(target, estado);
            sobreponer.SetTile(target, tierra);
            sobreponer.SetTransformMatrix(target + new Vector3Int(2, -2, 0), estado);
            sobreponer.SetTile(target + new Vector3Int(2, -2, 0), tierra);
            sobreponer.SetTransformMatrix(target + new Vector3Int(-2, -2, 0), estado);
            sobreponer.SetTile(target + new Vector3Int(-2, -2, 0), tierra);
            sobreponer.SetTransformMatrix(target + new Vector3Int(-2, 2, 0), estado);
            sobreponer.SetTile(target + new Vector3Int(-2, 2, 0), tierra);
            sobreponer.SetTransformMatrix(target + new Vector3Int(2, 2, 0), estado);
            sobreponer.SetTile(target + new Vector3Int(2, 2, 0), tierra);
            sobreponer.SetTransformMatrix(target + new Vector3Int(0, 2, 0), estado);
            sobreponer.SetTile(target + new Vector3Int(0, 2, 0), tierra);
            sobreponer.SetTransformMatrix(target + new Vector3Int(0, -2, 0), estado);
            sobreponer.SetTile(target + new Vector3Int(0, -2, 0), tierra);
            sobreponer.SetTransformMatrix(target + new Vector3Int(-2, 0, 0), estado);
            sobreponer.SetTile(target + new Vector3Int(-2, 0, 0), tierra);
            sobreponer.SetTransformMatrix(target + new Vector3Int(2, 0, 0), estado);
            sobreponer.SetTile(target + new Vector3Int(2, 0, 0), tierra);
            sobreponer.SetTransformMatrix(target + new Vector3Int(-3, 3, 0), estado);
            yield return new WaitForSeconds(.1f);
        }
    }
    IEnumerator TerremotoNegativo2()
    {

        for (int i = 1; i < 5; i++)
        {
            Matrix4x4 estado = Matrix4x4.TRS(new Vector3(0, -.25f + .05f * i, 0), Quaternion.Euler(0, 0, 0), Vector3.one);
            sobreponer.SetTransformMatrix(target + new Vector3Int(-1, 1, 0), estado);
            sobreponer.SetTile(target + new Vector3Int(-1, 1, 0), tierra);
            sobreponer.SetTransformMatrix(target + new Vector3Int(-1, -1, 0), estado);
            sobreponer.SetTile(target + new Vector3Int(-1, -1, 0), tierra);
            sobreponer.SetTransformMatrix(target + new Vector3Int(1, -1, 0), estado);
            sobreponer.SetTile(target + new Vector3Int(1, -1, 0), tierra);
            sobreponer.SetTransformMatrix(target + new Vector3Int(1, 1, 0), estado);
            sobreponer.SetTile(target + new Vector3Int(1, 1, 0), tierra);
            sobreponer.SetTransformMatrix(target + new Vector3Int(-3, 3, 0), estado);
            sobreponer.SetTile(target + new Vector3Int(-3, 3, 0), tierra);
            sobreponer.SetTransformMatrix(target + new Vector3Int(-3, -3, 0), estado);
            sobreponer.SetTile(target + new Vector3Int(-3, -3, 0), tierra);
            sobreponer.SetTransformMatrix(target + new Vector3Int(3, -3, 0), estado);
            sobreponer.SetTile(target + new Vector3Int(3, -3, 0), tierra);
            sobreponer.SetTransformMatrix(target + new Vector3Int(3, 3, 0), estado);
            sobreponer.SetTile(target + new Vector3Int(3, 3, 0), tierra);
            yield return new WaitForSeconds(.1f);
        }

        Limpiar();
    }

    void Limpiar()
    {
        sobreponer.ClearAllTiles();
    }


}
