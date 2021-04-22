using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Snake {
    class Game {
        private Board _board;
        ConsoleKeyInfo _cki;
        public Game(int size = 10) {
            _board = new Board(10);
        }
        public void Start() {
            Task timer = new Task(() => { Stepper(); });
            Task input = new Task(() => { InputKey(); });
            timer.Start();
            input.Start();
            timer.Wait();
        }
        public void Stepper() {
            while (true) {
                //_board.spawnFood();

                //_board.drawSnake();
                _board.MoveSnake();
                _board.CalcBoard();
                _board.DrawBoard();

                Console.WriteLine(_board.GetDirection());
                Console.WriteLine(_cki.Key);
                Thread.Sleep(1000);
                Console.Clear();
            }
        }
        public void InputKey() {
            while (true) {
                _cki = Console.ReadKey();
                switch (_cki.Key.ToString()) {
                    case "W":
                        _board.SetDirection(Direction.UP);
                        break;
                    case "S":
                        _board.SetDirection(Direction.DOWN);
                        break;
                    case "A":
                        _board.SetDirection(Direction.LEFT);
                        break;
                    case "D":
                        _board.SetDirection(Direction.RIGHT);
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
