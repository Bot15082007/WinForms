using System;
using System.Drawing;
using System.Windows.Forms;

namespace WinFormsPractice
{
    public class Task6Form : Form
    {
        private TextBox textBox1;

        public Task6Form()
        {
            Text = "задание 6";
            ClientSize = new Size(500, 250);
            StartPosition = FormStartPosition.CenterScreen;

            textBox1 = new TextBox();
            textBox1.Left = 50; textBox1.Top = 50; textBox1.Width = 400;

            Button btnBlock = new Button();
            btnBlock.Text = "блокировать";
            btnBlock.Left = 50; btnBlock.Top = 120; btnBlock.Width = 150; btnBlock.Height = 40;
            btnBlock.Click += (sender, e) => textBox1.Enabled = false;

            Button btnUnblock = new Button();
            btnUnblock.Text = "разблокировать";
            btnUnblock.Left = 300; btnUnblock.Top = 120; btnUnblock.Width = 150; btnUnblock.Height = 40;
            btnUnblock.Click += (sender, e) => textBox1.Enabled = true;

            Controls.Add(textBox1);
            Controls.Add(btnBlock);
            Controls.Add(btnUnblock);
        }
    }
}
