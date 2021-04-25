using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace Snake {
    class Board {
    private int _size {get; set;}
    public Cell[,] _board {get; set;}
    private SnakeObj _snake1{get; set;}
    private SnakeObj _snake2{get; set;}

    public Board(int size) {
         _size = size;
         _board = new Cell[_size, _size];
         for (int x = 0; x < _size; x++) {
             for (int y = 0; y < _size; y++) {
                 _board[x, y] = new Cell();
             }
             
         }
 
         _snake1 = new SnakeObj();     
     }
    public Board(Cell[,] board,int size,SnakeObj snake1,SnakeObj snake2)
    {
        _size = size;
        _board = board;
        _snake1 = snake1;
        _snake2 = snake2;
    }
    public Board()
    {
        
    }
    public void MoveSnake()
    {
        int snake_head_x = _snake1.GetCoords(_snake1.GetSize() - 1).Item1;
        int snake_head_y = _snake1.GetCoords(_snake1.GetSize() - 1).Item2;
        int snake_tail_x = _snake1.GetCoords(0).Item1;
        int snake_tail_y = _snake1.GetCoords(0).Item2;
        switch (_snake1.GetDirection())
        {
            case Direction.UP:
                if (_board[snake_head_x, snake_head_y + 1]._type == CellType.EMPTY)
                {
                    _snake1.Move(Direction.UP);
                }

                _board[snake_tail_x, snake_tail_y]._type = CellType.EMPTY;
                //DrawSnake();
                break;
            case Direction.DOWN:
                break;
            case Direction.LEFT:
                break;
            case Direction.RIGHT:
            default:
                break;
        }
    }

    public void SetDirection(Direction direction)
    {
        _snake1.SetDirection(direction);
    }

    public Direction GetDirection()
    {
        return _snake1.GetDirection();
    }

    /*public void SpawnFood() {
        //TODO сделать проверку на заполненность доски
        var rand = new Random();
        while (true) {
            int x = rand.Next(0, _size);
            int y = rand.Next(0, _size);
            if (_board[x, y]._type == CellType.EMPTY) {
                _board[x, y]._type = CellType.FOOD;
                break;
            }
        }
    }*/
    public void CalcSnake()
    {
        for (int index = 0; index < _snake1.GetSize(); index++)
        {
            _board[_snake1.GetCoords(index).Item1, _snake1.GetCoords(index).Item2]._type = CellType.SNAKE1;
        }
    }

    public void CalcBoard()
    {

        CalcSnake();
    }

    public void DrawBoard()
    {
        //отрисовка верхней рамки
        for (int i = 0; i < _size + 1; i++)
        {
            if (i == 0)
            {
                Console.Write("\u2554\u2550");
            }
            else if (i == _size)
            {
                Console.WriteLine("\u2550\u2557");
            }
            else
            {
                Console.Write("\u2550\u2550");
            }
        }

        //отрисовка поля
        for (int y = _size - 1; y >= 0; y--)
        {
            Console.Write("\u2551");
            for (int x = 0; x < _size; x++)
            {
                switch (_board[x, y]._type)
                {
                    case CellType.SNAKE1:
                        Console.Write("\u2588\u2588");
                        break;
                    case CellType.SNAKE2:
                        Console.Write("\u2588\u2588");
                        break;
                    case CellType.EMPTY:
                        Console.Write("  ");
                        break;
                    case CellType.FOOD:
                        Console.Write("\u2588\u2588");
                        break;
                    default:
                        break;
                }
            }

            Console.WriteLine("\u2551");
        }

        //отрисовка нижней рамки
        for (int i = 0; i < _size + 1; i++)
        {
            if (i == 0)
            {
                Console.Write("\u255A\u2550");
            }
            else if (i == _size)
            {
                Console.WriteLine("\u2550\u255D");
            }
            else
            {
                Console.Write("\u2550\u2550");
            }
        }
    }

    public void GetBoard(string json)
    {
        try
        {
            Console.WriteLine("test");
            var temp = JsonSerializer.Deserialize<Board>(json);
            _board = temp._board;
            _size = temp._size;
            _snake1 = temp._snake1;
            _snake2 = temp._snake2;
            DrawBoard();
        }
        catch
        {
            Console.WriteLine("Ошибка принятогго класса!"); //соединение было прервано
            Console.ReadLine();
        }
    }

    public string PushBoard()
    {
        //DrawBoard();
        //Board temp = new Board(_board,_size,_snake1,_snake2);
        //temp.DrawBoard();
        Cell[,] temp = new Cell[_size,_size];
        //temp = _board;
        for (int i = 0; i < _size; i++)
        {
            for (int j = 0; j < _size; j++)
            {
                temp[i, j]._type = CellType.EMPTY;
            }
        }
        Console.WriteLine(temp[1,1]._type);
        var res = JsonSerializer.Serialize(temp);
        Console.WriteLine(res);
        return res;
    }

    }
    
}
