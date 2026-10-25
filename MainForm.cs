using System;
using System.Drawing;
using System.Windows.Forms;

namespace WinFormsPractice
{
    public class MainForm : Form
    {
        public MainForm()
        {
            Text = "Выбор задания";
            ClientSize = new Size(420, 340);
            StartPosition = FormStartPosition.CenterScreen;

            AddButton("задание 1", 20, 20, () => new Task1Form());
            AddButton("задание 2", 20, 80, () => new Task2Form());
            AddButton("задание 3", 20, 140, () => new Task3Form());
            AddButton("задание 4", 20, 200, () => new Task4Form());
            AddButton("задание 5", 20, 260, () => new Task5Form());

            AddButton("задание 6", 190, 20, () => new Task6Form());
            AddButton("задание 8 (калькулятор)", 190, 80, () => new Task8Var2Form());
        }

        private void AddButton(string text, int x, int y, Func<Form> createForm)
        {
            Button b = new Button();
            b.Text = text;
            b.Left = x;
            b.Top = y;
            b.Width = 160;
            b.Height = 45;
            b.Click += (sender, e) =>
            {
                Form f = createForm(); 
                f.Show();             
            };
            Controls.Add(b);
        }
    }
}
