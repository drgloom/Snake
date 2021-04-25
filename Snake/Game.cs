using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Snake {
    class Game {
        private Board _board;
        private byte _snakesNum;
        ConsoleKeyInfo _cki;
        Task _timerTask;
        Task _inputTask;
        public Game(int size = 10, byte snakesNum = 0) {
            _board = new Board(size, snakesNum);
            _snakesNum = snakesNum;
        }
        public void Start() {
            _timerTask = new Task(() => { Stepper(); });
            _inputTask = new Task(() => { InputKey(); });
            _timerTask.Start();
            _inputTask.Start();
            _timerTask.Wait();
        }
        public void Stepper() {
            int step = 0;
            byte result;
            while (true) {
                if (step != 0) {
                    result = _board.CalcNextTurn();
                    if (result == 1) {
                        Console.WriteLine("Победил 1");
                        break;
                    }
                    else if (result == 2) {
                        Console.WriteLine("Победил 2");
                        break;
                    }
                    else if (result == 3) {
                        Console.WriteLine("Ничья");
                        break;
                    }
                }
                else {
                    _board.SpawnFood();
                    if (_snakesNum == 1) _board.SpawnFood();
                }
                _board.DrawBoard(step);
                Console.WriteLine(_board.GetDirection(0));
                Console.WriteLine(_board.GetDirection(1));
                Thread.Sleep(300);
                step += 1;
            }
        }
        public void InputKey() {
            while (true) {
                //Thread.Sleep(199);
                _cki = Console.ReadKey();
                switch (_cki.Key.ToString()) {
                    case "W":
                        if (_board.GetDirection(0) != Direction.DOWN)
                            _board.SetDirection(Direction.UP, 0);
                        break;
                    case "S":
                        if (_board.GetDirection(0) != Direction.UP)
                            _board.SetDirection(Direction.DOWN, 0);
                        break;
                    case "A":
                        if (_board.GetDirection(0) != Direction.RIGHT)
                            _board.SetDirection(Direction.LEFT, 0);
                        break;
                    case "D":
                        if (_board.GetDirection(0) != Direction.LEFT)
                            _board.SetDirection(Direction.RIGHT, 0);
                        break;
                    case "UpArrow":
                        if (_board.GetDirection(1) != Direction.DOWN)
                            _board.SetDirection(Direction.UP, 1);
                        break;
                    case "DownArrow":
                        if (_board.GetDirection(1) != Direction.UP)
                            _board.SetDirection(Direction.DOWN, 1);
                        break;
                    case "LeftArrow":
                        if (_board.GetDirection(1) != Direction.RIGHT)
                            _board.SetDirection(Direction.LEFT, 1);
                        break;
                    case "RightArrow":
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
