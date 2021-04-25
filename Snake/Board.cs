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
        public Board(int size = 10, byte snakesNum = 0) {
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
            _snake1 = new SnakeObj(0, 0, 0);
            _board[0, 0]._type = CellType.SNAKE1;
            _direction1 = Direction.UP;
            if (snakesNum == 1) {
                _snake2 = new SnakeObj(_size - 1, _size - 1, 1);
                _board[_size - 1, _size - 1]._type = CellType.SNAKE2;
                _direction2 = Direction.DOWN;
            }
        }
        public byte CalcNextTurn() {
            CopyBoard(ref _board, ref _prevBoard);
            byte result;
            (int x, int y) headPoint = _snake1.GetHeadPoint();
            (int x, int y) tailPoint = _snake1.GetTailPoint();
            switch (_direction1) {
                case Direction.UP:
                    result = CalcSnake(headPoint, tailPoint, 0, 1, ref _snake1);
                    break;
                case Direction.DOWN:
                    result = CalcSnake(headPoint, tailPoint, 0, -1, ref _snake1);
                    break;
                case Direction.LEFT:
                    result = CalcSnake(headPoint, tailPoint, -1, 0, ref _snake1);
                    break;
                case Direction.RIGHT:
                    result = CalcSnake(headPoint, tailPoint, 1, 0, ref _snake1);
                    break;
                default:
                    result = 0;
                    break;
            }
            if (result == 0 && _snake2 != null) {
                headPoint = _snake2.GetHeadPoint();
                tailPoint = _snake2.GetTailPoint();
                switch (_direction2) {
                    case Direction.UP:
                        result = CalcSnake(headPoint, tailPoint, 0, 1, ref _snake2);
                        break;
                    case Direction.DOWN:
                        result = CalcSnake(headPoint, tailPoint, 0, -1, ref _snake2);
                        break;
                    case Direction.LEFT:
                        result = CalcSnake(headPoint, tailPoint, -1, 0, ref _snake2);
                        break;
                    case Direction.RIGHT:
                        result = CalcSnake(headPoint, tailPoint, 1, 0, ref _snake2);
                        break;
                    default:
                        result = 0;
                        break;
                }
            }
            return result;
        }
        private byte CalcSnake((int x, int y) headPoint, (int x, int y) tailPoint, int xOffset, int yOffset, ref SnakeObj snake) {
            if (IsOutOfBorder(headPoint, snake._snakeIndex)) {
                if (snake._snakeIndex == 0) return 2;
                else return 1;
            }
            else if (_board[headPoint.x + xOffset, headPoint.y + yOffset]._type == CellType.EMPTY) {
                _board[tailPoint.x, tailPoint.y]._type = CellType.EMPTY;
                if (snake._snakeIndex == 0) snake.Move(false, _direction1);
                else snake.Move(false, _direction2);
                if (snake._snakeIndex == 0) _board[snake.GetHeadPoint().x, snake.GetHeadPoint().y]._type = CellType.SNAKE1;
                else _board[snake.GetHeadPoint().x, snake.GetHeadPoint().y]._type = CellType.SNAKE2;
                return 0;
            }
            else if (_board[headPoint.x + xOffset, headPoint.y + yOffset]._type == CellType.FOOD) {
                if (snake._snakeIndex == 0) snake.Move(true, _direction1);
                else snake.Move(true, _direction2);
                if (snake._snakeIndex == 0) _board[snake.GetHeadPoint().x, snake.GetHeadPoint().y]._type = CellType.SNAKE1;
                else _board[snake.GetHeadPoint().x, snake.GetHeadPoint().y]._type = CellType.SNAKE2;
                SpawnFood();
                return 0;
            }
            else if (snake._snakeIndex == 0) return 2;
            else return 1;
        }
        private bool IsOutOfBorder((int x, int y) headPoint, byte snakeIndex) {
            Direction direction;
            if (snakeIndex == 0) direction = _direction1;
            else direction = _direction2;
            switch (direction) {
                case Direction.UP   : return headPoint.y + 1 >= _size;
                case Direction.DOWN : return headPoint.y - 1 < 0;
                case Direction.LEFT : return headPoint.x - 1 < 0;
                case Direction.RIGHT: return headPoint.x + 1 >= _size;
                default             : return false;
            }
        }
        private void CopyBoard(ref Cell[,] board, ref Cell[,] prevBoard) {
            for (int x = 0; x < _size; x++) {
                for (int y = 0; y < _size; y++) {
                    prevBoard[x, y]._type = board[x, y]._type;
                }
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
