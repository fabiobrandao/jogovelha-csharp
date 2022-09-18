using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace JogoDaVelha
{
    public partial class Main : Form
    {
        private string currentPlayer;
        private string lastWinner;
        private List<Score> scores;

        public Main()
        {
            InitializeComponent();
            StartGame("X");
            StartScore();
        }

        public void StartGame(string player)
        {
            currentPlayer = player;
            btnA1.Text = btnA2.Text = btnA3.Text = btnB1.Text = btnB2.Text = btnB3.Text = btnC1.Text = btnC2.Text = btnC3.Text = "";
            btnA1.BackColor = btnA2.BackColor = btnA3.BackColor = btnB1.BackColor = btnB2.BackColor = btnB3.BackColor = btnC1.BackColor = btnC2.BackColor = btnC3.BackColor = Color.White;
        }

        public void ChangePlayer()
        {
            if (currentPlayer == "X")
                currentPlayer = "O";
            else
                currentPlayer = "X";
        }

        public void StartScore()
        {
            scores = new List<Score>();
            scores.Add(new Score("X"));
            scores.Add(new Score("O"));

            txbX.Text = txbO.Text = "0";
        }

        public bool HaveWinner(string player)
        {
            if (btnA1.Text == player && btnA2.Text == player && btnA3.Text == player)
            {
                btnA1.BackColor = Color.Yellow;
                btnA2.BackColor = Color.Yellow;
                btnA3.BackColor = Color.Yellow;
                return true;
            }

            if (btnB1.Text == player && btnB2.Text == player && btnB3.Text == player)
            {
                btnB1.BackColor = btnB2.BackColor = btnB3.BackColor = Color.Yellow;
                return true;
            }

            if (btnC1.Text == player && btnC2.Text == player && btnC3.Text == player)
            {
                btnC1.BackColor = btnC2.BackColor = btnC3.BackColor = Color.Yellow;
                return true;
            }

            if (btnA1.Text == player && btnB1.Text == player && btnC1.Text == player)
            {
                btnA1.BackColor = btnB1.BackColor = btnC1.BackColor = Color.Yellow;
                return true;
            }

            if (btnA2.Text == player && btnB2.Text == player && btnC2.Text == player)
            {
                btnA2.BackColor = btnB2.BackColor = btnC2.BackColor = Color.Yellow;
                return true;
            }

            if (btnA3.Text == player && btnB3.Text == player && btnC3.Text == player)
            {
                btnA3.BackColor = btnB3.BackColor = btnC3.BackColor = Color.Yellow;
                return true;
            }

            if (btnA1.Text == player && btnB2.Text == player && btnC3.Text == player)
            {
                btnA1.BackColor = btnB2.BackColor = btnC3.BackColor = Color.Yellow;
                return true;
            }

            if (btnA3.Text == player && btnB2.Text == player && btnC1.Text == player)
            {
                btnA3.BackColor = btnB2.BackColor = btnC1.BackColor = Color.Yellow;
                return true;
            }

            if (btnA1.Text != "" && btnA2.Text != "" && btnA3.Text != "" &&
                btnB1.Text != "" && btnB2.Text != "" && btnB3.Text != "" &&
                btnC1.Text != "" && btnC2.Text != "" && btnC3.Text != ""
            )
            {
                MessageBox.Show("Deu velha!!! Ninguém soma pontos");
                ChangePlayer();
                StartGame(currentPlayer); ;
            }

            return false;
        }

        public void ShowWinner(string player)
        {
            MessageBox.Show(player + " ganhou!!!");

            Score scoreByPlayer = scores.Where(x => x.Player == player).FirstOrDefault();

            scoreByPlayer.SetPoints(10 + (lastWinner == scoreByPlayer.Player == true ? 5 : 0));

            MessageBox.Show(string.Format("{0} foi o vencedor, total de {1} pontos\nGanhe duas seguindas e acumule +5 pontos\n\nO vencedor começa o jogo!", scoreByPlayer.Player, scoreByPlayer.Points));

            lastWinner = scoreByPlayer.Player;

            if (scoreByPlayer.Player == "X")
                txbX.Text = scoreByPlayer.Points.ToString();
            else
                txbO.Text = scoreByPlayer.Points.ToString();

            StartGame(scoreByPlayer.Player);
        }

        private void btnPlayer_Click(object sender, EventArgs e)
        {
            Button btnPlayer = (Button)sender;

            if (string.IsNullOrEmpty(btnPlayer.Text))
            {
                btnPlayer.Text = currentPlayer;
                Console.Beep();
            }

            if (HaveWinner(currentPlayer))
                ShowWinner(currentPlayer);
            else
                ChangePlayer();
        }

        private void btnClearPoints_Click(object sender, EventArgs e)
        {
            StartScore();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
