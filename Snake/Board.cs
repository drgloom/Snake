using System;
using System.Collections.Generic;
using System.Text;

namespace Snake {
    class Board {
        private int _size;
        private Cell[,] _board;
        public Board(int size = 10) {
            _size = size;
            _board = new Cell[_size, _size];
            for (int x = 0; x < _size; x++) {
                for (int y = 0; y < _size; y++) {
                    _board[x, y] = new Cell();
                }
            }
        }
        public void print() {
            //отрисовка верхней рамки
            for (int i = 0; i < _size + 1; i++) {
                if (i == 0) {
                    Console.Write("\u2554\u2550");
                } else if (i == _size) {
                    Console.WriteLine("\u2550\u2557");
                } else {
                    Console.Write("\u2550\u2550");
                }
            }
            //отрисовка поля
            for (int x = 0; x < _size; x++) {
                Console.Write("\u2551");
                for (int y = 0; y < _size; y++) {
                    switch (_board[x, y]._type) {
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
            for (int i = 0; i < _size + 1; i++) {
                if (i == 0) {
                    Console.Write("\u255A\u2550");
                } else if (i == _size) {
                    Console.WriteLine("\u2550\u255D");
                } else {
                    Console.Write("\u2550\u2550");
                }
            }
        }
    }
}
