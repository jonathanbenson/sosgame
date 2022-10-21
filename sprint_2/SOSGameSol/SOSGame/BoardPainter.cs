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
        }

        public static int Rasterize(int index, int cellSizePixels, int k)
        {
            // index = row or column number
            // cellSizePixels = number of pixels of a cell square dimensions
            // k = number of total pixels of the length of the game board

            return (int)((((float)index * (float)cellSizePixels) / (float)k) * k);
        }

        private void DrawLetter(char letter, float x, float y, Color color)
        {

            // convert the letter to a string (S or O)
            String strToDraw = letter.ToString();

            // create the font and brush for drawing
            Font drawFont = new Font("Arial", 16);
            SolidBrush drawBrush = new SolidBrush(color);

            // make it so the letter is centered inside of a square
            StringFormat drawFormat = new StringFormat();
            drawFormat.LineAlignment = StringAlignment.Center;
            drawFormat.Alignment = StringAlignment.Center;

            // draw the S or O to the screen
            graphics.DrawString(strToDraw, drawFont, drawBrush, x, y, drawFormat);
        }

        public void DrawS(int row, int col, bool isRed = false)
        {
            // obtain the board size from the board size numeric updown control
            int boardSize = (int)boardSizeNum.Value;

            // size = k, while the board has dimensions k x k
            int k = boardCanvas.Width;
            int cellSizePixels = k / boardSize;

            // x and y coordinates of the point that the S will center on
            int x = Rasterize(col, cellSizePixels, k) + (int)(.5f * cellSizePixels);
            int y = Rasterize(row, cellSizePixels, k) + (int)(.5f * cellSizePixels);

            // draw the S
            DrawLetter('S', x, y, isRed ? Color.Red : Color.Blue);
        }

        public void DrawO(int row, int col, bool isRed = false)
        {
            // obtain the board size from the board size numeric updown control
            int boardSize = (int)boardSizeNum.Value;

            // size = k, while the board has dimensions k x k
            int k = boardCanvas.Width;
            int cellSizePixels = k / boardSize;

            // x and y coordinates of the point that the O will center on
            int x = Rasterize(col, cellSizePixels, k) + (int)(.5f * cellSizePixels);
            int y = Rasterize(row, cellSizePixels, k) + (int)(.5f * cellSizePixels);

            DrawLetter('O', x, y, isRed ? Color.Red : Color.Blue);
        }

        public void DrawSOSLine(int startRow, int startCol, int endRow, int endCol, bool isRed = false)
        {
            // obtain the board size from the board size numeric updown control
            int boardSize = (int)boardSizeNum.Value;

            // size = k, while the board has dimensions k x k
            int k = boardCanvas.Width;
            int cellSizePixels = k / boardSize;

            // x and y coordinates of the start point of the line
            int x1 = Rasterize(startCol, cellSizePixels, k) + (int)(.5f * cellSizePixels);
            int y1 = Rasterize(startRow, cellSizePixels, k) + (int)(.5f * cellSizePixels);

            // x and y coordinates of the end point of the line
            int x2 = Rasterize(endCol, cellSizePixels, k) + (int)(.5f * cellSizePixels);
            int y2 = Rasterize(endRow, cellSizePixels, k) + (int)(.5f * cellSizePixels);

            // draw the border of the board
            Point startPoint = new Point(x1, y1);
            Point endPoint = new Point(x2, y2);

            // pen used to draw the border, as well as row and column lines
            Pen linePen = new Pen(isRed ? Color.Red : Color.Blue, 2f);

            // draw the line connecting the two squares
            graphics.DrawLine(linePen, startPoint, endPoint);
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
                int x = Rasterize(i, cellSizePixels, k);

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
