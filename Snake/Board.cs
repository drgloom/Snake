using System;
using System.Collections.Generic;
using System.Text;

namespace Snake {
    enum Direction {
        UP,
        DOWN,
        LEFT,
        RIGHT,
    }
    class Board {
        private int _size;
        public Cell[,] _board;
        public Cell[,] _prevBoard;
        private SnakeObj _snake1;
        private Direction _direction1;
        private SnakeObj _snake2;
        private Direction _direction2;
        public Board(int size = 10) {
            _size = size;
            _board = new Cell[_size, _size];
            for (int x = 0; x < _size; x++) {
                for (int y = 0; y < _size; y++) {
                    _board[x, y] = new Cell();
                }
            }
            _prevBoard = new Cell[_size, _size];
            for (int x = 0; x < _size; x++) {
                for (int y = 0; y < _size; y++) {
                    _prevBoard[x, y] = new Cell();
                }
            }
            _snake1 = new SnakeObj();
            _board[0, 0]._type = CellType.SNAKE1;

        }
        public bool CalcNextTurn() {
            for (int x = 0; x < _size; x++) {
                for (int y = 0; y < _size; y++) {
                    _prevBoard[x, y]._type = _board[x, y]._type;
                }
            }
            (int x, int y) headPoint = _snake1.GetHeadPoint();
            (int x, int y) tailPoint = _snake1.GetTailPoint();
            switch (_direction1) {
                case Direction.UP   : return CalcSnake(headPoint, tailPoint, 0, 1);
                case Direction.DOWN : return CalcSnake(headPoint, tailPoint, 0, -1);
                case Direction.LEFT : return CalcSnake(headPoint, tailPoint, -1, 0);
                case Direction.RIGHT: return CalcSnake(headPoint, tailPoint, 1, 0);
                default             : return true;
            }
        }
        private bool CalcSnake((int x, int y) headPoint, (int x, int y) tailPoint, int xOffset, int yOffset) {
            if (IsOutOfBorder(headPoint)) return false;
            else if (_board[headPoint.x + xOffset, headPoint.y + yOffset]._type == CellType.EMPTY) {
                _board[tailPoint.x, tailPoint.y]._type = CellType.EMPTY;
                _snake1.Move(false, _direction1);
                _board[_snake1.GetHeadPoint().x, _snake1.GetHeadPoint().y]._type = CellType.SNAKE1;
                return true;
            }
            else if (_board[headPoint.x + xOffset, headPoint.y + yOffset]._type == CellType.FOOD) {
                _snake1.Move(true, _direction1);
                _board[_snake1.GetHeadPoint().x, _snake1.GetHeadPoint().y]._type = CellType.SNAKE1;
                SpawnFood();
                return true;
            }
            else return false;
        }
        private bool IsOutOfBorder((int x, int y) headPoint) {
            switch (_direction1) {
                case Direction.UP   : return headPoint.y + 1 >= _size;
                case Direction.DOWN : return headPoint.y - 1 < 0;
                case Direction.LEFT : return headPoint.x - 1 < 0;
                case Direction.RIGHT: return headPoint.x + 1 >= _size;
                default             : return false;
            }
        }
        public void SetDirection(Direction direction, byte snake) {
            if (snake == 0) {
                _direction1 = direction;
            }
            else _direction2 = direction;
        }
        public Direction GetDirection(byte snake) {
            if (snake == 0) {
                return _direction1;
            }
            else return _direction2;
        }
        public void SpawnFood() {
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
        }
        public void DrawBoard(int step) {
            //отрисовка верхней рамки
            if (step == 0) {
                for (int i = 0; i < _size + 1; i++) {
                    if (i == 0) {
                        Console.Write("\u2554\u2550");
                    }
                    else if (i == _size) {
                        Console.WriteLine("\u2550\u2557");
                    }
                    else {
                        Console.Write("\u2550\u2550");
                    }
                }
                //отрисовка поля
                for (int y = _size - 1; y >= 0; y--) {
                    Console.Write("\u2551");
                    for (int x = 0; x < _size; x++) {
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
                                Console.Write("\u2591\u2591");
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
                    }
                    else if (i == _size) {
                        Console.WriteLine("\u2550\u255D");
                    }
                    else {
                        Console.Write("\u2550\u2550");
                    }
                }
            }
            else {
                for (int x = 0; x < _size; x++) {
                    for (int y = 0; y < _size; y++) {
                        if (_prevBoard[x, y]._type != _board[x, y]._type) {
                            switch (_board[x, y]._type) {
                                case CellType.SNAKE1:
                                    Console.SetCursorPosition(x*2 + 1, _size - y);
                                    Console.Write("\u2588\u2588");
                                    break;
                                case CellType.SNAKE2:
                                    Console.SetCursorPosition(x*2 + 1, _size - y);
                                    Console.Write("\u2588\u2588");
                                    break;
                                case CellType.EMPTY:
                                    Console.SetCursorPosition(x*2 + 1, _size - y);
                                    Console.Write("  ");
                                    break;
                                case CellType.FOOD:
                                    Console.SetCursorPosition(x*2 + 1, _size - y);
                                    Console.Write("\u2591\u2591");
                                    break;
                                default:
                                    break;
                            }
                        }
                    }
                }
                Console.SetCursorPosition(0, _size + 2);
            }
        }
    }
}
