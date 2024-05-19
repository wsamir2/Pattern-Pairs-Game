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
        int totalTime = 120;
        int countDownTime;
        bool gameOver = false;
        string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
        public frmMain()
        {
            InitializeComponent();
        }
        private void TimerEvent(object sender, EventArgs e)
        {
            countDownTime--;
            lblTimeLeft.Text = "Time Left: " + countDownTime + " seconds";
            if (countDownTime <= 0)
            {
                GameOver("Times Up, You Lose");
                // Navigate up to the project directory from the bin\Debug\netcoreappX.X directory
                string projectDirectory = Directory.GetParent(baseDirectory).Parent.Parent.FullName;
                foreach (PictureBox x in pictures)
                {
                    if (x.Tag != null)
                    {
                        string imagePath = Path.Combine(projectDirectory, "images", picA.Tag + ".png");
                        x.Image = Image.FromFile(imagePath);
                    }
                }
            }
        }
        private void RestartGameEvent(object sender, EventArgs e)
        {
            RestartGame();
        }
        private void LoadPictures()
        {
            int leftPos = 20;
            int topPos = 80;
            int rows = (int)numericUpDownRows.Value;
            int columns = (int)numericUpDownColumns.Value;
            if ((rows * columns) % 2 != 0)
            {
                MessageBox.Show("The number of cells must be even.", "Invalid Grid Size", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    pictures.Add(newPic);
                    newPic.Left = leftPos + j * 60;
                    newPic.Top = topPos + i * 60;
                    this.Controls.Add(newPic);
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
                }
            }
            else
            {
                CheckPictures(picA, picB);
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
            }
            firstChoice = null;
            secondChoice = null;
            foreach (PictureBox pics in pictures.ToList())
            {
                if (pics.Tag != null)
                {
                    pics.Image = null;
                }
            }
            // now lets check if all of the items have been solved
            if (pictures.All(o => o.Tag == pictures[0].Tag))
            {
                GameOver("Great Work, You Win!!!!");
            }
        }
        private void GameOver(string msg)
        {
             disposeCardTimer.Stop();
            gameOver = true;
            MessageBox.Show(msg + " Click Restart to Play Again.", "Walid Team Sayes: ");
        }

        private void btnRestartGame_Click(object sender, EventArgs e)
        {
            RestartGame();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoadPictures();
        }
    }
}
