using System;
using System.Drawing;
using System.Windows.Forms;

namespace WinFormsPractice
{
    public class Task5Form : Form
    {
        private Label[] labels = new Label[4];

        public Task5Form()
        {
            Text = "задание 5";
            ClientSize = new Size(600, 300);
            StartPosition = FormStartPosition.CenterScreen;

            for (int i = 0; i < 4; i++)
            {
                Button b = new Button();
                b.Text = "кнопка " + (i + 1);
                b.Left = 30; b.Top = 30 + i * 55;
                b.Width = 120; b.Height = 35;

                Label l = new Label();
                l.Text = "текст виден при нажатии на кнопку " + (i + 1);
                l.Left = 180; l.Top = 38 + i * 55;
                l.AutoSize = true;

                b.Tag = l; 
                b.Click += Button_Click;

                labels[i] = l;
                Controls.Add(b);
                Controls.Add(l);
            }

            this.Load += Task5Form_Load;
        }

        private void Task5Form_Load(object sender, EventArgs e)
        {
            foreach (Label l in labels)
            {
                l.Visible = false; 
            }
        }

        private void Button_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            Label l = (Label)b.Tag;
            l.Visible = true; 
        }
    }
}
