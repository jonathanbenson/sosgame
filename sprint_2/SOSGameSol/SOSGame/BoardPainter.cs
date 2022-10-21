using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOSGame
{
    internal class BoardPainter
    {
        private Panel boardCanvas;
        private NumericUpDown boardSizeNum;
        private Graphics graphics;

        public BoardPainter(Panel boardCanvas, NumericUpDown boardSizeNum, Graphics graphics)
        {
            this.boardCanvas = boardCanvas;
            this.graphics = graphics;
            this.boardSizeNum = boardSizeNum;
            
            DrawBoard();
        }

        public void test()
        {
            Brush brush = new SolidBrush(Color.Red);

            graphics.FillRectangle(brush, new Rectangle(0, 0, 100, 100));
        }

        public void DrawS(int row, int col)
        {

        }

        public void DrawO(int row, int col)
        {

        }

        public void DrawSOSLine(int startRow, int startCol, int endRow, int endCol)
        {

        }

        public void DrawBoard()
        {
            // clear the board of paint
            graphics.Clear(Color.White);

            // obtain the board size from the board size numeric updown control
            int boardSize = (int)boardSizeNum.Value;

            // pen used to draw the border, as well as row and column lines
            Pen linePen = new Pen(Color.Black);

            // size = k, while the board has dimensions k x k
            int k = boardCanvas.Width;
            int cellSizePixels = k / boardSize;

            // draw the border of the board
            Point topLeftCorner = new Point(0, 0);
            Point topRightCorner = new Point(k - 1, 0);
            Point bottomLeftCorner = new Point(0, k - 1);
            Point bottomRightCorner = new Point(k - 1, k - 1);

            graphics.DrawLine(linePen, topLeftCorner, topRightCorner);
            graphics.DrawLine(linePen, topRightCorner, bottomRightCorner);
            graphics.DrawLine(linePen, bottomLeftCorner, bottomRightCorner);
            graphics.DrawLine(linePen, topLeftCorner, bottomLeftCorner);

            int lineCount = 0;

            // draw the lines that separate the rows and columns
            for (int i = 1; i < boardSize; i++)
            {
                int x = (int)((((float)i * (float)cellSizePixels) / (float)k) * k);

                // the points that make the lines that separate the rows
                Point rowLineStart = new Point(0, x);
                Point rowLineEnd = new Point(k, x);

                // the points that make the lines that separate the columns
                Point colLineStart = new Point(x, 0);
                Point colLineEnd = new Point(x, k);

                // draw the lines the separate the rows and columns
                if (i < k - cellSizePixels)
                {
                    graphics.DrawLine(linePen, rowLineStart, rowLineEnd);
                    graphics.DrawLine(linePen, colLineStart, colLineEnd);
                }

                lineCount++;
                   
            }
        }

    }
}
