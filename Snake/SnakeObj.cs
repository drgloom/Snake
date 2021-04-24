using System;
using System.Collections.Generic;
using System.Text;

namespace Snake {
    class SnakeObj {
        private (int x, int y)[] _body;
        public SnakeObj(int x = 0, int y = 0, Direction direction = Direction.UP) {
            _body = new (int, int)[1] { (x, y) };
        }
        public int GetLastIndex() {
            return _body.Length - 1;
        }
        public (int x, int y) GetHeadPoint() {
            return _body[GetLastIndex()];
        }
        public (int x, int y) GetTailPoint() {
            return _body[0];
        }
        public void Move(bool isFood, Direction direction) {
            if (isFood) {
                switch (direction) {
                    case Direction.UP:
                        EatMove(0, 1);
                        break;
                    case Direction.DOWN:
                        EatMove(0, -1);
                        break;
                    case Direction.LEFT:
                        EatMove(-1, 0);
                        break;
                    case Direction.RIGHT:
                        EatMove(1, 0);
                        break;
                    default:
                        break;
                }
            }
            else {
                switch (direction) {
                    case Direction.UP:
                        JustMove(0, 1);
                        break;
                    case Direction.DOWN:
                        JustMove(0, -1);
                        break;
                    case Direction.LEFT:
                        JustMove(-1, 0);
                        break;
                    case Direction.RIGHT:
                        JustMove(1, 0);
                        break;
                    default:
                        break;
                }
            }
        }
        private void EatMove(int x, int y) {
            Array.Resize(ref _body, _body.Length + 1);
            _body[_body.Length - 1].x = _body[_body.Length - 2].x + x;
            _body[_body.Length - 1].y = _body[_body.Length - 2].y + y;
        }
        private void JustMove(int x, int y) {
            if (_body.Length > 1) {
                for (int index = 0; index < _body.Length - 1; index++) {
                    _body[index] = _body[index + 1];
                }
            }
            if (x != 0) _body[_body.Length - 1].x += x;
            if (y != 0) _body[_body.Length - 1].y += y;
        }
    }
}
