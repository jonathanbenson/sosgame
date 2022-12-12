using System.Diagnostics;
using System.Linq.Expressions;
using System.Xml.Linq;
using SOSLogic;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

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

        // miliseconds
        long computerPlayerMoveDecisionTime = 1000;

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

            try
            {
                Game game = sosEngine.GetCurrentGame();

                Player redPlayer = game.GetRedPlayer();
                Player bluePlayer = game.GetBluePlayer();

                _redPlayerSRadio.Checked = redPlayer.GetMoveType() == MoveType.S ? true : false;
                _redPlayerORadio.Checked = redPlayer.GetMoveType() == MoveType.O ? true : false;
                _bluePlayerSRadio.Checked = bluePlayer.GetMoveType() == MoveType.S ? true : false;
                _bluePlayerORadio.Checked = bluePlayer.GetMoveType() == MoveType.O ? true : false;
            }
            catch (Exception exc)
            {
                
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
                {
                    Game game = sosEngine.GetCurrentGame();
                    
                    game.GetCurrentPlayer().MakeMove(row, col);

                    boardPainter.DrawBoard();

                    // End the current game if it is over
                    EndGameIfOver();

                    // remember to display the changes in the GUI
                    SyncSOSEngine();
                    boardPainter.DrawBoard();

                    try
                    {
                        // if the next player is a computer, then make a move for them
                        if (sosEngine.GetCurrentGame().GetCurrentPlayer().GetPlayerType() == PlayerType.Computer)
                            ComputerPlayerMakeMove();
                    }
                    // an exception is thrown if the last move ended the game
                    catch (Exception exc)
                    {
                        return;
                    }
                }
                // else tell the user they need to start a new game if they want to play SOS
                else
                {
                    try
                    {
                        Game game = sosEngine.GetCurrentGame();

                        MessageBox.Show("It is the computer player's turn!");
                    }
                    catch (Exception exc)
                    {
                        MessageBox.Show("Start a new game to play!");
                    }
                }
                    
            }
            // if they player makes an invalid move, tell them they can't do that
            catch (ArgumentException exc)
            {
                MessageBox.Show(exc.Message);
            }



        }

        bool EndGameIfOver(bool isReplay = false)
        {
            Game game = sosEngine.GetCurrentGame();

            // If the game is over, then display the winner
            if (game.IsOver())
            {
                Player? winner = game.GetWinner();

                if (winner == null)
                    MessageBox.Show("The game is a draw!");
                else
                {
                    if (winner == game.GetBluePlayer())
                        MessageBox.Show("Blue is the winner!");
                    else
                        MessageBox.Show("Red is the winner!");
                }

                if (isReplay)
                    sosEngine.EndReplay();
                else
                    sosEngine.EndGame();

                return true;
            }
            else
                return false;
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

            bool recordGame = _recordGameCheckBox.Checked;

            // retrieve the desired game mode from the GUI control
            GameMode gameMode = GameMode.Simple;

            if (_generalGameRadio.Checked)
                gameMode = GameMode.General;

            // retrieve the desired player types from the GUI controls
            PlayerType bluePlayerType = _bluePlayerComputerRadio.Checked ? PlayerType.Computer : PlayerType.Human;
            PlayerType redPlayerType = _redPlayerComputerRadio.Checked ? PlayerType.Computer : PlayerType.Human;

            // create a new game with the desired settings
            sosEngine.StartGame(recordGame, gameMode, boardSize, bluePlayerType, redPlayerType);

            // set the move types of the players
            Game game = sosEngine.GetCurrentGame();
            game.GetBluePlayer().SetMoveType(_bluePlayerSRadio.Checked ? MoveType.S : MoveType.O);
            game.GetRedPlayer().SetMoveType(_redPlayerSRadio.Checked ? MoveType.S : MoveType.O);

            // the board painter needs to have reference to the new game
            // in order to display the game board correctly
            boardPainter.SetGame(sosEngine.GetCurrentGame());

            // display the changes in the GUI
            SyncSOSEngine();

            // if the starting player is a computer, then make a move for them
            if (game.GetCurrentPlayer().GetPlayerType() == PlayerType.Computer)
                ComputerPlayerMakeMove();

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

        private async void ComputerPlayerMakeMove()
        {
            if (sosEngine.InGame())
                await Task.Run(async () =>
                {
                    ComputerPlayer computerPlayer = (ComputerPlayer)sosEngine.GetCurrentGame().GetCurrentPlayer();

                    // make the move
                    computerPlayer.ChooseRandomMoveType();

                    Invoke(new MethodInvoker(delegate { SyncSOSEngine(); }));

                    var watch = new System.Diagnostics.Stopwatch();

                    watch.Start();
                    computerPlayer.MakeMove();
                    watch.Stop();

                    if (watch.ElapsedMilliseconds < computerPlayerMoveDecisionTime)
                        await Task.Delay((int)(computerPlayerMoveDecisionTime - watch.ElapsedMilliseconds));

                    boardPainter.DrawBoard();


                    if (!EndGameIfOver())
                    {
                        // if the player of the next turn is a computer, then make a move for them
                        Player nextPlayer = sosEngine.GetCurrentGame().GetCurrentPlayer();

                        if (nextPlayer.GetPlayerType() == PlayerType.Computer)
                            ComputerPlayerMakeMove();
                    }

                    Invoke(new MethodInvoker(delegate { SyncSOSEngine(); }));
                });
        }

        private async void _replayButton_Click(object sender, EventArgs e)
        {

            Replay replay = new Replay();

            // Parse all the moves associated with the previous game
            replay.Parse("PreviousGame.txt");

            sosEngine.SetInReplay(true);

            Game previousGame = sosEngine.GetPreviousGame();
            sosEngine.StartGame(false, previousGame.GetGameMode(), previousGame.GetBoardSize(), previousGame.GetBluePlayer().GetPlayerType(), previousGame.GetRedPlayer().GetPlayerType());
            Game currentGame = sosEngine.GetCurrentGame();

            boardPainter.SetGame(currentGame);
            while (!currentGame.IsOver())
            {
                // Put the next move on the screen
                await Task.Run(async () =>
                {

                    Invoke(new MethodInvoker(delegate { boardPainter.DrawBoard(); SyncSOSEngine(); }));

                    await Task.Delay(1000);

                    MoveEntry nextMoveEntry = replay.GetNextMoveEntry();

                    Move nextMove = new Move(currentGame.GetCurrentPlayer(), nextMoveEntry.moveType == "S" ? MoveType.S : MoveType.O, nextMoveEntry.row, nextMoveEntry.col);

                    currentGame.MakeMove(nextMove);
                });

            }

            SyncSOSEngine();
            boardPainter.DrawBoard();

            // End the game and display the game result
            EndGameIfOver(true);
            sosEngine.SetInReplay(false);

            SyncSOSEngine();
            boardPainter.DrawBoard();

        }
    }
}