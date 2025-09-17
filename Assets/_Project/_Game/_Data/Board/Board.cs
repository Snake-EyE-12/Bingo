using UnityEngine;

public class Board<T>
{
    private T[,] board;
    public Board(Vector2Int size)
    {
        board = new T[size.x,size.y];
    }

    public T Get(int x, int y)
    {
        return board[x, y];
    }

    public void Set(int x, int y, T value)
    {
        board[x, y] = value;
    }

    public void Set(Vector2Int pos, T value)
    {
        Set(pos.x, pos.y, value);
    }

    public bool TryGet(out Vector2Int position, T value)
    {
        for (int x = 0; x < board.GetLength(0); x++)
        {
            for (int y = 0; y < board.GetLength(1); y++)
            {
                if (Get(x, y).Equals(value))
                {
                    position = new Vector2Int(x, y);
                    Debug.Log("Hit");
                    return true;
                }
            }
        }
        position = default;
        return false;
    }
    
}
