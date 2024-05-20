using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pattern_Pairs_Game
{
    public partial class frmMain : Form
    {
        List<int> numbers = new List<int> { 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6 ,7,7,8,8};
        string firstChoice;
        string secondChoice;
        int tries;
        List<PictureBox> pictures = new List<PictureBox>();
        PictureBox picA;
        PictureBox picB;
        int totalTime;
        int countDownTime;
        bool gameOver = false;
        string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
        Timer mismatchTimer = new Timer();
        public frmMain()
        {
            InitializeComponent();
            mismatchTimer.Interval = 1000;
            mismatchTimer.Tick += MismatchTimer_Tick;
        }
        private void TimerEvent(object sender, EventArgs e)
        {
            countDownTime--;
            lblTimeLeft.Text = "Time Left: " + countDownTime + " seconds";
            if (countDownTime == 0)
            {
                GameOver("Times Up, You Lose");
            }
        }

        private void CheckForCompletionEvent(object sender, EventArgs e)
        {
            CheckForCompletion();
        }
        private void RestartGameEvent(object sender, EventArgs e)
        {
            RestartGame();
        }
        private void LoadPictures()
        {
            int rows = (int)numericUpDownRows.Value;
            int columns = (int)numericUpDownColumns.Value;
            if ((rows * columns) % 2 != 0)
            {
                MessageBox.Show("The number of cells must be even.", "Invalid Grid Size", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (rows * columns == 2)
            {
                MessageBox.Show("This is a trivial case, Number of blocks should be 4 or more.", "Trivial Case", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int totalPairs = rows * columns / 2;
            if(totalPairs > 16)
            {
                MessageBox.Show("The Maximum allowed number of pairs is 16.", "Invalid Grid Size", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            numbers = Enumerable.Range(1, totalPairs).SelectMany(x => new List<int> { x, x }).ToList();
            pictures.Clear();
            this.Controls.OfType<PictureBox>().ToList().ForEach(p => this.Controls.Remove(p));
            tableLayoutPanel.Controls.Clear();

            tableLayoutPanel.RowCount = rows;
            tableLayoutPanel.ColumnCount = columns;

            tableLayoutPanel.RowStyles.Clear();
            tableLayoutPanel.ColumnStyles.Clear();

            for (int i = 0; i < rows; i++)
            {
                tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100f / rows));
            }

            for (int i = 0; i < columns; i++)
            {
                tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f / columns));
            }
            var randomList = numbers.OrderBy(x => Guid.NewGuid()).ToList();
            numbers = randomList;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    PictureBox newPic = new PictureBox();
                    newPic.Height = 50;
                    newPic.Width = 50;
                    newPic.BackColor = Color.LightGray;
                    newPic.SizeMode = PictureBoxSizeMode.StretchImage;
                    newPic.Click += NewPic_Click;
                    newPic.Tag = numbers[i * columns + j].ToString();
                    pictures.Add(newPic);
                    tableLayoutPanel.Controls.Add(newPic, j, i);
                }
            }
            RestartGame();
        }
        private void NewPic_Click(object sender, EventArgs e)
        {
            if (gameOver)
            {
                // dont register a click if the game is over
                return;
            }
            // Navigate up to the project directory from the bin\Debug\netcoreappX.X directory
            string projectDirectory = Directory.GetParent(baseDirectory).Parent.Parent.FullName;
            if (firstChoice == null)
            {
                picA = sender as PictureBox;
                if (picA.Tag != null && picA.Image == null)
                {
                    string imagePath = Path.Combine(projectDirectory, "images", picA.Tag + ".png");
                    picA.Image = Image.FromFile(imagePath);
                    firstChoice = (string)picA.Tag;
                }
            }
            else if (secondChoice == null)
            {
                picB = sender as PictureBox;
                if (picB.Tag != null && picB.Image == null)
                {
                    string imagePath = Path.Combine(projectDirectory, "images", picB.Tag + ".png");
                    picB.Image = Image.FromFile(imagePath);
                    secondChoice = (string)picB.Tag;
                    CheckPictures(picA, picB);
                }
            }
        }
        private void RestartGame()
        {
            // randomise the original list
            var randomList = numbers.OrderBy(x => Guid.NewGuid()).ToList();
            // assign the random list to the original
            numbers = randomList;
            for (int i = 0; i < pictures.Count; i++)
            {
                pictures[i].Image = null;
                pictures[i].Tag = numbers[i].ToString();
            }
            tries = 0;
            lblStatus.Text = "Mismatched: " + tries + " times.";
            lblTimeLeft.Text = "Time Left: " + totalTime;
            gameOver = false;
            disposeCardTimer.Start();
            checkCompletionTimer.Start();
            countDownTime = totalTime;
        }
        private void CheckPictures(PictureBox A, PictureBox B)
        {
            if (firstChoice == secondChoice)
            {
                A.Tag = null;
                B.Tag = null;
            }
            else
            {
                tries++;
                lblStatus.Text = "Mismatched " + tries + " times.";
                mismatchTimer.Start();
            }
            firstChoice = null;
            secondChoice = null;
        }

        private void MismatchTimer_Tick(object sender, EventArgs e)
        {
            // Stop the timer
            mismatchTimer.Stop();

            // Flip the cards back over
            if (picA != null && picA.Tag != null)
            {
                picA.Image = null;
            }
            if (picB != null && picB.Tag != null)
            {
                picB.Image = null;
            }

            // Reset the selected pictures
            picA = null;
            picB = null;
        }

        private void CheckForCompletion()
        {
            // Check if all tags are null (indicating all pairs are matched)
            if (pictures.All(p => p.Tag == null))
            {
                GameOver("Great Work, You Win!!!!");
            }
        }
        private void GameOver(string msg)
        {
            disposeCardTimer.Stop();
            checkCompletionTimer.Stop();
            gameOver = true;
            MessageBox.Show(msg + " Click Restart to Play Again.", "");
        }

        private void btnRestartGame_Click(object sender, EventArgs e)
        {
            RestartGame();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SetTimeOutValue();
            LoadPictures();
        }

        private void SetTimeOutValue()
        {
            totalTime = ((int)numericUpDownTimer.Value)*60;
        }
    }
}
