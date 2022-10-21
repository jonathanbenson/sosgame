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

        private void label2_Click(object sender, EventArgs e)
        {

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
    }
}