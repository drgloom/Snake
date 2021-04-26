using System;
using System.Threading.Tasks;
using System.Threading;

namespace Snake {
    class Game {
        private Board _board;
        private byte _snakesNum;
        private Task _timerTask;
        private Task _inputTask;
        private bool run;
        public Game(int size = 10, byte snakesNum = 0) {
            if (size >= 5) _board = new Board(size, snakesNum);
            else _board = new Board(5, snakesNum);
            _snakesNum = snakesNum;
            run = true;
        }
        public void Start() {
            Console.Clear();
            _timerTask = new Task(() => { Stepper(); });
            _inputTask = new Task(() => { InputKey(); });
            _timerTask.Start();
            _inputTask.Start();
            _timerTask.Wait();
            run = false;
            _inputTask.Wait();
        }
        public void Stepper() {
            int step = 0;
            while (true) {
                if (step != 0) {
                    byte result = _board.CalcNextTurn();
                    if (result == 1) {
                        Console.WriteLine("Победил 1.");
                        Console.WriteLine("Нажмите любую кнопку для продолжения.");
                        break;
                    }
                    else if (result == 2) {
                        Console.WriteLine("Победил 2.");
                        Console.WriteLine("Нажмите любую кнопку для продолжения.");
                        break;
                    }
                    else if (result == 3) {
                        Console.WriteLine("Ничья.");
                        Console.WriteLine("Нажмите любую кнопку для продолжения.");
                        break;
                    }
                }
                else {
                    _board.SpawnFood();
                    if (_snakesNum == 1) _board.SpawnFood();
                }
                Program.tempBoard.CopyTemp(_board._board);
                _board.DrawBoard(step);
                Console.WriteLine(_board.GetDirection(0));
                Console.WriteLine(_board.GetDirection(1));
                //Console.WriteLine(TempBoard._size);
                /*for (int i = 0; i < TempBoard._size; i++) {
                    for (int j = 0; j < TempBoard._size; j++) {
                        Console.Write(TempBoard._board[i, j]._type);
                    }
                }*/
                Thread.Sleep(2000);
                step += 1;
            }
        }
        public void InputKey() {
            while (run) {
                switch (Console.ReadKey(true).Key) {
                    case ConsoleKey.W :
                        if (_board.GetDirection(0) != Direction.DOWN)
                            _board.SetDirection(Direction.UP, 0);
                        break;
                    case ConsoleKey.S :
                        if (_board.GetDirection(0) != Direction.UP)
                            _board.SetDirection(Direction.DOWN, 0);
                        break;
                    case ConsoleKey.A :
                        if (_board.GetDirection(0) != Direction.RIGHT)
                            _board.SetDirection(Direction.LEFT, 0);
                        break;
                    case ConsoleKey.D :
                        if (_board.GetDirection(0) != Direction.LEFT)
                            _board.SetDirection(Direction.RIGHT, 0);
                        break;
                    case ConsoleKey.UpArrow :
                        if (_board.GetDirection(1) != Direction.DOWN)
                            _board.SetDirection(Direction.UP, 1);
                        break;
                    case ConsoleKey.DownArrow :
                        if (_board.GetDirection(1) != Direction.UP)
                            _board.SetDirection(Direction.DOWN, 1);
                        break;
                    case ConsoleKey.LeftArrow :
                        if (_board.GetDirection(1) != Direction.RIGHT)
                            _board.SetDirection(Direction.LEFT, 1);
                        break;
                    case ConsoleKey.RightArrow :
                        if (_board.GetDirection(1) != Direction.LEFT)
                            _board.SetDirection(Direction.RIGHT, 1);
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
