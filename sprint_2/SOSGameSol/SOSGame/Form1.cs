using System.Diagnostics;

using SOSLogic;

namespace SOSGame
{
    public partial class Form1 : Form
    {

        // Object that paints the board canvas to create the SOS game board
        BoardPainter boardPainter;
        AccessibilityManager accessibilityManager;
        SOSEngine sosEngine;

        public Form1()
        {
            InitializeComponent();

            Graphics graphics = boardCanvas.CreateGraphics();
            boardPainter = new BoardPainter(boardCanvas, _boardSizeNum, graphics);

            sosEngine = new SOSEngine();
            accessibilityManager = new AccessibilityManager(sosEngine);

            SyncSOSEngine();
        }

        public void SyncSOSEngine()
        {

            // if the game mode selector is accessible then make the corresponding controls accessible
            // else make them inacccessible
            if (accessibilityManager.IsGameModeAccessible())
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
            if (accessibilityManager.IsBlueRoleAccessible())
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
            if (accessibilityManager.IsRedRoleAccessible())
            {
                _redPlayerComputerRadio.Enabled = true;
                _redPlayerHumanRadio.Enabled = true;
            }
            else
            {
                _redPlayerComputerRadio.Enabled = false;
                _redPlayerHumanRadio.Enabled = false;
            }

            // if the record game button is accessible then make its corresponding control accessible
            // else make it inaccessible
            if (accessibilityManager.IsRecordButtonAccessible())
                _recordGameCheckBox.Enabled = true;
            else
                _recordGameCheckBox.Enabled = false;

            // if the replay button is accessible then make its corresponding control accessible
            // else make it inaccessible
            if (accessibilityManager.IsReplayButtonAccessible())
                _replayButton.Enabled = true;
            else
                _replayButton.Enabled = false;

            // if the new game button is accessible then make its corresponding control accessible
            // else make it inaccessible
            if (accessibilityManager.IsNewGameButtonAccessible())
                _newGameButton.Enabled = true;
            else
                _newGameButton.Enabled = false;

            // if the board size selector is accessible then make the corresponding controls accessible
            // else make it inaccessible
            if (accessibilityManager.IsBoardSizeAccessible())
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
            if (accessibilityManager.IsBlueSOAccessible())
                _blueSOGroupBox.Enabled = true;
            else
                _blueSOGroupBox.Enabled = false;

            // if the red SO controls are accessible then make the corresponding controls accessible
            // else make them inaccessible
            if (accessibilityManager.IsRedSOAccessible())
                _redSOGroupBox.Enabled = true;
            else
                _redSOGroupBox.Enabled = false;

            // if the quit replay button is accessible then make the corresponding control accessible
            // else make it inaccessible
            if (accessibilityManager.IsQuitReplayButtonAccessible())
                _quitReplayButton.Show();
            else
                _quitReplayButton.Hide();

            if (accessibilityManager.IsBoardAccessible())
                boardPainter.DrawBoard();

            // if the current turn display is accessible then make the corresponding control accessible
            // else make it inaccessible
            if (accessibilityManager.IsCurrentTurnDisplayAccessible())
            {
                _currentTurnLabel.Show();
                _currentTurn.Show();
            }
            else
            {
                _currentTurnLabel.Hide();
                _currentTurn.Hide();
            }

            // During a game...
            // Tell who the current player is and what their color is
            if (sosEngine.IsRedTurn())
            {
                _currentTurn.Text = "Red";
                _currentTurn.ForeColor = Color.Red;
            }
            else
            {
                _currentTurn.Text = "Blue";
                _currentTurn.ForeColor = Color.Blue;
            }

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            SyncSOSEngine();
            boardPainter.DrawBoard();
        }

        private void boardCanvas_Paint(object sender, PaintEventArgs e)
        {
            boardPainter.DrawBoard();
        }

        private void boardCanvas_Click(object sender, EventArgs e)
        {
            Point point = boardCanvas.PointToClient(Cursor.Position);

            Tuple<int, int> rowCol = GetRowColOfPoint(point);

            int row = rowCol.Item1;
            int col = rowCol.Item2;

            try
            {
                if (accessibilityManager.IsBoardAccessible())
                    sosEngine.GetCurrentGame().GetCurrentPlayer().MakeMove(row, col);
                else
                    MessageBox.Show("Start a new game to play!");

                SyncSOSEngine();
            }
            catch (ArgumentException exc)
            {
                MessageBox.Show(exc.Message);
            }

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

        private void _newGameButton_Click(object sender, EventArgs e)
        {
            sosEngine.StartGame();
            boardPainter.SetGame(sosEngine.GetCurrentGame());

            SyncSOSEngine();
        }

        private void _bluePlayerSRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (_bluePlayerSRadio.Checked)
                sosEngine.GetCurrentGame().GetBluePlayer().SetMoveType(MoveType.S);
        }

        private void _bluePlayerORadio_CheckedChanged(object sender, EventArgs e)
        {
            if (_bluePlayerORadio.Checked)
                sosEngine.GetCurrentGame().GetBluePlayer().SetMoveType(MoveType.O);
        }
        
        private void _redPlayerSRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (_redPlayerSRadio.Checked)
                sosEngine.GetCurrentGame().GetRedPlayer().SetMoveType(MoveType.S);
        }

        private void _redPlayerORadio_CheckedChanged(object sender, EventArgs e)
        {
            if (_redPlayerORadio.Checked)
                sosEngine.GetCurrentGame().GetRedPlayer().SetMoveType(MoveType.O);
        }
    }
}