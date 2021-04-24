using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Snake {
    class Game {
        private Board _board;
        ConsoleKeyInfo _cki;
        Task _timerTask;
        Task _inputTask;
        public Game(int size = 10) {
            _board = new Board(size);
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
            while (true) {
                if (step != 0) {
                    if (!_board.CalcNextTurn()) {
                        Console.WriteLine("GameOver");
                        break;
                    }
                }
                else {
                    _board.SpawnFood();
                }
                _board.DrawBoard(step);
                Console.WriteLine(_board.GetDirection(0));
                Thread.Sleep(200);
                step += 1;
            }
        }
        public void InputKey() {
            while (true) {
                //Thread.Sleep(199);
                _cki = Console.ReadKey();
                switch (_cki.Key.ToString()) {
                    case "W":
                        _board.SetDirection(Direction.UP, 0);
                        break;
                    case "S":
                        _board.SetDirection(Direction.DOWN, 0);
                        break;
                    case "A":
                        _board.SetDirection(Direction.LEFT, 0);
                        break;
                    case "D":
                        _board.SetDirection(Direction.RIGHT, 0);
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
