using System;
using System.Drawing;
using System.Windows.Forms;

namespace WinFormsPractice
{
    public class Task2Form : Form
    {
        private Random random = new Random();

        public Task2Form()
        {
            Text = "задание 2";
            ClientSize = new Size(600, 350);
            StartPosition = FormStartPosition.CenterScreen;

            Button btn = new Button();
            btn.Text = "случайный цвет";
            btn.Width = 200; btn.Height = 50;
            btn.Left = (ClientSize.Width - btn.Width) / 2;
            btn.Top = (ClientSize.Height - btn.Height) / 2;
            btn.Click += (sender, e) =>
            {
                int r = random.Next(256); 
                int g = random.Next(256);
                int b = random.Next(256);
                this.BackColor = Color.FromArgb(r, g, b);
            };
            Controls.Add(btn);
        }
    }
}
