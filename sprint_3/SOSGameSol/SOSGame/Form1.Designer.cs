namespace SOSGame
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this._topGroupBox = new System.Windows.Forms.GroupBox();
            this._boardSizeLabel = new System.Windows.Forms.Label();
            this._boardSizeNum = new System.Windows.Forms.NumericUpDown();
            this._generalGameRadio = new System.Windows.Forms.RadioButton();
            this._simpleGameRadio = new System.Windows.Forms.RadioButton();
            this._recordGameCheckBox = new System.Windows.Forms.CheckBox();
            this._currentTurnLabel = new System.Windows.Forms.Label();
            this._currentTurn = new System.Windows.Forms.Label();
            this._newGameButton = new System.Windows.Forms.Button();
            this._replayButton = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this._quitReplayButton = new System.Windows.Forms.Button();
            this._bluePlayerGroupBox = new System.Windows.Forms.GroupBox();
            this._redScore = new System.Windows.Forms.Label();
            this._blueScoreLabel = new System.Windows.Forms.Label();
            this._blueSOGroupBox = new System.Windows.Forms.GroupBox();
            this._bluePlayerSRadio = new System.Windows.Forms.RadioButton();
            this._bluePlayerORadio = new System.Windows.Forms.RadioButton();
            this._bluePlayerHumanRadio = new System.Windows.Forms.RadioButton();
            this._bluePlayerComputerRadio = new System.Windows.Forms.RadioButton();
            this._redPlayerGroupBox = new System.Windows.Forms.GroupBox();
            this._blueScore = new System.Windows.Forms.Label();
            this._redScoreLabel = new System.Windows.Forms.Label();
            this._redSOGroupBox = new System.Windows.Forms.GroupBox();
            this._redPlayerSRadio = new System.Windows.Forms.RadioButton();
            this._redPlayerORadio = new System.Windows.Forms.RadioButton();
            this._redPlayerHumanRadio = new System.Windows.Forms.RadioButton();
            this._redPlayerComputerRadio = new System.Windows.Forms.RadioButton();
            this.boardCanvas = new System.Windows.Forms.Panel();
            this._sourceCodeLink = new System.Windows.Forms.LinkLabel();
            this._topGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._boardSizeNum)).BeginInit();
            this.groupBox2.SuspendLayout();
            this._bluePlayerGroupBox.SuspendLayout();
            this._blueSOGroupBox.SuspendLayout();
            this._redPlayerGroupBox.SuspendLayout();
            this._redSOGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            // 
            // _topGroupBox
            // 
            this._topGroupBox.Controls.Add(this._boardSizeLabel);
            this._topGroupBox.Controls.Add(this._boardSizeNum);
            this._topGroupBox.Controls.Add(this._generalGameRadio);
            this._topGroupBox.Controls.Add(this._simpleGameRadio);
            this._topGroupBox.Location = new System.Drawing.Point(12, 12);
            this._topGroupBox.Name = "_topGroupBox";
            this._topGroupBox.Size = new System.Drawing.Size(680, 46);
            this._topGroupBox.TabIndex = 0;
            this._topGroupBox.TabStop = false;
            this._topGroupBox.Text = "SOS Game";
            // 
            // _boardSizeLabel
            // 
            this._boardSizeLabel.AutoSize = true;
            this._boardSizeLabel.Location = new System.Drawing.Point(525, 19);
            this._boardSizeLabel.Name = "_boardSizeLabel";
            this._boardSizeLabel.Size = new System.Drawing.Size(61, 15);
            this._boardSizeLabel.TabIndex = 4;
            this._boardSizeLabel.Text = "Board Size";
            // 
            // _boardSizeNum
            // 
            this._boardSizeNum.Location = new System.Drawing.Point(592, 17);
            this._boardSizeNum.Maximum = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this._boardSizeNum.Minimum = new decimal(new int[] {
            6,
            0,
            0,
            0});
            this._boardSizeNum.Name = "_boardSizeNum";
            this._boardSizeNum.Size = new System.Drawing.Size(82, 23);
            this._boardSizeNum.TabIndex = 3;
            this._boardSizeNum.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this._boardSizeNum.ValueChanged += new System.EventHandler(this._boardSizeNum_ValueChanged);
            // 
            // _generalGameRadio
            // 
            this._generalGameRadio.AutoSize = true;
            this._generalGameRadio.Location = new System.Drawing.Point(107, 21);
            this._generalGameRadio.Name = "_generalGameRadio";
            this._generalGameRadio.Size = new System.Drawing.Size(99, 19);
            this._generalGameRadio.TabIndex = 2;
            this._generalGameRadio.Text = "General Game";
            this._generalGameRadio.UseVisualStyleBackColor = true;
            // 
            // _simpleGameRadio
            // 
            this._simpleGameRadio.AutoSize = true;
            this._simpleGameRadio.Checked = true;
            this._simpleGameRadio.Location = new System.Drawing.Point(6, 21);
            this._simpleGameRadio.Name = "_simpleGameRadio";
            this._simpleGameRadio.Size = new System.Drawing.Size(95, 19);
            this._simpleGameRadio.TabIndex = 1;
            this._simpleGameRadio.TabStop = true;
            this._simpleGameRadio.Text = "Simple Game";
            this._simpleGameRadio.UseVisualStyleBackColor = true;
            // 
            // _recordGameCheckBox
            // 
            this._recordGameCheckBox.AutoSize = true;
            this._recordGameCheckBox.Location = new System.Drawing.Point(6, 25);
            this._recordGameCheckBox.Name = "_recordGameCheckBox";
            this._recordGameCheckBox.Size = new System.Drawing.Size(97, 19);
            this._recordGameCheckBox.TabIndex = 5;
            this._recordGameCheckBox.Text = "Record Game";
            this._recordGameCheckBox.UseVisualStyleBackColor = true;
            // 
            // _currentTurnLabel
            // 
            this._currentTurnLabel.AutoSize = true;
            this._currentTurnLabel.Location = new System.Drawing.Point(12, 432);
            this._currentTurnLabel.Name = "_currentTurnLabel";
            this._currentTurnLabel.Size = new System.Drawing.Size(75, 15);
            this._currentTurnLabel.TabIndex = 1;
            this._currentTurnLabel.Text = "Current turn:";
            // 
            // _currentTurn
            // 
            this._currentTurn.AutoSize = true;
            this._currentTurn.ForeColor = System.Drawing.Color.DodgerBlue;
            this._currentTurn.Location = new System.Drawing.Point(85, 432);
            this._currentTurn.Name = "_currentTurn";
            this._currentTurn.Size = new System.Drawing.Size(30, 15);
            this._currentTurn.TabIndex = 2;
            this._currentTurn.Text = "blue";
            // 
            // _newGameButton
            // 
            this._newGameButton.Location = new System.Drawing.Point(599, 22);
            this._newGameButton.Name = "_newGameButton";
            this._newGameButton.Size = new System.Drawing.Size(75, 23);
            this._newGameButton.TabIndex = 3;
            this._newGameButton.Text = "New Game";
            this._newGameButton.UseVisualStyleBackColor = true;
            this._newGameButton.Click += new System.EventHandler(this._newGameButton_Click);
            // 
            // _replayButton
            // 
            this._replayButton.Location = new System.Drawing.Point(519, 22);
            this._replayButton.Name = "_replayButton";
            this._replayButton.Size = new System.Drawing.Size(75, 23);
            this._replayButton.TabIndex = 4;
            this._replayButton.Text = "Replay";
            this._replayButton.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this._quitReplayButton);
            this.groupBox2.Controls.Add(this._recordGameCheckBox);
            this.groupBox2.Controls.Add(this._replayButton);
            this.groupBox2.Controls.Add(this._newGameButton);
            this.groupBox2.Location = new System.Drawing.Point(12, 375);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(680, 54);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            // 
            // _quitReplayButton
            // 
            this._quitReplayButton.Location = new System.Drawing.Point(422, 22);
            this._quitReplayButton.Name = "_quitReplayButton";
            this._quitReplayButton.Size = new System.Drawing.Size(91, 23);
            this._quitReplayButton.TabIndex = 6;
            this._quitReplayButton.Text = "Quit Replay";
            this._quitReplayButton.UseVisualStyleBackColor = true;
            // 
            // _bluePlayerGroupBox
            // 
            this._bluePlayerGroupBox.Controls.Add(this._blueScoreLabel);
            this._bluePlayerGroupBox.Controls.Add(this._blueScore);
            this._bluePlayerGroupBox.Controls.Add(this._blueSOGroupBox);
            this._bluePlayerGroupBox.Controls.Add(this._bluePlayerHumanRadio);
            this._bluePlayerGroupBox.Controls.Add(this._bluePlayerComputerRadio);
            this._bluePlayerGroupBox.Location = new System.Drawing.Point(12, 64);
            this._bluePlayerGroupBox.Name = "_bluePlayerGroupBox";
            this._bluePlayerGroupBox.Size = new System.Drawing.Size(194, 305);
            this._bluePlayerGroupBox.TabIndex = 8;
            this._bluePlayerGroupBox.TabStop = false;
            this._bluePlayerGroupBox.Text = "Blue Player";
            // 
            // _redScore
            // 
            this._redScore.AutoSize = true;
            this._redScore.Location = new System.Drawing.Point(44, 287);
            this._redScore.Name = "_redScore";
            this._redScore.Size = new System.Drawing.Size(13, 15);
            this._redScore.TabIndex = 12;
            this._redScore.Text = "0";
            // 
            // _blueScoreLabel
            // 
            this._blueScoreLabel.AutoSize = true;
            this._blueScoreLabel.Location = new System.Drawing.Point(6, 287);
            this._blueScoreLabel.Name = "_blueScoreLabel";
            this._blueScoreLabel.Size = new System.Drawing.Size(39, 15);
            this._blueScoreLabel.TabIndex = 11;
            this._blueScoreLabel.Text = "Score:";
            // 
            // _blueSOGroupBox
            // 
            this._blueSOGroupBox.Controls.Add(this._bluePlayerSRadio);
            this._blueSOGroupBox.Controls.Add(this._bluePlayerORadio);
            this._blueSOGroupBox.Location = new System.Drawing.Point(6, 72);
            this._blueSOGroupBox.Name = "_blueSOGroupBox";
            this._blueSOGroupBox.Size = new System.Drawing.Size(182, 65);
            this._blueSOGroupBox.TabIndex = 9;
            this._blueSOGroupBox.TabStop = false;
            // 
            // _bluePlayerSRadio
            // 
            this._bluePlayerSRadio.AutoSize = true;
            this._bluePlayerSRadio.Checked = true;
            this._bluePlayerSRadio.Location = new System.Drawing.Point(17, 13);
            this._bluePlayerSRadio.Name = "_bluePlayerSRadio";
            this._bluePlayerSRadio.Size = new System.Drawing.Size(31, 19);
            this._bluePlayerSRadio.TabIndex = 7;
            this._bluePlayerSRadio.TabStop = true;
            this._bluePlayerSRadio.Text = "S";
            this._bluePlayerSRadio.UseVisualStyleBackColor = true;
            this._bluePlayerSRadio.CheckedChanged += new System.EventHandler(this._bluePlayerSRadio_CheckedChanged);
            // 
            // _bluePlayerORadio
            // 
            this._bluePlayerORadio.AutoSize = true;
            this._bluePlayerORadio.Location = new System.Drawing.Point(17, 38);
            this._bluePlayerORadio.Name = "_bluePlayerORadio";
            this._bluePlayerORadio.Size = new System.Drawing.Size(34, 19);
            this._bluePlayerORadio.TabIndex = 8;
            this._bluePlayerORadio.Text = "O";
            this._bluePlayerORadio.UseVisualStyleBackColor = true;
            this._bluePlayerORadio.CheckedChanged += new System.EventHandler(this._bluePlayerORadio_CheckedChanged);
            // 
            // _bluePlayerHumanRadio
            // 
            this._bluePlayerHumanRadio.AutoSize = true;
            this._bluePlayerHumanRadio.Checked = true;
            this._bluePlayerHumanRadio.Location = new System.Drawing.Point(6, 47);
            this._bluePlayerHumanRadio.Name = "_bluePlayerHumanRadio";
            this._bluePlayerHumanRadio.Size = new System.Drawing.Size(65, 19);
            this._bluePlayerHumanRadio.TabIndex = 6;
            this._bluePlayerHumanRadio.TabStop = true;
            this._bluePlayerHumanRadio.Text = "Human";
            this._bluePlayerHumanRadio.UseVisualStyleBackColor = true;
            // 
            // _bluePlayerComputerRadio
            // 
            this._bluePlayerComputerRadio.AutoSize = true;
            this._bluePlayerComputerRadio.Location = new System.Drawing.Point(6, 22);
            this._bluePlayerComputerRadio.Name = "_bluePlayerComputerRadio";
            this._bluePlayerComputerRadio.Size = new System.Drawing.Size(79, 19);
            this._bluePlayerComputerRadio.TabIndex = 5;
            this._bluePlayerComputerRadio.Text = "Computer";
            this._bluePlayerComputerRadio.UseVisualStyleBackColor = true;
            // 
            // _redPlayerGroupBox
            // 
            this._redPlayerGroupBox.Controls.Add(this._redScore);
            this._redPlayerGroupBox.Controls.Add(this._redScoreLabel);
            this._redPlayerGroupBox.Controls.Add(this._redSOGroupBox);
            this._redPlayerGroupBox.Controls.Add(this._redPlayerHumanRadio);
            this._redPlayerGroupBox.Controls.Add(this._redPlayerComputerRadio);
            this._redPlayerGroupBox.Location = new System.Drawing.Point(518, 64);
            this._redPlayerGroupBox.Name = "_redPlayerGroupBox";
            this._redPlayerGroupBox.Size = new System.Drawing.Size(174, 305);
            this._redPlayerGroupBox.TabIndex = 9;
            this._redPlayerGroupBox.TabStop = false;
            this._redPlayerGroupBox.Text = "Red Player";
            // 
            // _blueScore
            // 
            this._blueScore.AutoSize = true;
            this._blueScore.Location = new System.Drawing.Point(44, 287);
            this._blueScore.Name = "_blueScore";
            this._blueScore.Size = new System.Drawing.Size(13, 15);
            this._blueScore.TabIndex = 13;
            this._blueScore.Text = "0";
            // 
            // _redScoreLabel
            // 
            this._redScoreLabel.AutoSize = true;
            this._redScoreLabel.Location = new System.Drawing.Point(6, 287);
            this._redScoreLabel.Name = "_redScoreLabel";
            this._redScoreLabel.Size = new System.Drawing.Size(39, 15);
            this._redScoreLabel.TabIndex = 12;
            this._redScoreLabel.Text = "Score:";
            // 
            // _redSOGroupBox
            // 
            this._redSOGroupBox.Controls.Add(this._redPlayerSRadio);
            this._redSOGroupBox.Controls.Add(this._redPlayerORadio);
            this._redSOGroupBox.Location = new System.Drawing.Point(6, 72);
            this._redSOGroupBox.Name = "_redSOGroupBox";
            this._redSOGroupBox.Size = new System.Drawing.Size(162, 65);
            this._redSOGroupBox.TabIndex = 10;
            this._redSOGroupBox.TabStop = false;
            // 
            // _redPlayerSRadio
            // 
            this._redPlayerSRadio.AutoSize = true;
            this._redPlayerSRadio.Checked = true;
            this._redPlayerSRadio.Location = new System.Drawing.Point(17, 13);
            this._redPlayerSRadio.Name = "_redPlayerSRadio";
            this._redPlayerSRadio.Size = new System.Drawing.Size(31, 19);
            this._redPlayerSRadio.TabIndex = 7;
            this._redPlayerSRadio.TabStop = true;
            this._redPlayerSRadio.Text = "S";
            this._redPlayerSRadio.UseVisualStyleBackColor = true;
            this._redPlayerSRadio.CheckedChanged += new System.EventHandler(this._redPlayerSRadio_CheckedChanged);
            // 
            // _redPlayerORadio
            // 
            this._redPlayerORadio.AutoSize = true;
            this._redPlayerORadio.Location = new System.Drawing.Point(17, 38);
            this._redPlayerORadio.Name = "_redPlayerORadio";
            this._redPlayerORadio.Size = new System.Drawing.Size(34, 19);
            this._redPlayerORadio.TabIndex = 8;
            this._redPlayerORadio.Text = "O";
            this._redPlayerORadio.UseVisualStyleBackColor = true;
            this._redPlayerORadio.CheckedChanged += new System.EventHandler(this._redPlayerORadio_CheckedChanged);
            // 
            // _redPlayerHumanRadio
            // 
            this._redPlayerHumanRadio.AutoSize = true;
            this._redPlayerHumanRadio.Checked = true;
            this._redPlayerHumanRadio.Location = new System.Drawing.Point(6, 47);
            this._redPlayerHumanRadio.Name = "_redPlayerHumanRadio";
            this._redPlayerHumanRadio.Size = new System.Drawing.Size(65, 19);
            this._redPlayerHumanRadio.TabIndex = 6;
            this._redPlayerHumanRadio.TabStop = true;
            this._redPlayerHumanRadio.Text = "Human";
            this._redPlayerHumanRadio.UseVisualStyleBackColor = true;
            // 
            // _redPlayerComputerRadio
            // 
            this._redPlayerComputerRadio.AutoSize = true;
            this._redPlayerComputerRadio.Location = new System.Drawing.Point(6, 22);
            this._redPlayerComputerRadio.Name = "_redPlayerComputerRadio";
            this._redPlayerComputerRadio.Size = new System.Drawing.Size(79, 19);
            this._redPlayerComputerRadio.TabIndex = 5;
            this._redPlayerComputerRadio.Text = "Computer";
            this._redPlayerComputerRadio.UseVisualStyleBackColor = true;
            // 
            // boardCanvas
            // 
            this.boardCanvas.Location = new System.Drawing.Point(212, 69);
            this.boardCanvas.Name = "boardCanvas";
            this.boardCanvas.Size = new System.Drawing.Size(300, 300);
            this.boardCanvas.TabIndex = 10;
            this.boardCanvas.Click += new System.EventHandler(this.boardCanvas_Click);
            this.boardCanvas.Paint += new System.Windows.Forms.PaintEventHandler(this.boardCanvas_Paint);
            // 
            // _sourceCodeLink
            // 
            this._sourceCodeLink.AutoSize = true;
            this._sourceCodeLink.Location = new System.Drawing.Point(618, 432);
            this._sourceCodeLink.Name = "_sourceCodeLink";
            this._sourceCodeLink.Size = new System.Drawing.Size(74, 15);
            this._sourceCodeLink.TabIndex = 11;
            this._sourceCodeLink.TabStop = true;
            this._sourceCodeLink.Text = "Source Code";
            this._sourceCodeLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this._sourceCodeLink_LinkClicked);
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(704, 453);
            this.Controls.Add(this._sourceCodeLink);
            this.Controls.Add(this._currentTurnLabel);
            this.Controls.Add(this._currentTurn);
            this.Controls.Add(this.boardCanvas);
            this.Controls.Add(this._redPlayerGroupBox);
            this.Controls.Add(this._bluePlayerGroupBox);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this._topGroupBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.Text = "SOS Game";
            this._topGroupBox.ResumeLayout(false);
            this._topGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._boardSizeNum)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this._bluePlayerGroupBox.ResumeLayout(false);
            this._bluePlayerGroupBox.PerformLayout();
            this._blueSOGroupBox.ResumeLayout(false);
            this._blueSOGroupBox.PerformLayout();
            this._redPlayerGroupBox.ResumeLayout(false);
            this._redPlayerGroupBox.PerformLayout();
            this._redSOGroupBox.ResumeLayout(false);
            this._redSOGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private GroupBox _topGroupBox;
        private Label _boardSizeLabel;
        private NumericUpDown _boardSizeNum;
        private RadioButton _generalGameRadio;
        private RadioButton _simpleGameRadio;
        private CheckBox _recordGameCheckBox;
        private Label _currentTurnLabel;
        private Label _currentTurn;
        private Button _newGameButton;
        private Button _replayButton;
        private GroupBox groupBox2;
        private GroupBox _bluePlayerGroupBox;
        private RadioButton _bluePlayerORadio;
        private RadioButton _bluePlayerSRadio;
        private RadioButton _bluePlayerHumanRadio;
        private RadioButton _bluePlayerComputerRadio;
        private GroupBox _redPlayerGroupBox;
        private RadioButton _redPlayerHumanRadio;
        private RadioButton _redPlayerComputerRadio;
        private GroupBox _blueSOGroupBox;
        private GroupBox _redSOGroupBox;
        private RadioButton _redPlayerSRadio;
        private RadioButton _redPlayerORadio;
        private Panel boardCanvas;
        private Button _quitReplayButton;
        private Label _blueScoreLabel;
        private Label _redScoreLabel;
        private LinkLabel _sourceCodeLink;
        private Label _redScore;
        private Label _blueScore;
    }
}