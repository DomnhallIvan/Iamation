using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class Set : MonoBehaviour
{
    public List<Vector3Int> set;

    public void Add(Vector3Int current)
    {
        if (!set.Contains(current))
        {
            // Debug.Log("Agregue un neighbor " + current);
            set.Add(current);
        }
    }

    public void Clear()
    {
        set.Clear();
    }



}
