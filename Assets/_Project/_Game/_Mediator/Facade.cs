using System;
using System.Collections.Generic;
using UnityEngine;

public static class Facade
{
    public static Action<BingoBoard> OnBoardUpdate;
    public static Action<List<Chip>> OnHandUpdate;
    
}
