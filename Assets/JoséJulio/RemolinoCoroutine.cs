using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class RemolinoCoroutine : MonoBehaviour
{
    public Tilemap tm;
    public Tilemap sobreponer;
    public Tile agua;
    public Vector3Int target;

    // Update is called once per frame
    void Update()
    {
        var algo = transform.GetComponent<Camera>().ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z));
        Vector3Int location = tm.WorldToCell(algo);
        target = location;

        if (tm.GetSprite(location) != null && Input.GetKeyDown(KeyCode.C))
        {
            StartCoroutine(Remolino1());
        }
    }
    IEnumerator Remolino1()
    {
        for (int i = 1; i < 4; i++)
        {
            Matrix4x4 estado = Matrix4x4.TRS(new Vector3(0, 0 + .025f, 0), Quaternion.Euler(0, 0, -10), Vector3.one);
            sobreponer.SetTransformMatrix(target, estado);
            sobreponer.SetTile(target, agua);
            sobreponer.SetTransformMatrix(target + new Vector3Int(-1, 0, 0), estado);
            sobreponer.SetTile(target + new Vector3Int(-1, 0, 0), agua);
            yield return new WaitForSeconds(.1f);         
        }
        StartCoroutine(Remolino2());
    }

    IEnumerator Remolino2()
    {
        for (int i = 1; i < 4; i++)
        {
            Matrix4x4 estado = Matrix4x4.TRS(new Vector3(0, .1f + .025f, 0), Quaternion.Euler(0, 0, -10), Vector3.one);
            sobreponer.SetTransformMatrix(target + new Vector3Int(-2, -1, 0), estado);
            sobreponer.SetTile(target + new Vector3Int(-2, -1, 0), agua);
            sobreponer.SetTransformMatrix(target + new Vector3Int(-1, -2, 0), estado);
            sobreponer.SetTile(target + new Vector3Int(-1, -2, 0), agua);
            sobreponer.SetTransformMatrix(target + new Vector3Int(0, -3, 0), estado);
            sobreponer.SetTile(target + new Vector3Int(0, -3, 0), agua);
            sobreponer.SetTransformMatrix(target + new Vector3Int(1, -2, 0), estado);
            sobreponer.SetTile(target + new Vector3Int(-1, -2, 0), agua);
            yield return new WaitForSeconds(.1f);
            StartCoroutine(Remolino3());
        }
    }

    IEnumerator Remolino3()
    {
        for (int i = 1; i < 4; i++)
        {
            Matrix4x4 estado = Matrix4x4.TRS(new Vector3(0, .1f + .025f, 0), Quaternion.Euler(0, 0, -10), Vector3.one);
            sobreponer.SetTransformMatrix(target + new Vector3Int(2, -1, 0), estado);
            sobreponer.SetTile(target + new Vector3Int(2, -1, 0), agua);
            sobreponer.SetTransformMatrix(target + new Vector3Int(2, 0, 0), estado);
            sobreponer.SetTile(target + new Vector3Int(2, 0, 0), agua);
            sobreponer.SetTransformMatrix(target + new Vector3Int(2, 1, 0), estado);
            sobreponer.SetTile(target + new Vector3Int(2, 1, 0), agua);
            yield return new WaitForSeconds(.1f);
        }
        StartCoroutine(Remolino4());
    }

    IEnumerator Remolino4()
    {
        for (int i = 1; i < 4; i++)
        {
            Matrix4x4 estado = Matrix4x4.TRS(new Vector3(0, .2f + .025f, 0), Quaternion.Euler(0, 0, -10), Vector3.one);
            sobreponer.SetTransformMatrix(target + new Vector3Int(1, 2, 0), estado);
            sobreponer.SetTile(target + new Vector3Int(1, 2, 0), agua);
            sobreponer.SetTransformMatrix(target + new Vector3Int(0, 3, 0), estado);
            sobreponer.SetTile(target + new Vector3Int(0, 3, 0), agua);
            sobreponer.SetTransformMatrix(target + new Vector3Int(-1, 3, 0), estado);
            sobreponer.SetTile(target + new Vector3Int(-1, 3, 0), agua);
            sobreponer.SetTransformMatrix(target + new Vector3Int(-2, 3, 0), estado);
            sobreponer.SetTile(target + new Vector3Int(-2, 3, 0), agua);
            sobreponer.SetTransformMatrix(target + new Vector3Int(-3, 3, 0), estado);
            sobreponer.SetTile(target + new Vector3Int(-3, 3, 0), agua);
            sobreponer.SetTransformMatrix(target + new Vector3Int(-4, 2, 0), estado);
            sobreponer.SetTile(target + new Vector3Int(-4, 2, 0), agua);
            sobreponer.SetTransformMatrix(target + new Vector3Int(-4, 1, 0), estado);
            sobreponer.SetTile(target + new Vector3Int(-4, 1, 0), agua);
            yield return new WaitForSeconds(.1f);
        }

        Limpiar();
    }

    void Limpiar()
    {
        sobreponer.ClearAllTiles();
    }
}
