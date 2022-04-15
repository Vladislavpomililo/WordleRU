using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerFields : MonoBehaviour
{
    static public List<Transform> cells;
    public Transform cellsTransform;
    private int childCountCells;

    static public int listCellsCount;
    static public bool cell_1;

    static public bool cellsController;
    static public bool checkCell;

    void Start()
    {
        listCellsCount = 0;
        cell_1 = true;
        cellsController = true;
        checkCell = false;

        cells = new List<Transform>();

        childCountCells = cellsTransform.childCount;

        for (int i = 0; i < childCountCells; i++)
        {
            cells.Add(cellsTransform.GetChild(i));
        }

    }
}
