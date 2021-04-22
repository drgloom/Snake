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
    class SnakeObj {
        private Direction _direction;
        private (int, int)[] _body;
        public SnakeObj(int x = 0, int y = 0, Direction direction = Direction.UP) {
            _direction = direction;
            _body = new (int, int)[1] { (x, y) };
        }
        public int GetSize() {
            return _body.Length;
        }
        public (int, int) GetCoords(int index) {
            return _body[index];
        }
        public Direction GetDirection() {
            return _direction;
        }
        public void SetDirection(Direction direction) {
            _direction = direction;
        }
        public void Move(Direction direction) {
            switch (direction) {
                case Direction.UP:
                    _body[_body.Length - 1].Item2 += 1;
                    /*for (int index = _body.Length; index >= 0; index--) {
                        
                    }*/
                    break;
                case Direction.DOWN:
                    break;
                case Direction.LEFT:
                    break;
                case Direction.RIGHT:
                    break;
                default:
                    break;
            }
        }
    }
}
