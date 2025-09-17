using System;
using System.Collections.Generic;
using UnityEngine;

public class BoardPlayer : MonoBehaviour
{
    [SerializeField] private BingoBoard bingoBoard;
    public void Play(List<Chip> chips)
    {
        bingoBoard.Receive(chips);
    }
}