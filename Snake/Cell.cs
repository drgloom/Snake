using System;
using System.Collections.Generic;
using System.Text;

namespace Snake {
    enum CellType {
        EMPTY,
        SNAKE1,
        SNAKE2,
        FOOD,
    }
    class Cell {
        public CellType _type { get; set; }
        public Cell(CellType type = CellType.EMPTY) {
            _type = type;
        }
    }
}