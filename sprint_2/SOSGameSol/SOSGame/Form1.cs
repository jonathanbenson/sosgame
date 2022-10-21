using System.Diagnostics;

namespace SOSGame
{
    public partial class Form1 : Form
    {

        // Object that paints the board canvas to create the SOS game board
        BoardPainter boardPainter;

        public Form1()
        {
            InitializeComponent();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            boardPainter.DrawBoard();
            boardPainter.DrawS(3, 3);
            boardPainter.DrawSOSLine(2, 1, 4, 3);
        }

        private void boardCanvas_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = boardCanvas.CreateGraphics();

            boardPainter = new BoardPainter(boardCanvas, _boardSizeNum, graphics);
        }

        private void boardCanvas_Click(object sender, EventArgs e)
        {
            Point point = boardCanvas.PointToClient(Cursor.Position);

            Tuple<int, int> rowCol = GetRowColOfPoint(point);

            boardPainter.DrawS(rowCol.Item1, rowCol.Item2);
        }

        private Tuple<int, int> GetRowColOfPoint(Point point)
        {
            int k = boardCanvas.Width;
            int boardSize = (int)_boardSizeNum.Value;
            int cellSizePixels = k / boardSize;

            for (int row = 0; row < boardSize; ++row)
            {
                for (int col = 0; col < boardSize; ++col)
                {
                    int rLow = BoardPainter.Rasterize(row, cellSizePixels, k);
                    int rHigh = BoardPainter.Rasterize(row + 1, cellSizePixels, k);
                    int cLow = BoardPainter.Rasterize(col, cellSizePixels, k);
                    int cHigh = BoardPainter.Rasterize(col + 1, cellSizePixels, k);

                    if (point.X > cLow && point.X < cHigh && point.Y > rLow && point.Y < rHigh)
                        return Tuple.Create(row, col);

                }
            }

            return Tuple.Create(-1, -1);
        }
    }
}