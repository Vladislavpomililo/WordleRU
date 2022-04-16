using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Win : MonoBehaviour
{
    [SerializeField] private GameObject winWindow;
    [SerializeField] private Text textCount;
    [SerializeField] private Text cellWin;

    public static bool activWin;

    private void Start()
    {
        activWin = false;
    }

    private void Update()
    {
        if(activWin == true)
        {
            WinWindow();
        }
    }

    public void WinWindow()
    {
        winWindow.SetActive(true);
        textCount.text = "¬€ ”√¿ƒ¿À» —ÀŒ¬Œ! " + (ManagerFields.listCellsCount / 5) + "/6";
        cellWin.text = scriptDB.word;
    }
}
