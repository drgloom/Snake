using System;
using System.Drawing;
using System.Text.Json.Serialization;

namespace Snake
{
    class BoardTest
    {
        public int size {get; set;}
        public CellType[] line {get; set;}
        [JsonIgnore] public CellType[,] board;

        public BoardTest(Cell[,] board,int size)
        {
            this.size = size;
            int count = 0;
            line = new CellType[size*size];
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    line[count] = board[i, j]._type;
                    count++;
                }
            }
        }
        
        public BoardTest()
        { 
            size = 15;
            line = new CellType[size * size];
        }

        public BoardTest(CellType[] line, int size)
        {
            this.size = size;
            int count = 0;
            board = new CellType[size, size];
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    board[i, j] = line[count];
                    count++;
                }
            }
        }
        public void DrawBoard()
            {
                //отрисовка верхней рамки
                for (int i = 0; i < size + 1; i++)
                {
                    if (i == 0)
                    {
                        Console.Write("\u2554\u2550");
                    }
                    else if (i == size)
                    {
                        Console.WriteLine("\u2550\u2557");
                    }
                    else
                    {
                        Console.Write("\u2550\u2550");
                    }
                }
        
                //отрисовка поля
                for (int y = size - 1; y >= 0; y--)
                {
                    Console.Write("\u2551");
                    for (int x = 0; x < size; x++)
                    {
                        switch (board[x, y])
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
                for (int i = 0; i < size + 1; i++)
                {
                    if (i == 0)
                    {
                        Console.Write("\u255A\u2550");
                    }
                    else if (i == size)
                    {
                        Console.WriteLine("\u2550\u255D");
                    }
                    else
                    {
                        Console.Write("\u2550\u2550");
                    }
                }
            }
    }
}