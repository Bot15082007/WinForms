using System;
using System.Drawing;
using System.Windows.Forms;

namespace WinFormsPractice
{
    public class Task3Form : Form
    {
        private TextBox textBox1;

        public Task3Form()
        {
            Text = "задание 3";
            ClientSize = new Size(600, 300);
            StartPosition = FormStartPosition.CenterScreen;

            textBox1 = new TextBox();
            textBox1.Left = 100; textBox1.Top = 60; textBox1.Width = 400;

            Button btn = new Button();
            btn.Text = "отобразить";
            btn.Left = 220; btn.Top = 140; btn.Width = 160; btn.Height = 45;
            btn.Click += (sender, e) => MessageBox.Show(textBox1.Text);

            Controls.Add(textBox1);
            Controls.Add(btn);
        }
    }
}
