using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading.Tasks;

public class ButtonKeyBoard : MonoBehaviour
{
    private Text letterText;
    private string cellToWords;
    private int countColor;
    
    void Start()
    {       
        letterText = GetComponentInChildren<Text>(); // узнали букву на клавише клавиатуры
    }

    public void ButtonLeter()
    {
        if (!gameObject.CompareTag("ButtonBackSpace") && !gameObject.CompareTag("ButtonConfirm") &&  ManagerFields.cellsController && ManagerFields.listCellsCount < 30)
        {
            if (ManagerFields.checkCell)
            {
                ManagerFields.cells[ManagerFields.listCellsCount-1].GetComponentInChildren<Text>().text = letterText.text;
                ManagerFields.checkCell = false;
                ManagerFields.cell_1 = true;
            }
            else
            {
                ManagerFields.cells[ManagerFields.listCellsCount].GetComponentInChildren<Text>().text = letterText.text;
                ManagerFields.listCellsCount++;
                ManagerFields.cell_1 = true;

                if (ManagerFields.listCellsCount == 5 || ManagerFields.listCellsCount == 10 || ManagerFields.listCellsCount == 15 || ManagerFields.listCellsCount == 20 || ManagerFields.listCellsCount == 25)
                {
                    ManagerFields.cellsController = false;
                }
            }
        }

        if(gameObject.CompareTag("ButtonBackSpace"))
        {
            if (ManagerFields.listCellsCount != 0 && ManagerFields.cell_1 == true)
            {
                if (ManagerFields.listCellsCount == 6 || ManagerFields.listCellsCount == 11 || ManagerFields.listCellsCount == 16 || ManagerFields.listCellsCount == 21 || ManagerFields.listCellsCount == 26)
                {
                    ManagerFields.cells[ManagerFields.listCellsCount - 1].GetComponentInChildren<Text>().text = "";
                    ManagerFields.checkCell = true;
                }
                else
                {
                    ManagerFields.cells[ManagerFields.listCellsCount - 1].GetComponentInChildren<Text>().text = "";
                    ManagerFields.listCellsCount--;
                    ManagerFields.cellsController = true;
                }
            }
        }

        if (gameObject.CompareTag("ButtonConfirm") && ManagerFields.cellsController == false)
        {
            if (CellToWords())
            {
                if (scriptDB.word == cellToWords)
                {
                    Debug.Log("Верно");
                    Win.activWin = true;
                    
                    //выводим окно победы
                }
                else
                {
                    ManagerFields.cellsController = true;
                    ManagerFields.cell_1 = false;
                }
            }
            else
            {
                MessageManager.errorMessageCheck = true;
                // выводим окно слова нет в базе
            }
        }

    }

    public bool CellToWords()
    {
        cellToWords = (ManagerFields.cells[ManagerFields.listCellsCount - 5].GetComponentInChildren<Text>().text
            + ManagerFields.cells[ManagerFields.listCellsCount - 4].GetComponentInChildren<Text>().text
            + ManagerFields.cells[ManagerFields.listCellsCount - 3].GetComponentInChildren<Text>().text
            + ManagerFields.cells[ManagerFields.listCellsCount - 2].GetComponentInChildren<Text>().text
            + ManagerFields.cells[ManagerFields.listCellsCount - 1].GetComponentInChildren<Text>().text).ToLower();

        if( scriptDB.ErrorWord(cellToWords) != null )
        {

            char[] b = new char[cellToWords.Length];
            char[] c = new char[scriptDB.word.Length];

            for (int i = 0; i < cellToWords.Length; i++)
            {
                b[i] = cellToWords[i];
                c[i] = scriptDB.word[i];

                for (int a = 0; a < scriptDB.word.Length; a++)
                {

                    if (cellToWords[i] == scriptDB.word[a])
                    {
                        countColor = 1;
                        break;
                    }
                    else
                    {
                        countColor = 2;
                    }
                }

                if (cellToWords[i] == scriptDB.word[i])
                {
                    countColor = 3;
                }
                switch (countColor)
                {
                    case 1:
                        ManagerFields.cells[ManagerFields.listCellsCount - 5 + i].GetComponentInChildren<Image>().color = Color.yellow;
                        break;
                    case 2:
                        ManagerFields.cells[ManagerFields.listCellsCount - 5 + i].GetComponentInChildren<Image>().color = Color.gray;
                        GameObject obj = GameObject.Find("Button" + cellToWords[i].ToString().ToUpper());
                        obj.GetComponent<Image>().color = Color.gray;
                        break;
                    case 3:
                        ManagerFields.cells[ManagerFields.listCellsCount - 5 + i].GetComponentInChildren<Image>().color = Color.green;
                        break;
                    default:
                        break;
                }
            }
            return true;
        }
        else
        {
            return false;
        }
    }
}
