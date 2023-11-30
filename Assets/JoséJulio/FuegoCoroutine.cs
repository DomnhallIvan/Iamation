using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class FuegoCoroutine : MonoBehaviour
{
    public Tilemap tm;
    public Tilemap sobreponer;
    public Tile fuego;
    public Tile fuego2;
    public Tile fuego3;
    public Vector3Int target;

    // Update is called once per frame
    void Update()
    {
        var algo = transform.GetComponent<Camera>().ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z));
        Vector3Int location = tm.WorldToCell(algo);
        target = location;

        if (tm.GetSprite(location) != null && Input.GetKeyDown(KeyCode.V))
        {
            StartCoroutine(Fuego1());
            StartCoroutine(Fuego2());
            StartCoroutine(Fuego3());
        }

    }
    IEnumerator Fuego1()
    {
        for (int i = 1; i < 10; i++)
        {
            Matrix4x4 estado = Matrix4x4.TRS(new Vector3(0, .1f * i, 0), Quaternion.Euler(0, 10 * i, 0), Vector3.one);
            sobreponer.SetTransformMatrix(target, estado);
            sobreponer.SetTile(target, fuego);
            yield return new WaitForSeconds(.1f);
        }
    }

    IEnumerator Fuego2()
    {
        for (int i = 1; i < 10; i++)
        {
            Matrix4x4 estado = Matrix4x4.TRS(new Vector3(0, .2f * i, 0), Quaternion.Euler(0, 20 * i, 0), Vector3.one);
            sobreponer.SetTransformMatrix(target + new Vector3Int(1, 0, 0), estado);
            sobreponer.SetTile(target + new Vector3Int(1, 0, 0), fuego2);
            sobreponer.SetTransformMatrix(target + new Vector3Int(-1, 0, 0), estado);
            sobreponer.SetTile(target + new Vector3Int(-1, 0, 0), fuego2);
            sobreponer.SetTransformMatrix(target + new Vector3Int(0, 1, 0), estado);
            sobreponer.SetTile(target + new Vector3Int(0, 1, 0), fuego2);
            sobreponer.SetTransformMatrix(target + new Vector3Int(0, -1, 0), estado);
            sobreponer.SetTile(target + new Vector3Int(0, -1, 0), fuego2);
            yield return new WaitForSeconds(.1f);
        }
    }

    IEnumerator Fuego3()
    {
        for (int i = 1; i < 10; i++)
        {
            Matrix4x4 estado = Matrix4x4.TRS(new Vector3(0, .3f * i, 0), Quaternion.Euler(0, 30 * i, 0), Vector3.one);
            sobreponer.SetTransformMatrix(target + new Vector3Int(2, 0, 0), estado);
            sobreponer.SetTile(target + new Vector3Int(2, 0, 0), fuego3);
            sobreponer.SetTransformMatrix(target + new Vector3Int(-2, 0, 0), estado);
            sobreponer.SetTile(target + new Vector3Int(-2, 0, 0), fuego3);
            sobreponer.SetTransformMatrix(target + new Vector3Int(0, 2, 0), estado);
            sobreponer.SetTile(target + new Vector3Int(0, 2, 0), fuego3);
            sobreponer.SetTransformMatrix(target + new Vector3Int(0, -2, 0), estado);
            sobreponer.SetTile(target + new Vector3Int(0, -2, 0), fuego3);
            sobreponer.SetTransformMatrix(target + new Vector3Int(1, 1, 0), estado);
            sobreponer.SetTile(target + new Vector3Int(1, 1, 0), fuego3);
            sobreponer.SetTransformMatrix(target + new Vector3Int(-1, 1, 0), estado);
            sobreponer.SetTile(target + new Vector3Int(-1, 1, 0), fuego3);
            sobreponer.SetTransformMatrix(target + new Vector3Int(1, -1, 0), estado);
            sobreponer.SetTile(target + new Vector3Int(1, -1, 0), fuego3);
            sobreponer.SetTransformMatrix(target + new Vector3Int(-1, -1, 0), estado);
            sobreponer.SetTile(target + new Vector3Int(-1, -1, 0), fuego3);
            yield return new WaitForSeconds(.1f);
        }
        Limpiar();
    }

    void Limpiar()
    {
        sobreponer.ClearAllTiles();
    }
}

