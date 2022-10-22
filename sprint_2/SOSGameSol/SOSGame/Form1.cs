using System.Diagnostics;

using SOSLogic;

namespace SOSGame
{
    public partial class Form1 : Form
    {

        // Object that paints the board canvas to create the SOS game board
        BoardPainter boardPainter;
        Board board;

        public Form1()
        {
            InitializeComponent();

            board = new Board();
            
            Update();
        }

        public void Update()
        {

            // if the game mode selector is accessible then make the corresponding controls accessible
            // else make them inacccessible
            if (board.IsGameModeAccessible())
            {
                _generalGameRadio.Enabled = true;
                _simpleGameRadio.Enabled = true;
            }
            else
            {
                _generalGameRadio.Enabled = false;
                _simpleGameRadio.Enabled = false;
            }

            // if the blue role selection is accessible then make the corresponding controls accesible
            // else make them inaccessible
            if (board.IsBlueRoleAccessible())
            {
                _bluePlayerComputerRadio.Enabled = true;
                _bluePlayerHumanRadio.Enabled = true;
            }
            else
            {
                _bluePlayerComputerRadio.Enabled = false;
                _bluePlayerHumanRadio.Enabled = false;
            }

            // if the red role selection is accessible then make the corresponding controls accesible
            // else make them inaccessible
            if (board.IsRedRoleAccessible())
            {
                _redPlayerComputerRadio.Enabled = true;
                _redPlayerHumanRadio.Enabled = true;
            }
            else
            {
                _redPlayerComputerRadio.Enabled= false;
                _redPlayerHumanRadio.Enabled= false;
            }

            // if the record game button is accessible then make its corresponding control accessible
            // else make it inaccessible
            if (board.IsRecordButtonAccessible())
                _recordGameCheckBox.Enabled = true;
            else
                _recordGameCheckBox.Enabled= false;

            // if the replay button is accessible then make its corresponding control accessible
            // else make it inaccessible
            if (board.IsReplayButtonAccessible())
                _replayButton.Enabled = true;
            else
                _replayButton.Enabled= false;

            // if the new game button is accessible then make its corresponding control accessible
            // else make it inaccessible
            if (board.IsNewGameButtonAccessible())
                _newGameButton.Enabled = true;
            else
                _newGameButton.Enabled= false;

            // if the board size selector is accessible then make the corresponding controls accessible
            // else make it inaccessible
            if (board.IsBoardSizeAccessible())
            {
                _boardSizeLabel.Enabled = true;
                _boardSizeNum.Enabled = true;
            }
            else
            {
                _boardSizeLabel.Enabled = false;
                _boardSizeNum.Enabled = false;
            }

            // if the blue SO controls are accessible then make the corresponding controls accessible
            // else make them inaccessible
            if (board.IsBlueSOAccessible())
                _blueSOGroupBox.Enabled = true;
            else
                _blueSOGroupBox.Enabled = false;

            // if the red SO controls are accessible then make the corresponding controls accessible
            // else make them inaccessible
            if (board.IsRedSOAccessible())
                _redSOGroupBox.Enabled = true;
            else
                _redSOGroupBox.Enabled = false;

            // if the quit replay button is accessible then make the corresponding control accessible
            // else make it inaccessible
            if (board.IsQuitReplayButtonAccessible())
                _quitReplayButton.Enabled = true;
            else
                _quitReplayButton.Enabled = false;

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            Update();
            boardPainter.DrawBoard();
        }

        private void boardCanvas_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = boardCanvas.CreateGraphics();

            boardPainter = new BoardPainter(boardCanvas, _boardSizeNum, graphics);

            boardPainter.DrawBoard();
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