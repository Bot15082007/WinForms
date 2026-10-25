using System;
using System.Drawing;
using System.Windows.Forms;

namespace WinFormsPractice
{
    public class Task4Form : Form
    {
        private TextBox textBox1;

        public Task4Form()
        {
            Text = "задание 4";
            ClientSize = new Size(600, 300);
            StartPosition = FormStartPosition.CenterScreen;

            textBox1 = new TextBox();
            textBox1.Left = 100; textBox1.Top = 50; textBox1.Width = 400;

            Controls.Add(textBox1);

            for (int i = 0; i < 3; i++)
            {
                Button b = new Button();
                b.Text = "кнопка " + (i + 1);
                b.Left = 50 + i * 180;
                b.Top = 150;
                b.Width = 130; b.Height = 45;
                b.Click += Button_Click;
                Controls.Add(b);
            }
        }

        private void Button_Click(object sender, EventArgs e)
        {
            Button clicked = (Button)sender;
            clicked.Text = textBox1.Text;
        }
    }
}
