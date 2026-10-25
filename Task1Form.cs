using System;
using System.Drawing;
using System.Windows.Forms;

namespace WinFormsPractice
{
    public class Task1Form : Form
    {
        private TextBox txtNumber;
        private Label lblWin, lblInfo, lblHint, lblAttempts;
        private Button btnGuess, btnReset;

        private Random rnd = new Random();
        private int secret;
        private int attempts;

        public Task1Form()
        {
            Text = "задание 1";
            ClientSize = new Size(600, 340);
            StartPosition = FormStartPosition.CenterScreen;

            lblWin = new Label();
            lblWin.Left = 100; lblWin.Top = 20; lblWin.Width = 400; lblWin.Height = 30;
            lblWin.TextAlign = ContentAlignment.MiddleCenter;
            lblWin.Font = new Font("Segoe UI", 12, FontStyle.Bold);

            lblInfo = new Label();
            lblInfo.Text = "Загадано число от 1 до 100. Попробуйте угадать!";
            lblInfo.Left = 100; lblInfo.Top = 60; lblInfo.Width = 400; lblInfo.Height = 25;
            lblInfo.TextAlign = ContentAlignment.MiddleCenter;

            txtNumber = new TextBox();
            txtNumber.Left = 100; txtNumber.Top = 100; txtNumber.Width = 400;
            txtNumber.Font = new Font("Segoe UI", 14);

            lblHint = new Label();
            lblHint.Left = 60; lblHint.Top = 170; lblHint.AutoSize = true;

            lblAttempts = new Label();
            lblAttempts.Left = 360; lblAttempts.Top = 170; lblAttempts.AutoSize = true;

            btnGuess = new Button();
            btnGuess.Text = "угадать!";
            btnGuess.Left = 150; btnGuess.Top = 230; btnGuess.Width = 160; btnGuess.Height = 45;
            btnGuess.Click += BtnGuess_Click;

            btnReset = new Button();
            btnReset.Text = "заново";
            btnReset.Left = 400; btnReset.Top = 240; btnReset.Width = 90; btnReset.Height = 30;
            btnReset.Click += BtnReset_Click;

            Controls.AddRange(new Control[] { lblWin, lblInfo, txtNumber, lblHint, lblAttempts, btnGuess, btnReset });
            AcceptButton = btnGuess;

            StartNewGame();
        }

        private void StartNewGame()
        {
            secret = rnd.Next(1, 101);
            attempts = 0;
            lblWin.Text = "";
            lblHint.Text = "Подсказка:";
            lblAttempts.Text = "Попытки: 0";
            txtNumber.Clear();
            btnGuess.Enabled = true;
            txtNumber.Focus();
        }

        private void BtnGuess_Click(object sender, EventArgs e)
        {
            int number;

            if (!int.TryParse(txtNumber.Text, out number))
            {
                MessageBox.Show("Введите целое число!", "Ошибка ввода",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            attempts++;
            lblAttempts.Text = "Попытки: " + attempts;

            if (number == secret)
            {
                lblWin.Text = "ВЫ УГАДАЛИ!";
                lblHint.Text = "Подсказка:";
                btnGuess.Enabled = false;
            }
            else if (number < secret)
            {
                lblHint.Text = "Подсказка: число больше!";
            }
            else
            {
                lblHint.Text = "Подсказка: число меньше!";
            }
        }

        private void InitializeComponent()
        {

        }

        private void BtnReset_Click(object sender, EventArgs e)
        {
            StartNewGame();
        }
    }
}
