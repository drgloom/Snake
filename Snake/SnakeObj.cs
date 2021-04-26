using System;

namespace Snake {
    class SnakeObj {
        private (int x, int y)[] _body;
        public byte _snakeIndex { get; set; }
        public SnakeObj(int x = 0, int y = 0, byte snakeIndex = 0) {
            _body = new (int, int)[1] { (x, y) };
            _snakeIndex = snakeIndex;
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
        private void EatMove(int xOffset, int yOffset) {
            Array.Resize(ref _body, _body.Length + 1);
            _body[_body.Length - 1].x = _body[_body.Length - 2].x + xOffset;
            _body[_body.Length - 1].y = _body[_body.Length - 2].y + yOffset;
        }
        private void JustMove(int xOffset, int yOffset) {
            if (_body.Length > 1) {
                for (int index = 0; index < _body.Length - 1; index++) {
                    _body[index] = _body[index + 1];
                }
            }
            if (xOffset != 0) _body[_body.Length - 1].x += xOffset;
            if (yOffset != 0) _body[_body.Length - 1].y += yOffset;
        }
    }
}
