using System;
using System.Collections.Generic;
using UnityEngine;

public class BoardDisplay : MonoBehaviour
{
    private void OnEnable()
    {
        Facade.OnBoardUpdate += Display;
        Facade.OnHandUpdate += DisplayHand;
    }

    private void OnDisable()
    {
        Facade.OnBoardUpdate -= Display;
        Facade.OnHandUpdate -= DisplayHand;
    }

    private void Display(BingoBoard board)
    {
        string all = "\n";
        for (int y = 4; y >= 0; y--)
        {
            string row = "";
            for (int x = 0; x < 5; x++)
            {
                int number = board.Get(x, y);
                if (number < 10) row += " " + number + " ";
                else row += number + " ";

            }

            row += "    ";
            for (int x = 0; x < 5; x++)
            {
                if (board.IsFilled(x, y))
                {
                    row += "X ";
                }
                
                else row += "_ ";

            }

            all += row + "\n";
        }

        Debug.Log(all);
    }

    private void DisplayHand(List<Chip> hand)
    {
        //Debug.Log(hand);
    }
}
