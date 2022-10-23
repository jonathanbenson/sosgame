using System.Diagnostics;

using SOSLogic;

namespace SOSGame
{
    public partial class Form1 : Form
    {
        /*
         * The GUI of the SOS application
         * 
         */

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
            /*
             * Displays changed in the game state from the SOSEngine to the GUI.
             * 
             */

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

            // if the score display is accessible then make the corresponding controls accessible
            // else make them inaccessible
            if (accessibilityManager.IsScoreDisplayAccessible())
            {
                _blueScoreLabel.Show();
                _blueScore.Show();
                _blueScore.Text = sosEngine.GetCurrentGame().BlueScore().ToString();
                
                _redScoreLabel.Show();
                _redScore.Show();
                _redScore.Text = sosEngine.GetCurrentGame().RedScore().ToString();

            }
            else
            {
                _blueScoreLabel.Hide();
                _blueScore.Hide();
                
                _redScoreLabel.Hide();
                _redScore.Hide();
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

        private void boardCanvas_Paint(object sender, PaintEventArgs e)
        {
            /*
             * Event handler to initiate drawing on the game board (ex. drawing lines, S's, and O's)
             * 
             */

            boardPainter.DrawBoard();
        }

        private void boardCanvas_Click(object sender, EventArgs e)
        {
            /*
             * Event handler for when the game board is clicked (make a move in the SOS game)
             * 
             */
            
            Point point = boardCanvas.PointToClient(Cursor.Position);

            Tuple<int, int> rowCol = GetRowColOfPoint(point);

            int row = rowCol.Item1;
            int col = rowCol.Item2;


            try
            {
                // If the board is accessible (during a game), then let the player make a move
                if (accessibilityManager.IsBoardAccessible())
                    sosEngine.GetCurrentGame().GetCurrentPlayer().MakeMove(row, col);
                // else tell the user they need to start a new game if they want to play SOS
                else
                    MessageBox.Show("Start a new game to play!");
            }
            // if they player makes an invalid move, tell them they can't do that
            catch (ArgumentException exc)
            {
                MessageBox.Show(exc.Message);
            }

            // remember to display the changes in the GUI
            SyncSOSEngine();


        }

        private Tuple<int, int> GetRowColOfPoint(Point point)
        {
            /*
             * When a user clicks the board to make a move, this method will return the row and column
             * of the cell that was clicked.
             * 
             * The point argument is the place on the board that was clicked (relative to the control, not the screen)
             */
            
            int k = boardCanvas.Width;
            int boardSize = (int)_boardSizeNum.Value;
            int cellSizePixels = k / boardSize;

            for (int row = 0; row < boardSize; ++row)
            {
                for (int col = 0; col < boardSize; ++col)
                {
                    // get the positions of the rows and columns
                    int rLow = BoardPainter.Rasterize(row, cellSizePixels, k);
                    int rHigh = BoardPainter.Rasterize(row + 1, cellSizePixels, k);
                    int cLow = BoardPainter.Rasterize(col, cellSizePixels, k);
                    int cHigh = BoardPainter.Rasterize(col + 1, cellSizePixels, k);

                    // if the point is within the bounds of the cell, then return the row and column
                    if (point.X >= cLow - 5 && point.X <= cHigh + 5 && point.Y > rLow - 5 && point.Y <= rHigh + 5)
                        return Tuple.Create(row, col);

                }
            }

            // if the method gets here, then the application is experiencing undefined behavior
            throw new ArgumentException("Point is not on the board!");
        }

        private void _newGameButton_Click(object sender, EventArgs e)
        {
            /*
             * Event handler for when the new game button is clicked.
             * 
             */
            
            int boardSize = (int)_boardSizeNum.Value;

            // retrieve the desired game mode from the GUI control
            GameMode gameMode = GameMode.Simple;

            if (_generalGameRadio.Checked)
                gameMode = GameMode.General;

            // retrieve the desired player types from the GUI controls
            bool isBlueComputer = _bluePlayerComputerRadio.Checked;
            bool isRedComputer = _redPlayerComputerRadio.Checked;

            // create a new game with the desired settings
            sosEngine.StartGame(gameMode, boardSize, isBlueComputer, isRedComputer);

            // the board painter needs to have reference to the new game
            // in order to display the game board correctly
            boardPainter.SetGame(sosEngine.GetCurrentGame());

            // display the changes in the GUI
            SyncSOSEngine();
        }

        private void _bluePlayerSRadio_CheckedChanged(object sender, EventArgs e)
        {
            // event handler for when the blue player wants to use S
            
            if (_bluePlayerSRadio.Checked)
                sosEngine.GetCurrentGame().GetBluePlayer().SetMoveType(MoveType.S);
        }

        private void _bluePlayerORadio_CheckedChanged(object sender, EventArgs e)
        {
            // event handler for when the blue player wants to use O
            
            if (_bluePlayerORadio.Checked)
                sosEngine.GetCurrentGame().GetBluePlayer().SetMoveType(MoveType.O);
        }
        
        private void _redPlayerSRadio_CheckedChanged(object sender, EventArgs e)
        {
            // event handler for when the red player wants to use S
            
            if (_redPlayerSRadio.Checked)
                sosEngine.GetCurrentGame().GetRedPlayer().SetMoveType(MoveType.S);
        }

        private void _redPlayerORadio_CheckedChanged(object sender, EventArgs e)
        {
            // event handler for when the red player wants to use O
            
            if (_redPlayerORadio.Checked)
                sosEngine.GetCurrentGame().GetRedPlayer().SetMoveType(MoveType.O);
        }

        private void _sourceCodeLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // event handler for when the source code link is clicked
            // opens the source code (github) in the default browser
            
            try
            {
                OpenSourceCodeLink();
            }
            catch (Exception exc)
            {
                MessageBox.Show("Source code link invalid.");
            }
        }

        private void OpenSourceCodeLink()
        {
            // opens the source code (github) in the default browser
            
            _sourceCodeLink.LinkVisited = true;

            var processInfo = new ProcessStartInfo("http://github.com/jonathanbenson/sosgame")
            {
                UseShellExecute = true,
                Verb = "open"
            };
            
            Process.Start(processInfo);
        }

        private void _boardSizeNum_ValueChanged(object sender, EventArgs e)
        {
            /*
             * Event handler for when the board size selector is changed.
             * 
             */

            SyncSOSEngine();
            boardPainter.DrawBoard();
        }
    }
}