using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerFields : MonoBehaviour
{
    static public List<Transform> cells;
    public Transform cellsTransform;
    private int childCountCells;

    static public int listCellsCount = 0;
    static public bool cell_1 = true; 

    static public bool cellsController = true;
    static public bool checkCell = false;

    void Start()
    {
        cells = new List<Transform>();

        childCountCells = cellsTransform.childCount;

        for (int i = 0; i < childCountCells; i++)
        {
            cells.Add(cellsTransform.GetChild(i));
        }

    }
}
