using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Threading;
using System.Drawing;
using System.Text.Json.Serialization;

namespace Snake
{
    class TempBoard
    {
        public int _size { get; set; }
        public CellType[] _line { get; set; }
        //public Cell[,] _board { get; set; }

        public TempBoard(int size)
        {
            _size = size;
            _line = new CellType[_size * _size];
            /*for (int x = 0; x < _size; x++)
            {
                for (int y = 0; y < _size; y++)
                {
                    _board[x, y] = new Cell();
                }
            }*/
            //_line = new CellType[_size];
        }
/*        public TempBoard(Cell[,] board, int size)
        {
            this.size = size;
            int count = 0;
            line = new CellType[size * size];
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    line[count] = board[i, j]._type;
                    count++;
                }
            }
        }*/
        public void CopyTemp(Cell[,] board)
        {
            //_size = size;
            int count = 0;
            //_line = new CellType[size * size];
            for (int i = 0; i < _size; i++)
            {
                for (int j = 0; j < _size; j++)
                {
                    _line[count] = board[i, j]._type;
                    count++;
                }
            }
        }

/*        public TempBoard()
        {
            size = 15;
            line = new CellType[size * size];
        }*/

/*        public TempBoard(CellType[] line, int size)
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
        }*/
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
                    switch (_line[x + y])
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
    }
}
