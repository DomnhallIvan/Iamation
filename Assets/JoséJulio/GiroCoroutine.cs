using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GiroCoroutine : MonoBehaviour
{
    public Tilemap tm;
    public Tilemap sobreponer;
    public Tile ataque;
    public Vector3Int target;

    // Update is called once per frame
    void Update()
    {
        var algo = transform.GetComponent<Camera>().ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z));
        Vector3Int location = tm.WorldToCell(algo);
        target = location;

        if (tm.GetSprite(location) != null && Input.GetKeyDown(KeyCode.X))
        {
            StartCoroutine(Ataque());
        }

    }

    IEnumerator Ataque()
    {
        Matrix4x4 estado = Matrix4x4.TRS(new Vector3(0, .2f, 0), Quaternion.Euler(0, 0, 0), Vector3.one);
        sobreponer.SetTransformMatrix(target + new Vector3Int(0, 2, 0), estado);
        sobreponer.SetTile(target + new Vector3Int(0, 2, 0), ataque);
        yield return new WaitForSeconds(.05f);
        sobreponer.SetTransformMatrix(target + new Vector3Int(1, 2, 0), estado);
        sobreponer.SetTile(target + new Vector3Int(1, 2, 0), ataque);
        yield return new WaitForSeconds(.05f);
        sobreponer.SetTransformMatrix(target + new Vector3Int(2, 1, 0), estado);
        sobreponer.SetTile(target + new Vector3Int(2, 1, 0), ataque);
        yield return new WaitForSeconds(.05f);
        sobreponer.SetTransformMatrix(target + new Vector3Int(2, 0, 0), estado);
        sobreponer.SetTile(target + new Vector3Int(2, 0, 0), ataque);
        yield return new WaitForSeconds(.05f);
        sobreponer.SetTransformMatrix(target + new Vector3Int(2, -1, 0), estado);
        sobreponer.SetTile(target + new Vector3Int(2, -1, 0), ataque);
        yield return new WaitForSeconds(.05f);
        sobreponer.SetTransformMatrix(target + new Vector3Int(1, -2, 0), estado);
        sobreponer.SetTile(target + new Vector3Int(1, -2, 0), ataque);
        yield return new WaitForSeconds(.05f);
        sobreponer.SetTransformMatrix(target + new Vector3Int(0, -2, 0), estado);
        sobreponer.SetTile(target + new Vector3Int(0, -2, 0), ataque);
        yield return new WaitForSeconds(.05f);
        sobreponer.SetTransformMatrix(target + new Vector3Int(-1, -2, 0), estado);
        sobreponer.SetTile(target + new Vector3Int(-1, -2, 0), ataque);
        yield return new WaitForSeconds(.05f);
        sobreponer.SetTransformMatrix(target + new Vector3Int(-2, -1, 0), estado);
        sobreponer.SetTile(target + new Vector3Int(-2, -1, 0), ataque);
        yield return new WaitForSeconds(.05f);
        sobreponer.SetTransformMatrix(target + new Vector3Int(-2, 0, 0), estado);
        sobreponer.SetTile(target + new Vector3Int(-2, 0, 0), ataque);
        yield return new WaitForSeconds(.05f);
        sobreponer.SetTransformMatrix(target + new Vector3Int(-2, 1, 0), estado);
        sobreponer.SetTile(target + new Vector3Int(-2, 1, 0), ataque);
        yield return new WaitForSeconds(.05f);
        sobreponer.SetTransformMatrix(target + new Vector3Int(-1, 2, 0), estado);
        sobreponer.SetTile(target + new Vector3Int(-1, 2, 0), ataque);
        yield return new WaitForSeconds(.05f);
        Limpiar();

    }
    void Limpiar()
    {
        sobreponer.ClearAllTiles();
    }
}
