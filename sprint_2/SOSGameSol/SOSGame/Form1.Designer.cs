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
            this._bluePlayerGroupBox = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this._bluePlayerSRadio = new System.Windows.Forms.RadioButton();
            this._bluePlayerORadio = new System.Windows.Forms.RadioButton();
            this._bluePlayerHumanRadio = new System.Windows.Forms.RadioButton();
            this._bluePlayerComputerRadio = new System.Windows.Forms.RadioButton();
            this._redPlayerGroupBox = new System.Windows.Forms.GroupBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this._redPlayerSRadio = new System.Windows.Forms.RadioButton();
            this._redPlayerORadio = new System.Windows.Forms.RadioButton();
            this._redPlayerHumanRadio = new System.Windows.Forms.RadioButton();
            this._redPlayerComputerRadio = new System.Windows.Forms.RadioButton();
            this.boardCanvas = new System.Windows.Forms.Panel();
            this._topGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._boardSizeNum)).BeginInit();
            this.groupBox2.SuspendLayout();
            this._bluePlayerGroupBox.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this._redPlayerGroupBox.SuspendLayout();
            this.groupBox6.SuspendLayout();
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
            this._boardSizeLabel.Click += new System.EventHandler(this.label2_Click);
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
            this._boardSizeNum.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // _generalGameRadio
            // 
            this._generalGameRadio.AutoSize = true;
            this._generalGameRadio.Location = new System.Drawing.Point(107, 21);
            this._generalGameRadio.Name = "_generalGameRadio";
            this._generalGameRadio.Size = new System.Drawing.Size(99, 19);
            this._generalGameRadio.TabIndex = 2;
            this._generalGameRadio.TabStop = true;
            this._generalGameRadio.Text = "General Game";
            this._generalGameRadio.UseVisualStyleBackColor = true;
            // 
            // _simpleGameRadio
            // 
            this._simpleGameRadio.AutoSize = true;
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
            this._currentTurnLabel.Location = new System.Drawing.Point(284, 26);
            this._currentTurnLabel.Name = "_currentTurnLabel";
            this._currentTurnLabel.Size = new System.Drawing.Size(75, 15);
            this._currentTurnLabel.TabIndex = 1;
            this._currentTurnLabel.Text = "Current turn:";
            // 
            // _currentTurn
            // 
            this._currentTurn.AutoSize = true;
            this._currentTurn.ForeColor = System.Drawing.Color.DodgerBlue;
            this._currentTurn.Location = new System.Drawing.Point(365, 26);
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
            this.groupBox2.Controls.Add(this._recordGameCheckBox);
            this.groupBox2.Controls.Add(this._currentTurn);
            this.groupBox2.Controls.Add(this._replayButton);
            this.groupBox2.Controls.Add(this._currentTurnLabel);
            this.groupBox2.Controls.Add(this._newGameButton);
            this.groupBox2.Location = new System.Drawing.Point(12, 375);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(680, 54);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            // 
            // _bluePlayerGroupBox
            // 
            this._bluePlayerGroupBox.Controls.Add(this.groupBox5);
            this._bluePlayerGroupBox.Controls.Add(this._bluePlayerHumanRadio);
            this._bluePlayerGroupBox.Controls.Add(this._bluePlayerComputerRadio);
            this._bluePlayerGroupBox.Location = new System.Drawing.Point(12, 64);
            this._bluePlayerGroupBox.Name = "_bluePlayerGroupBox";
            this._bluePlayerGroupBox.Size = new System.Drawing.Size(194, 305);
            this._bluePlayerGroupBox.TabIndex = 8;
            this._bluePlayerGroupBox.TabStop = false;
            this._bluePlayerGroupBox.Text = "Blue Player";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this._bluePlayerSRadio);
            this.groupBox5.Controls.Add(this._bluePlayerORadio);
            this.groupBox5.Location = new System.Drawing.Point(6, 72);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(182, 65);
            this.groupBox5.TabIndex = 9;
            this.groupBox5.TabStop = false;
            // 
            // _bluePlayerSRadio
            // 
            this._bluePlayerSRadio.AutoSize = true;
            this._bluePlayerSRadio.Location = new System.Drawing.Point(17, 13);
            this._bluePlayerSRadio.Name = "_bluePlayerSRadio";
            this._bluePlayerSRadio.Size = new System.Drawing.Size(31, 19);
            this._bluePlayerSRadio.TabIndex = 7;
            this._bluePlayerSRadio.TabStop = true;
            this._bluePlayerSRadio.Text = "S";
            this._bluePlayerSRadio.UseVisualStyleBackColor = true;
            // 
            // _bluePlayerORadio
            // 
            this._bluePlayerORadio.AutoSize = true;
            this._bluePlayerORadio.Location = new System.Drawing.Point(17, 38);
            this._bluePlayerORadio.Name = "_bluePlayerORadio";
            this._bluePlayerORadio.Size = new System.Drawing.Size(34, 19);
            this._bluePlayerORadio.TabIndex = 8;
            this._bluePlayerORadio.TabStop = true;
            this._bluePlayerORadio.Text = "O";
            this._bluePlayerORadio.UseVisualStyleBackColor = true;
            // 
            // _bluePlayerHumanRadio
            // 
            this._bluePlayerHumanRadio.AutoSize = true;
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
            this._bluePlayerComputerRadio.TabStop = true;
            this._bluePlayerComputerRadio.Text = "Computer";
            this._bluePlayerComputerRadio.UseVisualStyleBackColor = true;
            // 
            // _redPlayerGroupBox
            // 
            this._redPlayerGroupBox.Controls.Add(this.groupBox6);
            this._redPlayerGroupBox.Controls.Add(this._redPlayerHumanRadio);
            this._redPlayerGroupBox.Controls.Add(this._redPlayerComputerRadio);
            this._redPlayerGroupBox.Location = new System.Drawing.Point(518, 64);
            this._redPlayerGroupBox.Name = "_redPlayerGroupBox";
            this._redPlayerGroupBox.Size = new System.Drawing.Size(174, 305);
            this._redPlayerGroupBox.TabIndex = 9;
            this._redPlayerGroupBox.TabStop = false;
            this._redPlayerGroupBox.Text = "Red Player";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this._redPlayerSRadio);
            this.groupBox6.Controls.Add(this._redPlayerORadio);
            this.groupBox6.Location = new System.Drawing.Point(6, 72);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(162, 65);
            this.groupBox6.TabIndex = 10;
            this.groupBox6.TabStop = false;
            // 
            // _redPlayerSRadio
            // 
            this._redPlayerSRadio.AutoSize = true;
            this._redPlayerSRadio.Location = new System.Drawing.Point(17, 13);
            this._redPlayerSRadio.Name = "_redPlayerSRadio";
            this._redPlayerSRadio.Size = new System.Drawing.Size(31, 19);
            this._redPlayerSRadio.TabIndex = 7;
            this._redPlayerSRadio.TabStop = true;
            this._redPlayerSRadio.Text = "S";
            this._redPlayerSRadio.UseVisualStyleBackColor = true;
            // 
            // _redPlayerORadio
            // 
            this._redPlayerORadio.AutoSize = true;
            this._redPlayerORadio.Location = new System.Drawing.Point(17, 38);
            this._redPlayerORadio.Name = "_redPlayerORadio";
            this._redPlayerORadio.Size = new System.Drawing.Size(34, 19);
            this._redPlayerORadio.TabIndex = 8;
            this._redPlayerORadio.TabStop = true;
            this._redPlayerORadio.Text = "O";
            this._redPlayerORadio.UseVisualStyleBackColor = true;
            // 
            // _redPlayerHumanRadio
            // 
            this._redPlayerHumanRadio.AutoSize = true;
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
            this._redPlayerComputerRadio.TabStop = true;
            this._redPlayerComputerRadio.Text = "Computer";
            this._redPlayerComputerRadio.UseVisualStyleBackColor = true;
            // 
            // boardCanvas
            // 
            this.boardCanvas.Location = new System.Drawing.Point(212, 69);
            this.boardCanvas.Name = "boardCanvas";
            this.boardCanvas.Size = new System.Drawing.Size(300, 300);
            this.boardCanvas.TabIndex = 10;
            this.boardCanvas.Paint += new System.Windows.Forms.PaintEventHandler(this.boardCanvas_Paint);
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(704, 441);
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
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this._redPlayerGroupBox.ResumeLayout(false);
            this._redPlayerGroupBox.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.ResumeLayout(false);

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
        private GroupBox groupBox5;
        private GroupBox groupBox6;
        private RadioButton _redPlayerSRadio;
        private RadioButton _redPlayerORadio;
        private Panel boardCanvas;
    }
}