using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOSLogic
{
    enum CellState
    {
        S,
        O,
        EMPTY
    }

    internal class Cell
    {
        private Board board;
        private int row, col;
        private CellState state;

        public Cell(Board board, int row, int col)
        {
            this.board = board;
            this.row = row;
            this.col = col;

            this.state = CellState.EMPTY;
        }

        private bool isInside(int row, int col)
        {
            return (row < this.row && col < this.col);
        }
    }
}
