using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BingoBoard : MonoBehaviour
{
    private static readonly Vector2Int boardSize = new Vector2Int(5, 5);
    private Board<int> numberedBoard = new Board<int>(boardSize);
    private Board<bool> filledBoard = new Board<bool>(boardSize);

    private void Awake()
    {
        InitializeBingoBoard();
    }

    public int Get(int x, int y)
    {
        return numberedBoard.Get(x, y);
    }

    public bool IsFilled(int x, int y)
    {
        return filledBoard.Get(x, y);
    }

    private void InitializeBingoBoard()
    {
        List<int> _b = pickXFromSet(5, generateSet(1, 15));
        List<int> _i = pickXFromSet(5, generateSet(16, 30));
        List<int> _n = pickXFromSet(5, generateSet(31, 45));
        List<int> _g = pickXFromSet(5, generateSet(46, 60));
        List<int> _o = pickXFromSet(5, generateSet(61, 75));

        _n[2] = 0; // Free Space
        filledBoard.Set(2, 2, true);

        for (int i = 0; i < 5; i++)
        {
            numberedBoard.Set(0, i, _b[i]);
            numberedBoard.Set(1, i, _i[i]);
            numberedBoard.Set(2, i, _n[i]);
            numberedBoard.Set(3, i, _g[i]);
            numberedBoard.Set(4, i, _o[i]);
        }
        Updated();
    }

    private List<int> generateSet(int from, int to)
    {
        List<int> set = new List<int>();
        for (int i = from; i <= to; i++)
        {
            set.Add(i);
        }

        return set;
    }

    private List<int> pickXFromSet(int x, List<int> set)
    {
        if (x > set.Count)
        {
            Debug.LogWarning("Forced To Choose All From Set");
            x = set.Count;
        }
        return set.OrderBy((u) => Random.value).ToList().GetRange(0, x);
    }

    public void Receive(List<Chip> chips)
    {
        chips.ForEach((x) =>
        {
            if (numberedBoard.TryGet(out Vector2Int pos, x.Value))
            {
                filledBoard.Set(pos, true);
                
            }
        });
        Updated();
    }

    private void Updated()
    {
        Facade.OnBoardUpdate?.Invoke(this);
    }
}